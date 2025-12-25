#!/bin/bash
set -e

# Container Configuration
PGBACKREST_CONTAINER="${PGBACKREST_CONTAINER:-ems-pgbackrest}"

# Convert backup type: incremental -> incr for pgBackRest
BACKUP_TYPE_INPUT=${1:-incremental}
case "$BACKUP_TYPE_INPUT" in
    incremental) BACKUP_TYPE="incr" ;;
    differential) BACKUP_TYPE="diff" ;;
    full) BACKUP_TYPE="full" ;;
    *) BACKUP_TYPE="$BACKUP_TYPE_INPUT" ;;
esac
LOG_FILE="/var/log/pgbackrest-backup.log"
DISCORD_WEBHOOK_URL="${DISCORD_WEBHOOK_URL}"

log() {
    echo "[$(date +'%Y-%m-%d %H:%M:%S')] $1" | tee -a "$LOG_FILE"
}

notify() {
    local message="$1"
    local color="$2"  # Success: 3066993 (green), Error: 15158332 (red), Warning: 16776960 (yellow)

    if [ -n "$DISCORD_WEBHOOK_URL" ]; then
        local timestamp=$(date -u +"%Y-%m-%dT%H:%M:%SZ")
        curl -s -H "Content-Type: application/json" -X POST "${DISCORD_WEBHOOK_URL}" \
            -d "{
                \"embeds\": [{
                    \"title\": \"🗄️ PostgreSQL Backup Notification\",
                    \"description\": \"${message}\",
                    \"color\": ${color},
                    \"timestamp\": \"${timestamp}\",
                    \"footer\": {
                        \"text\": \"EMS v1 Database Backup System\"
                    },
                    \"fields\": [
                        {
                            \"name\": \"Backup Type\",
                            \"value\": \"${BACKUP_TYPE}\",
                            \"inline\": true
                        },
                        {
                            \"name\": \"Server\",
                            \"value\": \"EMS v1 Master\",
                            \"inline\": true
                        }
                    ]
                }]
            }" > /dev/null 2>&1
    fi
}

# Execute backup
log "Starting ${BACKUP_TYPE} backup..."
START_TIME=$(date +%s)

if docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main --type=${BACKUP_TYPE} --no-archive-check backup; then
    END_TIME=$(date +%s)
    DURATION=$((END_TIME - START_TIME))

    # Get backup info
    BACKUP_INFO=$(docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main info --output=json)
    BACKUP_SIZE=$(echo "$BACKUP_INFO" | jq -r '.[0].backup[-1].info.size' || echo "N/A")

    log "✅ Backup completed successfully in ${DURATION}s (Size: ${BACKUP_SIZE})"
    notify "✅ Backup completed successfully!\n\n**Duration:** ${DURATION}s\n**Size:** ${BACKUP_SIZE}" 3066993

else
    log "❌ Backup failed!"
    notify "❌ **BACKUP FAILED**\n\nImmediate attention required!\nCheck logs at: ${LOG_FILE}" 15158332
    exit 1
fi

# Cleanup old backups
docker exec $PGBACKREST_CONTAINER pgbackrest --stanza=main expire

log "Backup process completed"
