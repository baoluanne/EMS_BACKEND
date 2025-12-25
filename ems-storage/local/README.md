# MinIO S3-Compatible Storage Setup

This directory contains a production-ready MinIO setup for local development and testing. MinIO provides S3-compatible object storage that can be deployed anywhere.

## Table of Contents

- [Quick Start](#quick-start)
- [Architecture](#architecture)
- [Configuration](#configuration)
- [Usage](#usage)
- [Management](#management)
- [Integration Examples](#integration-examples)
- [Troubleshooting](#troubleshooting)
- [Security Best Practices](#security-best-practices)

## Quick Start

### Prerequisites

- Docker Engine 20.10+ and Docker Compose 2.0+
- At least 2GB free disk space
- Ports 9000 and 9001 available

### Windows PowerShell (Recommended)

**Easy One-Command Startup:**

```powershell
.\start-minio.ps1
```

The PowerShell script will:
- Check prerequisites (Docker, Docker Compose)
- Create `.env` file from template if needed
- Start MinIO services
- Display access credentials and integration examples
- Show initialization logs automatically

**Features:**
- Colored output for better readability
- Automated health checks
- Credential display with generated access keys
- Interactive prompts for safety

### Manual Setup (All Platforms)

1. **Copy environment configuration:**
   ```bash
   cd minio-storage
   cp .env.example .env
   ```

2. **Edit `.env` file with your credentials:**
   ```bash
   # Windows
   notepad .env

   # Linux/Mac
   nano .env
   ```

   **IMPORTANT:** Change the default credentials:
   ```env
   MINIO_ROOT_USER=your_admin_username
   MINIO_ROOT_PASSWORD=your_secure_password_min8chars
   ```

3. **Start MinIO services:**
   ```bash
   docker-compose up -d
   ```

4. **Verify services are running:**
   ```bash
   docker-compose ps
   ```

5. **View initialization logs to get access credentials:**
   ```bash
   docker-compose logs minio-client
   ```

   Look for the "EMS STORAGE ACCESS CREDENTIALS" section with:
   - Bucket name: `ems-storage`
   - Access Key ID
   - Secret Access Key

6. **Access MinIO Console:**
   - Open browser: http://localhost:9001
   - Login with credentials from `.env` file

## Architecture

### Components

```
┌─────────────────────────────────────────────────┐
│               Client Applications                │
└────────────┬────────────────────┬────────────────┘
             │                    │
        S3 API (9000)      Console (9001)
             │                    │
┌────────────┴────────────────────┴────────────────┐
│                  MinIO Server                     │
│  ┌──────────────────────────────────────────┐   │
│  │         Persistent Volume Storage         │   │
│  │            /data → minio_data             │   │
│  └──────────────────────────────────────────┘   │
└──────────────────────────────────────────────────┘
             │
┌────────────┴────────────────────────────────────┐
│           MinIO Client (mc) - Init              │
│  • Creates default buckets                      │
│  • Configures policies                          │
│  • Sets up access keys                          │
└─────────────────────────────────────────────────┘
```

### Services

1. **minio** - Main storage server
   - S3 API endpoint: `http://localhost:9000`
   - Web Console: `http://localhost:9001`
   - Persistent data: Docker volume `minio_data`

2. **minio-client** - Initialization service
   - Runs once on startup
   - Creates default buckets
   - Configures initial settings

## Configuration

### Environment Variables

All configuration is managed through the `.env` file. Key sections:

#### Required Credentials
```env
MINIO_ROOT_USER=admin              # Admin username
MINIO_ROOT_PASSWORD=changeme123    # Admin password (min 8 chars)
```

#### Network Configuration
```env
MINIO_API_PORT=9000               # S3 API port
MINIO_CONSOLE_PORT=9001           # Web console port
MINIO_DOMAIN=localhost            # Domain name
```

#### Bucket Configuration
```env
# Buckets to create automatically on startup
MINIO_DEFAULT_BUCKETS=uploads,backups,documents

# Public buckets (development only!)
MINIO_BUCKET_PUBLIC=
```

#### Performance Tuning
```env
MINIO_API_REQUESTS_MAX=1000       # Max concurrent requests
MINIO_COMPRESSION_ENABLE=on       # Enable compression
```

### Storage Layout

```
minio-storage/
├── docker-compose.yml           # Main orchestration file
├── .env                        # Configuration (create from .env.example)
├── .env.example                # Configuration template
├── README.md                   # This file
├── scripts/
│   └── init-minio.sh          # Initialization script
└── data/                      # Local data mount (optional)
```

## Usage

### Starting Services

```bash
# Start all services
docker-compose up -d

# Start with logs visible
docker-compose up

# Start specific service
docker-compose up -d minio
```

### Stopping Services

```bash
# Stop all services (preserves data)
docker-compose stop

# Stop and remove containers (preserves data)
docker-compose down

# Stop and remove everything including volumes (DELETES ALL DATA!)
docker-compose down -v
```

### Viewing Logs

```bash
# All services
docker-compose logs -f

# Specific service
docker-compose logs -f minio

# Last 100 lines
docker-compose logs --tail=100 minio
```

### Health Checks

```bash
# Check service status
docker-compose ps

# Check MinIO health
docker exec ems-minio mc ready local

# Check disk usage
docker exec ems-minio mc admin info local
```

## Management

### Web Console

Access the MinIO Console at http://localhost:9001

Features:
- Browse and manage buckets
- Upload/download files
- User and access key management
- Monitoring and metrics
- Configuration management

### MinIO Client (mc) Commands

The MinIO Client is pre-installed in the containers:

```bash
# Alias for easier commands
alias mc='docker exec ems-minio mc'

# List buckets
mc ls local

# Create bucket
mc mb local/new-bucket

# Upload file
mc cp /path/to/file local/bucket-name/

# Download file
mc cp local/bucket-name/file.txt /path/to/destination/

# Remove file
mc rm local/bucket-name/file.txt

# Create access key
mc admin user add local newuser newpassword

# List users
mc admin user list local

# Set bucket policy (public read)
mc anonymous set download local/bucket-name

# View bucket policy
mc anonymous get local/bucket-name
```

### Bucket Management

#### Creating Buckets

Via Web Console:
1. Navigate to http://localhost:9001
2. Click "Buckets" → "Create Bucket"
3. Enter bucket name
4. Configure versioning and encryption as needed

Via CLI:
```bash
docker exec ems-minio mc mb local/my-new-bucket
```

#### Setting Bucket Policies

Make bucket public (download only):
```bash
docker exec ems-minio mc anonymous set download local/public-bucket
```

Make bucket public (upload and download):
```bash
docker exec ems-minio mc anonymous set public local/public-bucket
```

Remove public access:
```bash
docker exec ems-minio mc anonymous set none local/bucket-name
```

### User and Access Key Management

#### Create Service Account

```bash
# Create new access key
docker exec ems-minio mc admin user svcacct add \
  --access-key "MYACCESSKEY" \
  --secret-key "mysecretkey123456" \
  local admin
```

#### List Service Accounts

```bash
docker exec ems-minio mc admin user svcacct ls local admin
```

## Integration Examples

### Node.js / JavaScript

```javascript
const { S3Client, PutObjectCommand, GetObjectCommand } = require('@aws-sdk/client-s3');

const s3Client = new S3Client({
  endpoint: 'http://localhost:9000',
  region: 'us-east-1',
  credentials: {
    accessKeyId: 'admin',
    secretAccessKey: 'changeme123'
  },
  forcePathStyle: true  // Required for MinIO
});

// Upload file
async function uploadFile(bucket, key, body) {
  const command = new PutObjectCommand({
    Bucket: bucket,
    Key: key,
    Body: body
  });

  return await s3Client.send(command);
}

// Download file
async function downloadFile(bucket, key) {
  const command = new GetObjectCommand({
    Bucket: bucket,
    Key: key
  });

  return await s3Client.send(command);
}
```

### Python

```python
import boto3
from botocore.client import Config

# Initialize MinIO client
s3_client = boto3.client(
    's3',
    endpoint_url='http://localhost:9000',
    aws_access_key_id='admin',
    aws_secret_access_key='changeme123',
    config=Config(signature_version='s3v4'),
    region_name='us-east-1'
)

# Upload file
def upload_file(bucket, key, file_path):
    s3_client.upload_file(file_path, bucket, key)

# Download file
def download_file(bucket, key, file_path):
    s3_client.download_file(bucket, key, file_path)

# List objects
def list_objects(bucket):
    response = s3_client.list_objects_v2(Bucket=bucket)
    return response.get('Contents', [])
```

### .NET / C#

```csharp
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;

var config = new AmazonS3Config
{
    ServiceURL = "http://localhost:9000",
    ForcePathStyle = true
};

var credentials = new BasicAWSCredentials("admin", "changeme123");
var s3Client = new AmazonS3Client(credentials, config);

// Upload file
async Task UploadFileAsync(string bucket, string key, string filePath)
{
    var request = new PutObjectRequest
    {
        BucketName = bucket,
        Key = key,
        FilePath = filePath
    };

    await s3Client.PutObjectAsync(request);
}

// Download file
async Task DownloadFileAsync(string bucket, string key, string filePath)
{
    var request = new GetObjectRequest
    {
        BucketName = bucket,
        Key = key
    };

    using var response = await s3Client.GetObjectAsync(request);
    await response.WriteResponseStreamToFileAsync(filePath, false, CancellationToken.None);
}
```

### Java

```java
import software.amazon.awssdk.auth.credentials.AwsBasicCredentials;
import software.amazon.awssdk.auth.credentials.StaticCredentialsProvider;
import software.amazon.awssdk.regions.Region;
import software.amazon.awssdk.services.s3.S3Client;
import software.amazon.awssdk.services.s3.model.PutObjectRequest;
import software.amazon.awssdk.services.s3.model.GetObjectRequest;

import java.net.URI;
import java.nio.file.Paths;

public class MinIOExample {
    public static void main(String[] args) {
        AwsBasicCredentials credentials = AwsBasicCredentials.create("admin", "changeme123");

        S3Client s3Client = S3Client.builder()
            .endpointOverride(URI.create("http://localhost:9000"))
            .credentialsProvider(StaticCredentialsProvider.create(credentials))
            .region(Region.US_EAST_1)
            .forcePathStyle(true)
            .build();

        // Upload file
        s3Client.putObject(
            PutObjectRequest.builder()
                .bucket("uploads")
                .key("test.txt")
                .build(),
            Paths.get("/path/to/test.txt")
        );

        // Download file
        s3Client.getObject(
            GetObjectRequest.builder()
                .bucket("uploads")
                .key("test.txt")
                .build(),
            Paths.get("/path/to/download/test.txt")
        );
    }
}
```

## Troubleshooting

### Services Won't Start

**Issue:** Port already in use
```
Error: bind: address already in use
```

**Solution:** Change ports in `.env`:
```env
MINIO_API_PORT=9100
MINIO_CONSOLE_PORT=9101
```

### Cannot Access Console

**Check if service is running:**
```bash
docker-compose ps
```

**Check logs:**
```bash
docker-compose logs minio
```

**Verify port binding:**
```bash
netstat -ano | findstr :9001  # Windows
lsof -i :9001                 # Linux/Mac
```

### Buckets Not Created

**Re-run initialization:**
```bash
docker-compose up minio-client
```

**Check initialization logs:**
```bash
docker-compose logs minio-client
```

### Permission Denied Errors

**Linux/Mac:** Ensure proper permissions on data directory
```bash
chmod -R 755 ./data
```

**Windows:** Run Docker Desktop as Administrator

### Connection Refused from Application

**Verify MinIO is accessible:**
```bash
curl http://localhost:9000/minio/health/live
```

**Check Docker network:**
```bash
docker network inspect minio_minio-net
```

**From other containers:** Use service name instead of localhost:
```
endpoint: http://minio:9000
```

### High Memory Usage

Edit `.env` and add resource limits, then uncomment deployment section in `docker-compose.yml`:
```env
MINIO_MEMORY_LIMIT=1G
MINIO_CPU_LIMIT=1.0
```

## Security Best Practices

### Development Environment

1. **Change default credentials** in `.env`
2. **Don't commit** `.env` file to version control
3. **Use strong passwords** (minimum 8 characters)
4. **Keep buckets private** unless specifically needed

### Production Considerations

When moving to production:

1. **Enable HTTPS/TLS:**
   - Uncomment nginx service in `docker-compose.yml`
   - Configure SSL certificates
   - Update `MINIO_SERVER_URL` to use `https://`

2. **Secure Credentials:**
   - Use secrets management (AWS Secrets Manager, HashiCorp Vault)
   - Rotate access keys regularly
   - Implement least-privilege access policies

3. **Enable Audit Logging:**
   ```env
   MINIO_AUDIT_WEBHOOK_ENABLE=on
   MINIO_AUDIT_WEBHOOK_ENDPOINT=https://your-logging-service
   ```

4. **Set Resource Limits:**
   - Uncomment deployment section in `docker-compose.yml`
   - Set appropriate CPU and memory limits

5. **Regular Backups:**
   - Implement automated backup strategy
   - Test restore procedures
   - Monitor disk usage

6. **Network Security:**
   - Use internal networks only
   - Implement firewall rules
   - Enable VPN/bastion host access

7. **Monitoring:**
   - Enable Prometheus metrics
   - Set up alerting for disk usage, errors
   - Monitor access patterns

## Additional Resources

- [MinIO Documentation](https://min.io/docs/minio/linux/)
- [MinIO Client Guide](https://min.io/docs/minio/linux/reference/minio-mc.html)
- [S3 API Reference](https://docs.aws.amazon.com/s3/index.html)
- [Docker Compose Reference](https://docs.docker.com/compose/)

## Support

For issues specific to this setup:
1. Check logs: `docker-compose logs`
2. Review troubleshooting section above
3. Consult MinIO documentation

For MinIO issues:
- GitHub: https://github.com/minio/minio/issues
- Community: https://slack.min.io/

---

**Version:** 1.0.0
**Last Updated:** 2024-10-17
**Maintained by:** EMS DevOps Team
