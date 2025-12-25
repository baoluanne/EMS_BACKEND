# EMS v1 PostgreSQL Database

Single-node PostgreSQL 14 with automated encrypted backups, health monitoring, and Discord notifications.

**Quick Status:**
- PostgreSQL 14.13-alpine (single node)
- pgBackRest 2.56.0 (encrypted backups)
- Automated scheduling (daily incremental, weekly full)
- Container-based deployment

---

## Quick Start

### 1. Configure Environment

```bash
cd ems_v1
cp .env.example .env
# Edit .env with your passwords and Discord webhook
```

### 2. Deploy

```bash
docker compose up -d
```

### 3. Initialize Backups

```bash
# Create backup stanza
docker exec ems-pgbackrest pgbackrest --stanza=main stanza-create

# Run first backup
docker exec ems-pgbackrest pgbackrest --stanza=main --type=full --no-archive-check backup
```

### 4. Verify

```bash
./scripts/verify-backups.sh
```

---

## Architecture

```
Application → PostgreSQL (Port 5433)
                  ↓
              pgBackRest (Automated Backups)
                  ↓
            Backup Scheduler (Cron)
```

**Components:**
- `ems-postgres-master` - PostgreSQL 14.13
- `ems-pgbackrest` - Backup management (woblerr/pgbackrest:2.56.0-alpine)
- `ems-backup-scheduler` - Cron scheduler for automated backups

---

## Connection

**Local:**
```bash
Host: localhost
Port: 5433
User: postgres
Password: (from .env)
Database: postgres
```

**Connection String:**
```
postgresql://postgres:PASSWORD@localhost:5433/postgres
```

**Test Connection:**
```bash
docker exec ems-postgres-master psql -U postgres -c "SELECT version();"
```

---

## Backup System

### Automated Schedule

- **Daily 2:00 AM** - Incremental backup
- **Sunday 3:00 AM** - Full backup
- **Retention:** 4 full backups

### Manual Backups

```bash
# Full backup
docker exec ems-pgbackrest pgbackrest --stanza=main --type=full --no-archive-check backup

# Incremental backup
docker exec ems-pgbackrest pgbackrest --stanza=main --type=incr --no-archive-check backup

# Using script (supports both 'incr' and 'incremental')
./scripts/backup.sh full
./scripts/backup.sh incremental
```

### Verify Backups

```bash
# Quick info
docker exec ems-pgbackrest pgbackrest --stanza=main info

# Detailed verification
./scripts/verify-backups.sh

# Verify integrity
docker exec ems-pgbackrest pgbackrest --stanza=main verify
```

**Example Output:**
```
stanza: main
    status: ok
    cipher: aes-256-cbc

    full backup: 20251009-152311F
        database size: 25.3MB → backup size: 4.1MB (84% compression)

    incr backup: 20251009-152311F_20251009-152401I
        changed: 8.3KB → 480B
```

### Backup Locations

```bash
# View backup files
docker exec ems-pgbackrest ls -lh /backup/backup/main/

# Check storage usage
docker system df -v | grep ems_v1

# Backup volume location
docker volume inspect ems_v1_postgres-backups --format '{{.Mountpoint}}'
```

### Restore from Backup

⚠️ **WARNING:** Stops database and replaces all data!

```bash
# Stop PostgreSQL
docker compose stop postgres-master

# Restore to latest
docker exec ems-pgbackrest pgbackrest --stanza=main --delta restore

# Start PostgreSQL
docker compose start postgres-master

# Verify
docker exec ems-postgres-master psql -U postgres -c "SELECT version();"
```

---

## Monitoring

### Health Check

```bash
./scripts/health-check.sh
```

**Checks:**
1. Database status & version
2. Backup system (stanza, encryption, age, count)
3. Storage (database, backups, host disk)
4. Database connections
5. Database statistics (size, count, uptime)
6. Container health (all 3 containers)

### Backup Verification Script

```bash
./scripts/verify-backups.sh
```

**Automated checks:**
- Stanza status & encryption
- Backup inventory (full/incr/diff)
- Backup age (warns >48h, critical >72h)
- Size analysis
- Integrity verification
- Storage usage
- Container health

### View Logs

```bash
# PostgreSQL logs
docker logs ems-postgres-master --tail 50

# Backup operations
docker exec ems-pgbackrest tail -50 /var/log/pgbackrest/main-backup.log

# Scheduler logs
docker logs ems-backup-scheduler --tail 50

# Watch backup in progress
docker exec ems-pgbackrest tail -f /var/log/pgbackrest/main-backup.log
```

### Discord Notifications

Configure webhook in `.env`:
```bash
DISCORD_WEBHOOK_URL=https://discord.com/api/webhooks/YOUR_ID/YOUR_TOKEN
```

**Notifications for:**
- ✅ Backup success (green)
- ❌ Backup failure (red)
- ⚠️ Backup age warnings (yellow)
- 🚨 Database down alerts (red)
- ⚠️ High disk usage (yellow/red)

---

## Management Commands

### Container Management

```bash
# Start all services
docker compose up -d

# Stop all services
docker compose stop

# Restart services
docker compose restart

# View status
docker compose ps

# Remove containers (keeps data)
docker compose down

# Remove everything including data (DESTRUCTIVE!)
docker compose down -v
```

### Database Operations

```bash
# Access PostgreSQL shell
docker exec -it ems-postgres-master psql -U postgres

# Run SQL query
docker exec ems-postgres-master psql -U postgres -c "SELECT version();"

# Create database dump
docker exec ems-postgres-master pg_dump -U postgres -d mydb > backup.sql

# Restore from dump
cat backup.sql | docker exec -i ems-postgres-master psql -U postgres -d mydb

# Database size
docker exec ems-postgres-master psql -U postgres -c "
  SELECT pg_database.datname,
         pg_size_pretty(pg_database_size(pg_database.datname))
  FROM pg_database
  ORDER BY pg_database_size(pg_database.datname) DESC;"
```

### Backup Operations

```bash
# List all backups
docker exec ems-pgbackrest pgbackrest --stanza=main info

# Get backup info as JSON
docker exec ems-pgbackrest pgbackrest --stanza=main info --output=json

# Verify specific backup
docker exec ems-pgbackrest pgbackrest --stanza=main --set=20251009-152311F verify

# Manually expire old backups
docker exec ems-pgbackrest pgbackrest --stanza=main expire

# Check backup files
docker exec ems-pgbackrest find /backup/backup/main -type f | head -20
```

---

## Troubleshooting

### Database Won't Start

```bash
# Check logs
docker logs ems-postgres-master

# Check container status
docker ps -a | grep postgres-master

# Restart
docker compose restart postgres-master
```

### Backup Fails

```bash
# Check pgBackRest status
docker exec ems-pgbackrest pgbackrest --stanza=main info

# View logs
docker exec ems-pgbackrest tail -100 /var/log/pgbackrest/main-backup.log

# Check container is running
docker ps | grep pgbackrest

# Restart if needed
docker compose restart pgbackrest

# Recreate stanza if corrupted
docker exec ems-pgbackrest pgbackrest --stanza=main stanza-delete --force
docker exec ems-pgbackrest pgbackrest --stanza=main stanza-create
```

### Connection Refused

```bash
# Check container
docker ps | grep postgres-master

# Check port mapping
docker port ems-postgres-master

# Test internal connection
docker exec ems-postgres-master psql -U postgres -c "SELECT 1;"

# Check network
docker network inspect ems_v1_pgnet
```

### High Disk Usage

```bash
# Check sizes
docker system df -v | grep ems_v1

# Clean old backups
docker exec ems-pgbackrest pgbackrest --stanza=main expire

# Reduce retention (edit .env then restart)
BACKUP_RETENTION_FULL=2
```

---

## Known Issues & Solutions

### ❌ Issue: pgBackRest Image Not Found

**Problem:** Original `pgbackrest/pgbackrest:2.53.1` doesn't exist
**Solution:** Now using `woblerr/pgbackrest:2.56.0-alpine` (community image)

### ❌ Issue: Container Restart Loop

**Problem:** Container exits after starting
**Solution:** Added `command: ["tail", "-f", "/dev/null"]` to keep container running

### ❌ Issue: Archive Command Errors

**Problem:** `archive_command '/bin/true' must contain pgbackrest`
**Solution:** All backups use `--no-archive-check` flag
**Limitation:** No Point-in-Time Recovery (PITR) without full WAL archiving

### ❌ Issue: Authentication Failures

**Problem:** Peer authentication failed
**Solution:**
- Container runs as postgres user (UID 70)
- pg_hba.conf uses `trust` for local connections
- Shared socket volume for inter-container communication

### ❌ Issue: Backup Type Errors

**Problem:** `'incremental' is not allowed`
**Solution:** Script auto-converts: `incremental`→`incr`, `differential`→`diff`

---

## Configuration

### Key Files

**docker-compose.yml:**
- Image: `woblerr/pgbackrest:2.56.0-alpine`
- User: `70:70` (postgres)
- Socket: `postgres-socket:/var/run/postgresql`
- Command: `tail -f /dev/null` (keep alive)
- Cron: Uses `incr` not `incremental`

**postgres.conf:**
```conf
wal_level = replica
archive_mode = on
archive_command = '/bin/true'  # Simplified for basic backups
```

**pg_hba.conf:**
```conf
local all all trust  # Changed from 'peer'
```

**pgbackrest.conf:**
```ini
[main]
pg1-path=/var/lib/postgresql/data
pg1-socket-path=/var/run/postgresql
pg1-user=postgres
```

### Environment Variables

Edit `.env`:
```bash
# Database
POSTGRES_MASTER_USER=postgres
POSTGRES_MASTER_PASSWORD=YourSecurePassword123
POSTGRES_MASTER_PORT=5433

# Backup
BACKUP_RETENTION_FULL=4
BACKUP_ENCRYPTION_KEY=YourRandomKey

# Notifications
DISCORD_WEBHOOK_URL=https://discord.com/api/webhooks/...
```

---

## Security

**Encryption:**
- ✅ AES-256-CBC for all backups
- ✅ Configurable encryption key

**Authentication:**
- ⚠️ Local connections use `trust` (no password for Unix socket)
- ✅ Network connections require password (md5)
- 🔒 Restrict pg_hba.conf to specific IPs in production

**Best Practices:**
1. Change default passwords
2. Rotate encryption keys quarterly
3. Restrict network access to port 5433
4. Enable SSL/TLS for remote connections
5. Keep Docker images updated
6. Regular security audits

---

## Performance Tuning

**For Read-Heavy Workloads:**
```conf
shared_buffers = 256MB
effective_cache_size = 1GB
```

**For Write-Heavy Workloads:**
```conf
wal_buffers = 16MB
checkpoint_completion_target = 0.9
```

Apply changes:
```bash
# Edit postgres/master/postgres.conf
docker compose restart postgres-master
```

---

## Maintenance Schedule

### Daily
- ✅ Review Discord backup notifications
- ✅ Check backup age < 24 hours

### Weekly
- ✅ Run `./scripts/verify-backups.sh`
- ✅ Review disk usage
- ✅ Verify full backup completed

### Monthly
- ✅ Test backup restoration
- ✅ Review logs for errors
- ✅ Optimize database (VACUUM, ANALYZE)
- ✅ Update Docker images

### Quarterly
- ✅ Full disaster recovery drill
- ✅ Rotate encryption keys
- ✅ Review security settings
- ✅ Update documentation

---

## Upgrade to EMS v2

For high-availability with automatic failover:

1. See `../ems_v2/README.md`
2. Create backup: `docker exec ems-postgres-master pg_dumpall -U postgres > v1_backup.sql`
3. Follow migration guide

**EMS v2 Benefits:**
- Automatic failover (Patroni)
- Read replicas
- PostgreSQL 16
- HAProxy load balancing
- Enhanced monitoring

---

## File Structure

```
ems_v1/
├── .env                        # Configuration (git-ignored)
├── .env.example               # Template
├── docker-compose.yml         # Container definitions
├── postgres/
│   └── master/
│       ├── postgres.conf      # PostgreSQL config
│       └── pg_hba.conf       # Authentication
├── pgbackrest/
│   └── pgbackrest.conf       # Backup config
├── scripts/
│   ├── backup.sh             # Manual/cron backups
│   ├── health-check.sh       # System health
│   └── verify-backups.sh     # Backup verification
├── README.md                  # This file
└── BACKUP_VERIFICATION_GUIDE.md  # Detailed guide
```

---

## Quick Reference

```bash
# Deploy
docker compose up -d

# Health check
./scripts/verify-backups.sh

# Manual backup
docker exec ems-pgbackrest pgbackrest --stanza=main --type=full --no-archive-check backup

# View backups
docker exec ems-pgbackrest pgbackrest --stanza=main info

# Database shell
docker exec -it ems-postgres-master psql -U postgres

# View logs
docker logs ems-postgres-master --tail 50

# Restart
docker compose restart

# Stop
docker compose stop

# Check status
docker compose ps
```

---

## Support Resources

- **PostgreSQL 14:** https://www.postgresql.org/docs/14/
- **pgBackRest:** https://pgbackrest.org/
- **Docker Compose:** https://docs.docker.com/compose/

---

## Changelog

### 2025-10-09 - Major Update
- Fixed pgBackRest image (woblerr/pgbackrest:2.56.0-alpine)
- Simplified archive mode (`--no-archive-check`)
- Fixed authentication (trust for local, shared socket)
- Container runs as postgres user (UID 70)
- Added comprehensive verification scripts
- Updated all documentation
- Fixed all docker-compose → docker compose commands

### 2025-10-08 - Initial Release
- PostgreSQL 14.13-alpine setup
- pgBackRest automation
- Discord notifications

---

**Version:** 1.1
**Last Updated:** 2025-10-09
**PostgreSQL:** 14.13-alpine
**pgBackRest:** 2.56.0-alpine
**Status:** Production Ready ✅
