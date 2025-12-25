#!/bin/bash
set -e

# Container Configuration (can be overridden via environment variables)
POSTGRES_CONTAINER="${POSTGRES_CONTAINER:-ems-postgres-master}"
PGBACKREST_CONTAINER="${PGBACKREST_CONTAINER:-ems-pgbackrest}"
BACKUP_SCHEDULER_CONTAINER="${BACKUP_SCHEDULER_CONTAINER:-ems-backup-scheduler}"
DISCORD_WEBHOOK_URL="${DISCORD_WEBHOOK_URL}"

# Send Discord notification
send_notification() {
    local title="$1"
    local message="$2"
    local color="$3"  # 3066993 (green), 15158332 (red), 16776960 (yellow)

    if [ -n "$DISCORD_WEBHOOK_URL" ]; then
        local timestamp=$(date -u +"%Y-%m-%dT%H:%M:%SZ")
        curl -s -H "Content-Type: application/json" -X POST "${DISCORD_WEBHOOK_URL}" \
            -d "{
                \"embeds\": [{
                    \"title\": \"${title}\",
                    \"description\": \"${message}\",
                    \"color\": ${color},
                    \"timestamp\": \"${timestamp}\",
                    \"footer\": {
                        \"text\": \"EMS v1 Master Monitoring\"
                    }
                }]
            }" > /dev/null 2>&1
    fi
}

check_database_status() {
    echo "1. Database Status Check"
    if docker exec $POSTGRES_CONTAINER pg_isready -U postgres > /dev/null 2>&1; then
        echo "   ✅ Database is ready and accepting connections"

        # Check PostgreSQL version
        local pg_version=$(docker exec $POSTGRES_CONTAINER psql -U postgres -t -c "SELECT version();" 2>/dev/null | head -1 | xargs)
        if [ -n "$pg_version" ]; then
            echo "   📌 Version: PostgreSQL $(echo $pg_version | grep -oP 'PostgreSQL \K[0-9]+\.[0-9]+')"
        fi
        return 0
    else
        echo "   ❌ Database is not ready!"
        send_notification "🚨 Database Down" "EMS v1 Master database is not responding" 15158332
        return 1
    fi
}

check_backup_status() {
    echo ""
    echo "2. Backup System Status"

    # Check pgBackRest stanza status
    local stanza_status=$(docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main info 2>&1 | grep "status:" | awk '{print $2}')

    if [ "$stanza_status" = "ok" ]; then
        echo "   ✅ Stanza status: OK"
    else
        echo "   ❌ Stanza status: $stanza_status"
        send_notification "🚨 Backup System Error" "pgBackRest stanza status: $stanza_status" 15158332
        return 1
    fi

    # Check encryption
    local cipher=$(docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main info 2>&1 | grep "cipher:" | awk '{print $2}')
    if [ "$cipher" = "aes-256-cbc" ]; then
        echo "   ✅ Encryption: AES-256-CBC"
    else
        echo "   ⚠️  Encryption: $cipher"
    fi

    # Check backup age
    if command -v jq &> /dev/null; then
        local last_backup=$(docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main info --output=json 2>/dev/null | \
            jq -r '.[0].backup[-1].timestamp.stop' 2>/dev/null)
        local backup_label=$(docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main info --output=json 2>/dev/null | \
            jq -r '.[0].backup[-1].label' 2>/dev/null)

        if [ -n "$last_backup" ] && [ "$last_backup" != "null" ]; then
            local backup_age=$(( $(date +%s) - $last_backup ))
            local hours_old=$(( backup_age / 3600 ))

            if [ "$hours_old" -gt 48 ]; then
                echo "   ⚠️  Last backup: ${hours_old} hours ago (${backup_label})"
                send_notification "⚠️ Backup Age Warning" "Last backup is ${hours_old} hours old - scheduled backup may have failed" 16776960
                return 1
            else
                echo "   ✅ Last backup: ${hours_old} hours ago (${backup_label})"
            fi
        fi
    else
        echo "   ℹ️  Install jq for detailed backup age analysis"
    fi

    # Count backups
    local full_count=$(docker exec $PGBACKREST_CONTAINER sh -c 'ls -d /backup/backup/main/*F 2>/dev/null | wc -l' 2>/dev/null || echo "0")
    local incr_count=$(docker exec $PGBACKREST_CONTAINER sh -c 'ls -d /backup/backup/main/*I 2>/dev/null | wc -l' 2>/dev/null || echo "0")
    echo "   📊 Backups: ${full_count} full, ${incr_count} incremental"

    return 0
}

check_disk_space() {
    echo ""
    echo "3. Storage Analysis"

    # Check Docker volume sizes
    local data_volume=$(docker volume inspect ems_v1_pg_master_data --format '{{.Mountpoint}}' 2>/dev/null)
    local backup_volume=$(docker volume inspect ems_v1_postgres-backups --format '{{.Mountpoint}}' 2>/dev/null)

    if [ -n "$data_volume" ]; then
        local data_usage=$(docker exec $POSTGRES_CONTAINER du -sh /var/lib/postgresql/data 2>/dev/null | awk '{print $1}' || echo "N/A")
        echo "   📁 Database data: $data_usage"
    fi

    if [ -n "$backup_volume" ]; then
        local backup_usage=$(docker exec $PGBACKREST_CONTAINER du -sh /backup 2>/dev/null | awk '{print $1}' || echo "N/A")
        echo "   💾 Backup storage: $backup_usage"
    fi

    # Check host disk usage
    local usage=$(df -h / 2>/dev/null | awk 'NR==2 {print $5}' | sed 's/%//')

    if [ -z "$usage" ]; then
        echo "   ⚠️  Cannot check host disk usage"
        return 1
    fi

    if [ "$usage" -gt 90 ]; then
        echo "   🔴 CRITICAL: Host disk usage at ${usage}%"
        send_notification "🚨 CRITICAL: Disk Space Alert" "EMS v1 host disk usage at ${usage}%" 15158332
        return 1
    elif [ "$usage" -gt 80 ]; then
        echo "   ⚠️  WARNING: Host disk usage at ${usage}%"
        send_notification "⚠️ Disk Space Warning" "EMS v1 host disk usage at ${usage}%" 16776960
        return 1
    fi

    echo "   ✅ Host disk usage: ${usage}%"
    return 0
}

check_connections() {
    echo ""
    echo "4. Database Connections"

    local conn_count=$(docker exec $POSTGRES_CONTAINER psql -U postgres -d postgres -t -c \
        "SELECT count(*) FROM pg_stat_activity WHERE state = 'active';" 2>/dev/null | tr -d '[:space:]')

    local max_conn=$(docker exec $POSTGRES_CONTAINER psql -U postgres -d postgres -t -c \
        "SHOW max_connections;" 2>/dev/null | tr -d '[:space:]')

    if [ -n "$conn_count" ] && [ -n "$max_conn" ]; then
        local conn_pct=$(( conn_count * 100 / max_conn ))

        if [ "$conn_pct" -gt 90 ]; then
            echo "   🔴 CRITICAL: Active connections at ${conn_pct}% (${conn_count}/${max_conn})"
            send_notification "🚨 Connection Pool Alert" "Active connections at ${conn_pct}% (${conn_count}/${max_conn})" 15158332
            return 1
        elif [ "$conn_pct" -gt 75 ]; then
            echo "   ⚠️  WARNING: Active connections at ${conn_pct}% (${conn_count}/${max_conn})"
            return 1
        fi

        echo "   ✅ Active connections: ${conn_count}/${max_conn} (${conn_pct}%)"
    else
        echo "   ⚠️  Cannot retrieve connection information"
        return 1
    fi

    return 0
}

check_database_size() {
    echo ""
    echo "5. Database Statistics"

    local db_size=$(docker exec $POSTGRES_CONTAINER psql -U postgres -d postgres -t -c \
        "SELECT pg_size_pretty(pg_database_size('postgres'));" 2>/dev/null | tr -d '[:space:]')

    if [ -n "$db_size" ]; then
        echo "   📊 Database size: ${db_size}"
    fi

    # Check database count
    local db_count=$(docker exec $POSTGRES_CONTAINER psql -U postgres -t -c \
        "SELECT count(*) FROM pg_database WHERE datistemplate = false;" 2>/dev/null | tr -d '[:space:]')

    if [ -n "$db_count" ]; then
        echo "   🗄️  Total databases: ${db_count}"
    fi

    # Check uptime
    local uptime=$(docker exec $POSTGRES_CONTAINER psql -U postgres -t -c \
        "SELECT date_trunc('second', current_timestamp - pg_postmaster_start_time()) as uptime;" 2>/dev/null | xargs)

    if [ -n "$uptime" ]; then
        echo "   ⏱️  Uptime: ${uptime}"
    fi

    return 0
}

check_container_health() {
    echo ""
    echo "6. Container Health"

    # PostgreSQL
    local pg_status=$(docker inspect $POSTGRES_CONTAINER --format='{{.State.Status}}' 2>/dev/null || echo "not found")
    local pg_health=$(docker inspect $POSTGRES_CONTAINER --format='{{.State.Health.Status}}' 2>/dev/null || echo "none")

    if [ "$pg_status" = "running" ]; then
        if [ "$pg_health" = "healthy" ] || [ "$pg_health" = "none" ]; then
            echo "   ✅ PostgreSQL: Running"
        else
            echo "   ⚠️  PostgreSQL: Running but $pg_health"
        fi
    else
        echo "   ❌ PostgreSQL: $pg_status"
        send_notification "🚨 Container Down" "PostgreSQL container is $pg_status" 15158332
        return 1
    fi

    # pgBackRest
    local pbr_status=$(docker inspect $PGBACKREST_CONTAINER --format='{{.State.Status}}' 2>/dev/null || echo "not found")

    if [ "$pbr_status" = "running" ]; then
        echo "   ✅ pgBackRest: Running"
    else
        echo "   ❌ pgBackRest: $pbr_status"
        send_notification "⚠️ Backup Container Issue" "pgBackRest container is $pbr_status" 16776960
    fi

    # Backup Scheduler
    local sched_status=$(docker inspect $BACKUP_SCHEDULER_CONTAINER --format='{{.State.Status}}' 2>/dev/null || echo "not found")

    if [ "$sched_status" = "running" ]; then
        echo "   ✅ Backup Scheduler: Running"
    else
        echo "   ⚠️  Backup Scheduler: $sched_status"
    fi

    return 0
}

# Run all checks
echo "========================================"
echo "EMS v1 PostgreSQL Health Check"
echo "========================================"
echo "Timestamp: $(date '+%Y-%m-%d %H:%M:%S')"
echo "========================================"

FAILED_CHECKS=0

check_database_status || ((FAILED_CHECKS++))
check_backup_status || ((FAILED_CHECKS++))
check_disk_space || ((FAILED_CHECKS++))
check_connections || ((FAILED_CHECKS++))
check_database_size || ((FAILED_CHECKS++))
check_container_health || ((FAILED_CHECKS++))

echo ""
echo "========================================"
echo "Health Check Summary"
echo "========================================"

if [ $FAILED_CHECKS -eq 0 ]; then
    echo "✅ All checks PASSED"
    echo "✅ System is healthy"
else
    echo "⚠️  ${FAILED_CHECKS} check(s) FAILED or have warnings"
    echo "⚠️  Review output above for details"
fi

echo "========================================"
echo ""
echo "For detailed backup info:"
echo "  docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main info"
echo ""
echo "For verification:"
echo "  cd /home/marshmary/Documents/ems-db/ems_v1"
echo "  ./scripts/verify-backups.sh"
echo ""

exit $FAILED_CHECKS
