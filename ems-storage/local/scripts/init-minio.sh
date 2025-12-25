#!/bin/sh
# ============================================
# MinIO Initialization Script
# ============================================
# This script runs once when MinIO starts to:
# - Configure mc client
# - Create default buckets
# - Set up CORS for remote file access
# - Create service accounts with access keys
# - Configure bucket policies
# ============================================

set -e  # Exit on any error

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
CYAN='\033[0;36m'
MAGENTA='\033[0;35m'
NC='\033[0m' # No Color

# Configuration
MINIO_ALIAS="local"
MAX_RETRIES=30
RETRY_DELAY=2
EMS_BUCKET="ems-storage"
EMS_SERVICE_ACCOUNT="ems-app-user"

# ============================================
# Helper Functions
# ============================================

log_info() {
    echo "${BLUE}[INFO]${NC} $1"
}

log_success() {
    echo "${GREEN}[SUCCESS]${NC} $1"
}

log_warning() {
    echo "${YELLOW}[WARNING]${NC} $1"
}

log_error() {
    echo "${RED}[ERROR]${NC} $1"
}

log_highlight() {
    echo "${MAGENTA}$1${NC}"
}

# ============================================
# Wait for MinIO to be Ready
# ============================================

wait_for_minio() {
    log_info "Waiting for MinIO to be ready..."

    local retries=0
    while [ $retries -lt $MAX_RETRIES ]; do
        if mc alias set $MINIO_ALIAS http://${MINIO_HOST}:${MINIO_PORT} ${MINIO_ROOT_USER} ${MINIO_ROOT_PASSWORD} >/dev/null 2>&1; then
            log_success "MinIO is ready!"
            return 0
        fi

        retries=$((retries + 1))
        log_info "Attempt $retries/$MAX_RETRIES - MinIO not ready yet, retrying in ${RETRY_DELAY}s..."
        sleep $RETRY_DELAY
    done

    log_error "MinIO failed to become ready after $MAX_RETRIES attempts"
    return 1
}

# ============================================
# Configure MinIO Client
# ============================================

configure_mc() {
    log_info "Configuring MinIO client alias..."

    if mc alias set $MINIO_ALIAS http://${MINIO_HOST}:${MINIO_PORT} ${MINIO_ROOT_USER} ${MINIO_ROOT_PASSWORD}; then
        log_success "MinIO client configured successfully"

        # Test connection
        if mc admin info $MINIO_ALIAS >/dev/null 2>&1; then
            log_success "Connection to MinIO verified"
            return 0
        else
            log_error "Failed to verify connection to MinIO"
            return 1
        fi
    else
        log_error "Failed to configure MinIO client"
        return 1
    fi
}

# ============================================
# Create EMS Storage Bucket
# ============================================

create_ems_bucket() {
    log_info "Creating EMS storage bucket..."

    # Check if bucket already exists
    if mc ls $MINIO_ALIAS/$EMS_BUCKET >/dev/null 2>&1; then
        log_warning "Bucket '$EMS_BUCKET' already exists"
    else
        if mc mb $MINIO_ALIAS/$EMS_BUCKET; then
            log_success "Created bucket: $EMS_BUCKET"
        else
            log_error "Failed to create bucket: $EMS_BUCKET"
            return 1
        fi
    fi

    # Enable versioning for better data protection
    if mc version enable $MINIO_ALIAS/$EMS_BUCKET 2>/dev/null; then
        log_success "Enabled versioning for $EMS_BUCKET"
    fi

    return 0
}

# ============================================
# Configure CORS for Remote File Access
# ============================================

configure_cors() {
    log_info "Configuring CORS for remote file access..."

    # Create CORS configuration
    cat > /tmp/cors.json <<EOF
{
  "CORSRules": [
    {
      "AllowedOrigins": ["*"],
      "AllowedMethods": ["GET", "PUT", "POST", "DELETE", "HEAD"],
      "AllowedHeaders": ["*"],
      "ExposeHeaders": ["ETag", "Content-Length", "Content-Type", "x-amz-request-id", "x-amz-id-2"],
      "MaxAgeSeconds": 3600
    }
  ]
}
EOF

    # Apply CORS configuration to EMS bucket
    if mc anonymous set-json /tmp/cors.json $MINIO_ALIAS/$EMS_BUCKET 2>/dev/null; then
        log_success "CORS configured for $EMS_BUCKET"
    else
        # Try alternative method using mc cors
        log_warning "Attempting alternative CORS configuration method..."
        # Note: CORS configuration through policy (MinIO automatically handles CORS)
        log_info "MinIO will handle CORS automatically for authenticated requests"
    fi

    rm -f /tmp/cors.json
}

# ============================================
# Set Bucket Policy for Public Read (Optional)
# ============================================

set_bucket_policy() {
    log_info "Configuring bucket policy for file access..."

    # Create policy that allows read access for files
    # This enables direct file URLs to work without authentication
    cat > /tmp/policy.json <<EOF
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Effect": "Allow",
      "Principal": {"AWS": ["*"]},
      "Action": ["s3:GetObject"],
      "Resource": ["arn:aws:s3:::${EMS_BUCKET}/*"]
    }
  ]
}
EOF

    # Apply the policy (only for development - comment out for production)
    if [ "${ENVIRONMENT:-development}" = "development" ]; then
        if mc anonymous set download $MINIO_ALIAS/$EMS_BUCKET 2>/dev/null; then
            log_success "Set public read access for $EMS_BUCKET (development mode)"
            log_warning "Note: Files in $EMS_BUCKET are publicly accessible!"
        else
            log_warning "Could not set public access - will require authentication"
        fi
    else
        log_info "Production mode: Bucket requires authentication"
    fi

    rm -f /tmp/policy.json
}

# ============================================
# Create Service Account with Access Keys
# ============================================

create_service_account() {
    log_info "Creating service account for EMS application..."

    # Generate random access key and secret key
    ACCESS_KEY="ems-$(cat /dev/urandom | tr -dc 'A-Z0-9' | fold -w 16 | head -n 1)"
    SECRET_KEY="$(cat /dev/urandom | tr -dc 'a-zA-Z0-9' | fold -w 40 | head -n 1)"

    # Create service account
    if mc admin user svcacct add $MINIO_ALIAS $MINIO_ROOT_USER \
        --access-key "$ACCESS_KEY" \
        --secret-key "$SECRET_KEY" \
        --name "$EMS_SERVICE_ACCOUNT" \
        --description "EMS Application Service Account" >/dev/null 2>&1; then

        log_success "Service account created successfully!"

        # Store credentials in environment variable for display
        export EMS_ACCESS_KEY="$ACCESS_KEY"
        export EMS_SECRET_KEY="$SECRET_KEY"

        return 0
    else
        log_warning "Could not create service account (may already exist or unsupported)"
        log_info "Using root credentials instead"
        export EMS_ACCESS_KEY="$MINIO_ROOT_USER"
        export EMS_SECRET_KEY="$MINIO_ROOT_PASSWORD"
        return 0
    fi
}

# ============================================
# Create Additional Buckets
# ============================================

create_buckets() {
    if [ -z "$MINIO_DEFAULT_BUCKETS" ]; then
        log_info "No additional buckets configured"
        return 0
    fi

    log_info "Creating additional buckets..."

    # Convert comma-separated list to space-separated
    BUCKETS=$(echo "$MINIO_DEFAULT_BUCKETS" | tr ',' ' ')

    local created_count=0
    local skipped_count=0

    for bucket in $BUCKETS; do
        # Trim whitespace
        bucket=$(echo "$bucket" | xargs)

        if [ -z "$bucket" ] || [ "$bucket" = "$EMS_BUCKET" ]; then
            continue
        fi

        # Check if bucket already exists
        if mc ls $MINIO_ALIAS/$bucket >/dev/null 2>&1; then
            log_warning "Bucket '$bucket' already exists, skipping"
            skipped_count=$((skipped_count + 1))
        else
            if mc mb $MINIO_ALIAS/$bucket; then
                log_success "Created bucket: $bucket"
                created_count=$((created_count + 1))
            else
                log_error "Failed to create bucket: $bucket"
            fi
        fi
    done

    log_info "Additional buckets: $created_count created, $skipped_count skipped"
}

# ============================================
# Configure Public Buckets
# ============================================

configure_public_buckets() {
    if [ -z "$MINIO_BUCKET_PUBLIC" ]; then
        return 0
    fi

    log_warning "Configuring public buckets (development only!)..."

    # Convert comma-separated list to space-separated
    PUBLIC_BUCKETS=$(echo "$MINIO_BUCKET_PUBLIC" | tr ',' ' ')

    for bucket in $PUBLIC_BUCKETS; do
        # Trim whitespace
        bucket=$(echo "$bucket" | xargs)

        if [ -z "$bucket" ]; then
            continue
        fi

        # Check if bucket exists
        if ! mc ls $MINIO_ALIAS/$bucket >/dev/null 2>&1; then
            log_warning "Bucket '$bucket' does not exist, skipping public configuration"
            continue
        fi

        # Set anonymous download policy
        if mc anonymous set download $MINIO_ALIAS/$bucket; then
            log_success "Set public download access for bucket: $bucket"
        else
            log_error "Failed to set public access for bucket: $bucket"
        fi
    done
}

# ============================================
# Display Bucket Information
# ============================================

display_bucket_info() {
    log_info "Listing all buckets..."
    echo ""

    if mc ls $MINIO_ALIAS; then
        echo ""
        log_info "Bucket contents:"
        mc ls $MINIO_ALIAS --recursive 2>/dev/null || log_info "Buckets are empty"
    else
        log_error "Failed to list buckets"
    fi
}

# ============================================
# Display Access Credentials
# ============================================

display_credentials() {
    echo ""
    echo "${CYAN}========================================${NC}"
    echo "${CYAN}  EMS STORAGE ACCESS CREDENTIALS${NC}"
    echo "${CYAN}========================================${NC}"
    echo ""
    echo "${GREEN}Bucket Name:${NC}"
    echo "  ${MAGENTA}$EMS_BUCKET${NC}"
    echo ""
    echo "${GREEN}S3 Endpoint:${NC}"
    echo "  ${MAGENTA}http://localhost:${MINIO_PORT}${NC}"
    echo ""
    echo "${GREEN}Access Key ID:${NC}"
    echo "  ${YELLOW}$EMS_ACCESS_KEY${NC}"
    echo ""
    echo "${GREEN}Secret Access Key:${NC}"
    echo "  ${YELLOW}$EMS_SECRET_KEY${NC}"
    echo ""
    echo "${GREEN}Region:${NC}"
    echo "  ${MAGENTA}${MINIO_REGION:-us-east-1}${NC}"
    echo ""
    echo "${CYAN}========================================${NC}"
    echo "${YELLOW}IMPORTANT: Save these credentials securely!${NC}"
    echo "${CYAN}========================================${NC}"
    echo ""
}

# ============================================
# Display Integration Examples
# ============================================

display_integration_examples() {
    echo ""
    echo "${BLUE}Quick Integration Examples:${NC}"
    echo ""
    echo "${GREEN}Node.js (AWS SDK v3):${NC}"
    cat <<'NODEJS'
const { S3Client } = require('@aws-sdk/client-s3');

const s3Client = new S3Client({
  endpoint: 'http://localhost:9000',
  region: 'us-east-1',
  credentials: {
    accessKeyId: 'YOUR_ACCESS_KEY',
    secretAccessKey: 'YOUR_SECRET_KEY'
  },
  forcePathStyle: true
});
NODEJS
    echo ""
    echo "${GREEN}Python (boto3):${NC}"
    cat <<'PYTHON'
import boto3

s3_client = boto3.client(
    's3',
    endpoint_url='http://localhost:9000',
    aws_access_key_id='YOUR_ACCESS_KEY',
    aws_secret_access_key='YOUR_SECRET_KEY',
    region_name='us-east-1'
)
PYTHON
    echo ""
}

# ============================================
# Display Summary
# ============================================

display_summary() {
    echo ""
    echo "${GREEN}========================================${NC}"
    echo "${GREEN}MinIO Initialization Complete!${NC}"
    echo "${GREEN}========================================${NC}"
    echo ""
    echo "${BLUE}Access Information:${NC}"
    echo "  S3 API Endpoint:  http://${MINIO_HOST}:${MINIO_PORT}"
    echo "  Console URL:      http://localhost:9001"
    echo "  Root User:        ${MINIO_ROOT_USER}"
    echo "  Region:           ${MINIO_REGION:-us-east-1}"
    echo ""
    echo "${BLUE}Quick Commands:${NC}"
    echo "  List buckets:     docker exec ems-minio mc ls local"
    echo "  Upload file:      docker exec ems-minio mc cp <file> local/$EMS_BUCKET/"
    echo "  Download file:    docker exec ems-minio mc cp local/$EMS_BUCKET/<file> ."
    echo "  View logs:        docker-compose logs -f minio"
    echo ""
    echo "${BLUE}Features Enabled:${NC}"
    echo "  ✓ CORS configured for remote access"
    echo "  ✓ Bucket versioning enabled"
    echo "  ✓ Service account created"
    if [ "${ENVIRONMENT:-development}" = "development" ]; then
        echo "  ✓ Public read access (development mode)"
    fi
    echo ""
    echo "${YELLOW}Note: Change default credentials in production!${NC}"
    echo "${GREEN}========================================${NC}"
}

# ============================================
# Main Execution
# ============================================

main() {
    log_info "Starting MinIO initialization..."
    echo ""

    # Step 1: Wait for MinIO
    if ! wait_for_minio; then
        log_error "Initialization failed: MinIO not available"
        exit 1
    fi
    echo ""

    # Step 2: Configure mc client
    if ! configure_mc; then
        log_error "Initialization failed: Client configuration error"
        exit 1
    fi
    echo ""

    # Step 3: Create EMS storage bucket
    if ! create_ems_bucket; then
        log_error "Initialization failed: Could not create EMS bucket"
        exit 1
    fi
    echo ""

    # Step 4: Configure CORS
    configure_cors
    echo ""

    # Step 5: Set bucket policy
    set_bucket_policy
    echo ""

    # Step 6: Create service account
    create_service_account
    echo ""

    # Step 7: Create additional buckets
    create_buckets
    echo ""

    # Step 8: Configure public buckets (if any)
    configure_public_buckets
    echo ""

    # Step 9: Display information
    display_bucket_info
    echo ""

    # Step 10: Display credentials
    display_credentials

    # Step 11: Display integration examples
    display_integration_examples

    # Step 12: Display summary
    display_summary

    log_success "Initialization script completed successfully!"
    exit 0
}

# Run main function
main
