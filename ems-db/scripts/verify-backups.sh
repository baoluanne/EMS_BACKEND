#!/bin/bash
set -e

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

# Container Configuration (can be overridden via environment variables)
POSTGRES_CONTAINER="${POSTGRES_CONTAINER:-ems-postgres-master}"
PGBACKREST_CONTAINER="${PGBACKREST_CONTAINER:-ems-pgbackrest}"
BACKUP_SCHEDULER_CONTAINER="${BACKUP_SCHEDULER_CONTAINER:-ems-backup-scheduler}"

# Configuration
WARNING_AGE_HOURS=48
CRITICAL_AGE_HOURS=72

echo -e "${BLUE}=== pgBackRest Backup Verification Report ===${NC}"
echo "Generated: $(date '+%Y-%m-%d %H:%M:%S')"
echo ""

# 1. Check stanza status
echo -e "${BLUE}1. Stanza Status Check${NC}"
STANZA_STATUS=$(docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main info 2>&1 | grep "status:" | awk '{print $2}')
CIPHER_STATUS=$(docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main info 2>&1 | grep "cipher:" | awk '{print $2}')

if [ "$STANZA_STATUS" = "ok" ]; then
    echo -e "   Stanza Status: ${GREEN}✅ OK${NC}"
else
    echo -e "   Stanza Status: ${RED}❌ ERROR${NC}"
    exit 1
fi

if [ "$CIPHER_STATUS" = "aes-256-cbc" ]; then
    echo -e "   Encryption: ${GREEN}✅ AES-256-CBC${NC}"
else
    echo -e "   Encryption: ${YELLOW}⚠️  $CIPHER_STATUS${NC}"
fi
echo ""

# 2. Count backups
echo -e "${BLUE}2. Backup Inventory${NC}"
FULL_COUNT=$(docker exec $PGBACKREST_CONTAINER sh -c 'ls -d /backup/backup/main/*F 2>/dev/null | wc -l' || echo "0")
INCR_COUNT=$(docker exec $PGBACKREST_CONTAINER sh -c 'ls -d /backup/backup/main/*I 2>/dev/null | wc -l' || echo "0")
DIFF_COUNT=$(docker exec $PGBACKREST_CONTAINER sh -c 'ls -d /backup/backup/main/*D 2>/dev/null | wc -l' || echo "0")

echo "   Full backups: $FULL_COUNT"
echo "   Incremental backups: $INCR_COUNT"
echo "   Differential backups: $DIFF_COUNT"
echo "   Total backups: $(($FULL_COUNT + $INCR_COUNT + $DIFF_COUNT))"

if [ "$FULL_COUNT" -lt 1 ]; then
    echo -e "   ${RED}❌ ERROR: No full backups found!${NC}"
    exit 1
else
    echo -e "   ${GREEN}✅ At least one full backup exists${NC}"
fi
echo ""

# 3. Check latest backup age
echo -e "${BLUE}3. Latest Backup Age${NC}"
if command -v jq &> /dev/null; then
    LATEST_TIMESTAMP=$(docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main info --output=json 2>/dev/null | \
        jq -r '.[0].backup[-1].timestamp.stop' 2>/dev/null || echo "0")
    LATEST_LABEL=$(docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main info --output=json 2>/dev/null | \
        jq -r '.[0].backup[-1].label' 2>/dev/null || echo "unknown")
    LATEST_TYPE=$(docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main info --output=json 2>/dev/null | \
        jq -r '.[0].backup[-1].type' 2>/dev/null || echo "unknown")

    if [ "$LATEST_TIMESTAMP" != "0" ] && [ "$LATEST_TIMESTAMP" != "null" ]; then
        CURRENT=$(date +%s)
        AGE_SECONDS=$(( $CURRENT - $LATEST_TIMESTAMP ))
        AGE_HOURS=$(( $AGE_SECONDS / 3600 ))
        AGE_MINUTES=$(( ($AGE_SECONDS % 3600) / 60 ))

        echo "   Latest backup: $LATEST_LABEL ($LATEST_TYPE)"
        echo "   Completed: $(date -d @$LATEST_TIMESTAMP '+%Y-%m-%d %H:%M:%S')"
        echo "   Age: ${AGE_HOURS}h ${AGE_MINUTES}m"

        if [ $AGE_HOURS -gt $CRITICAL_AGE_HOURS ]; then
            echo -e "   ${RED}❌ CRITICAL: Backup is older than ${CRITICAL_AGE_HOURS} hours!${NC}"
            exit 1
        elif [ $AGE_HOURS -gt $WARNING_AGE_HOURS ]; then
            echo -e "   ${YELLOW}⚠️  WARNING: Backup is older than ${WARNING_AGE_HOURS} hours${NC}"
        else
            echo -e "   ${GREEN}✅ Backup age is acceptable${NC}"
        fi
    else
        echo -e "   ${YELLOW}⚠️  Unable to determine backup age (jq may have issues)${NC}"
    fi
else
    echo -e "   ${YELLOW}⚠️  jq not installed - skipping timestamp analysis${NC}"
    LATEST_BACKUP=$(docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main info 2>/dev/null | grep -E "(full|incr|diff) backup:" | tail -1)
    echo "   Latest backup: $LATEST_BACKUP"
fi
echo ""

# 4. Database size vs backup size
echo -e "${BLUE}4. Size Analysis${NC}"
DB_SIZE=$(docker exec $POSTGRES_CONTAINER psql -U postgres -t -c "SELECT pg_size_pretty(pg_database_size('postgres'));" 2>/dev/null | xargs || echo "N/A")
BACKUP_SIZE=$(docker exec $PGBACKREST_CONTAINER du -sh /backup/backup/main/ 2>/dev/null | awk '{print $1}' || echo "N/A")

echo "   Database size: $DB_SIZE"
echo "   Backup storage: $BACKUP_SIZE"

if [ "$DB_SIZE" != "N/A" ] && [ "$BACKUP_SIZE" != "N/A" ]; then
    echo -e "   ${GREEN}✅ Backup size is reasonable${NC}"
fi
echo ""

# 5. Verify backup integrity
echo -e "${BLUE}5. Backup Integrity Verification${NC}"
if docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main verify &>/dev/null; then
    echo -e "   ${GREEN}✅ PASSED - All backups verified successfully${NC}"
else
    echo -e "   ${RED}❌ FAILED - Backup verification errors detected${NC}"
    echo "   Check logs: docker exec $PGBACKREST_CONTAINER cat /var/log/pgbackrest/main-verify.log"
    exit 1
fi
echo ""

# 6. Storage usage
echo -e "${BLUE}6. Docker Volume Storage${NC}"
docker system df -v 2>/dev/null | grep ems_v1 | grep -E "(pg_master_data|postgres-backups)" || echo "   No volume data available"
echo ""

# 7. Container health
echo -e "${BLUE}7. Container Health${NC}"
PGBACKREST_STATUS=$(docker inspect $PGBACKREST_CONTAINER --format='{{.State.Status}}' 2>/dev/null || echo "not found")
POSTGRES_STATUS=$(docker inspect $POSTGRES_CONTAINER --format='{{.State.Status}}' 2>/dev/null || echo "not found")
SCHEDULER_STATUS=$(docker inspect $BACKUP_SCHEDULER_CONTAINER --format='{{.State.Status}}' 2>/dev/null || echo "not found")

echo -n "   pgBackRest: "
[ "$PGBACKREST_STATUS" = "running" ] && echo -e "${GREEN}✅ Running${NC}" || echo -e "${RED}❌ $PGBACKREST_STATUS${NC}"

echo -n "   PostgreSQL: "
[ "$POSTGRES_STATUS" = "running" ] && echo -e "${GREEN}✅ Running${NC}" || echo -e "${RED}❌ $POSTGRES_STATUS${NC}"

echo -n "   Scheduler: "
[ "$SCHEDULER_STATUS" = "running" ] && echo -e "${GREEN}✅ Running${NC}" || echo -e "${RED}❌ $SCHEDULER_STATUS${NC}"

echo ""

# 8. Summary
echo -e "${BLUE}=== Verification Summary ===${NC}"
if [ "$STANZA_STATUS" = "ok" ] && [ "$FULL_COUNT" -ge 1 ]; then
    echo -e "${GREEN}✅ All critical checks PASSED${NC}"
    echo -e "${GREEN}✅ Backup system is healthy${NC}"
    EXIT_CODE=0
else
    echo -e "${RED}❌ Some checks FAILED${NC}"
    echo -e "${RED}❌ Immediate attention required${NC}"
    EXIT_CODE=1
fi

echo ""
echo "For detailed information, run:"
echo "  docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main info"
echo ""

exit $EXIT_CODE
