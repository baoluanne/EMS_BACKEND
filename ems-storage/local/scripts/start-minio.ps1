<#
.SYNOPSIS
    MinIO S3-Compatible Storage Startup Script for Windows

.DESCRIPTION
    This PowerShell script starts MinIO services using Docker Compose,
    verifies the setup, and displays access credentials.

.NOTES
    Version:        1.0.0
    Author:         EMS DevOps Team
    Prerequisites:  Docker Desktop, Docker Compose
#>

#Requires -Version 5.1

# Script configuration
$ErrorActionPreference = "Stop"
$ProgressPreference = "SilentlyContinue"

# Colors for output
function Write-ColorOutput {
    param(
        [string]$Message,
        [string]$Color = "White"
    )
    Write-Host $Message -ForegroundColor $Color
}

function Write-Header {
    param([string]$Title)
    Write-Host ""
    Write-ColorOutput "========================================" "Cyan"
    Write-ColorOutput $Title "Cyan"
    Write-ColorOutput "========================================" "Cyan"
    Write-Host ""
}

function Write-Success {
    param([string]$Message)
    Write-ColorOutput "[SUCCESS] $Message" "Green"
}

function Write-Info {
    param([string]$Message)
    Write-ColorOutput "[INFO] $Message" "Blue"
}

function Write-Warning {
    param([string]$Message)
    Write-ColorOutput "[WARNING] $Message" "Yellow"
}

function Write-Error {
    param([string]$Message)
    Write-ColorOutput "[ERROR] $Message" "Red"
}

# Check prerequisites
function Test-Prerequisites {
    Write-Info "Checking prerequisites..."

    # Check Docker
    try {
        $dockerVersion = docker --version
        Write-Success "Docker found: $dockerVersion"
    }
    catch {
        Write-Error "Docker is not installed or not in PATH"
        Write-Info "Please install Docker Desktop from: https://www.docker.com/products/docker-desktop"
        exit 1
    }

    # Check Docker Compose
    try {
        $composeVersion = docker-compose --version
        Write-Success "Docker Compose found: $composeVersion"
    }
    catch {
        Write-Error "Docker Compose is not installed or not in PATH"
        exit 1
    }

    # Check if Docker is running
    try {
        docker ps | Out-Null
        Write-Success "Docker daemon is running"
    }
    catch {
        Write-Error "Docker daemon is not running"
        Write-Info "Please start Docker Desktop"
        exit 1
    }

    Write-Host ""
}

# Check and create .env file
function Test-EnvFile {
    Write-Info "Checking environment configuration..."

    if (-not (Test-Path ".env")) {
        Write-Warning ".env file not found"

        if (Test-Path ".env.example") {
            Write-Info "Copying .env.example to .env..."
            Copy-Item ".env.example" ".env"
            Write-Success ".env file created"
            Write-Warning "IMPORTANT: Please update credentials in .env file!"
            Write-Host ""
            Write-ColorOutput "Edit the .env file and change:" "Yellow"
            Write-ColorOutput "  - MINIO_ROOT_USER" "Yellow"
            Write-ColorOutput "  - MINIO_ROOT_PASSWORD" "Yellow"
            Write-Host ""

            $response = Read-Host "Do you want to continue with default credentials? (y/N)"
            if ($response -ne "y" -and $response -ne "Y") {
                Write-Info "Please edit .env file and run this script again"
                exit 0
            }
        }
        else {
            Write-Error ".env.example file not found"
            exit 1
        }
    }
    else {
        Write-Success ".env file found"
    }

    Write-Host ""
}

# Stop existing containers
function Stop-ExistingContainers {
    Write-Info "Checking for existing MinIO containers..."

    $existingContainers = docker ps -a --filter "name=ems-minio" --format "{{.Names}}"

    if ($existingContainers) {
        Write-Warning "Found existing MinIO containers"
        Write-Info "Stopping and removing existing containers..."
        docker-compose down
        Write-Success "Existing containers removed"
    }
    else {
        Write-Info "No existing containers found"
    }

    Write-Host ""
}

# Pull latest images
function Update-Images {
    Write-Info "Pulling MinIO Docker images..."

    try {
        docker-compose pull
        Write-Success "Docker images updated"
    }
    catch {
        Write-Warning "Failed to pull images, will use cached versions"
    }

    Write-Host ""
}

# Start MinIO services
function Start-MinioServices {
    Write-Header "Starting MinIO Services"

    try {
        Write-Info "Starting containers in detached mode..."
        docker-compose up -d
        Write-Success "MinIO services started"
    }
    catch {
        Write-Error "Failed to start MinIO services"
        Write-Info "Error details: $_"
        exit 1
    }

    Write-Host ""
}

# Wait for services to be healthy
function Wait-ForHealthy {
    Write-Info "Waiting for MinIO to become healthy..."

    $maxAttempts = 30
    $attempt = 0
    $healthy = $false

    while ($attempt -lt $maxAttempts -and -not $healthy) {
        $attempt++
        Start-Sleep -Seconds 2

        try {
            $healthStatus = docker inspect --format='{{.State.Health.Status}}' ems-minio 2>$null

            if ($healthStatus -eq "healthy") {
                $healthy = $true
                Write-Success "MinIO is healthy and ready!"
            }
            else {
                Write-Host "." -NoNewline
            }
        }
        catch {
            Write-Host "." -NoNewline
        }
    }

    Write-Host ""

    if (-not $healthy) {
        Write-Warning "MinIO health check timeout (this may be normal on first start)"
        Write-Info "Checking if MinIO is responding..."

        Start-Sleep -Seconds 5

        try {
            $response = Invoke-WebRequest -Uri "http://localhost:9000/minio/health/live" -TimeoutSec 5 -UseBasicParsing
            if ($response.StatusCode -eq 200) {
                Write-Success "MinIO is responding to requests"
                $healthy = $true
            }
        }
        catch {
            Write-Error "MinIO is not responding"
            Write-Info "Check logs with: docker-compose logs minio"
        }
    }

    Write-Host ""
    return $healthy
}

# Display service information
function Show-ServiceInfo {
    Write-Header "MinIO Services Information"

    # Load environment variables
    $envVars = @{}
    Get-Content ".env" | ForEach-Object {
        if ($_ -match '^([^#][^=]+)=(.*)$') {
            $envVars[$matches[1].Trim()] = $matches[2].Trim()
        }
    }

    $apiPort = if ($envVars.ContainsKey("MINIO_API_PORT")) { $envVars["MINIO_API_PORT"] } else { "9000" }
    $consolePort = if ($envVars.ContainsKey("MINIO_CONSOLE_PORT")) { $envVars["MINIO_CONSOLE_PORT"] } else { "9001" }
    $rootUser = if ($envVars.ContainsKey("MINIO_ROOT_USER")) { $envVars["MINIO_ROOT_USER"] } else { "admin" }

    Write-ColorOutput "Access URLs:" "Cyan"
    Write-Host "  S3 API Endpoint:  " -NoNewline
    Write-ColorOutput "http://localhost:$apiPort" "Green"
    Write-Host "  Web Console:      " -NoNewline
    Write-ColorOutput "http://localhost:$consolePort" "Green"
    Write-Host ""

    Write-ColorOutput "Root Credentials:" "Cyan"
    Write-Host "  Username:         " -NoNewline
    Write-ColorOutput $rootUser "Yellow"
    Write-Host "  Password:         " -NoNewline
    Write-ColorOutput "(see .env file)" "Yellow"
    Write-Host ""

    Write-ColorOutput "Container Status:" "Cyan"
    docker-compose ps

    Write-Host ""
}

# Wait for initialization to complete
function Wait-ForInitialization {
    Write-Info "Waiting for bucket initialization..."

    Start-Sleep -Seconds 3

    $maxWait = 60
    $waited = 0
    $initialized = $false

    while ($waited -lt $maxWait -and -not $initialized) {
        $clientStatus = docker ps --filter "name=ems-minio-client" --format "{{.Status}}"

        if ($clientStatus -match "Exited") {
            $exitCode = docker inspect --format='{{.State.ExitCode}}' ems-minio-client 2>$null

            if ($exitCode -eq "0") {
                $initialized = $true
                Write-Success "Bucket initialization completed"
            }
            else {
                Write-Warning "Initialization exited with code $exitCode"
                break
            }
        }
        elseif (-not $clientStatus) {
            Write-Warning "Initialization container not found"
            break
        }
        else {
            Write-Host "." -NoNewline
            Start-Sleep -Seconds 2
            $waited += 2
        }
    }

    Write-Host ""

    if ($initialized) {
        Write-Info "Viewing initialization logs..."
        Write-Host ""
        docker-compose logs minio-client
        Write-Host ""
    }
}

# Display quick commands
function Show-QuickCommands {
    Write-Header "Quick Commands"

    Write-ColorOutput "Manage Services:" "Cyan"
    Write-Host "  View logs:        " -NoNewline
    Write-ColorOutput "docker-compose logs -f" "White"
    Write-Host "  Stop services:    " -NoNewline
    Write-ColorOutput "docker-compose stop" "White"
    Write-Host "  Restart services: " -NoNewline
    Write-ColorOutput "docker-compose restart" "White"
    Write-Host "  Remove services:  " -NoNewline
    Write-ColorOutput "docker-compose down" "White"
    Write-Host ""

    Write-ColorOutput "MinIO Client Commands:" "Cyan"
    Write-Host "  List buckets:     " -NoNewline
    Write-ColorOutput "docker exec ems-minio mc ls local" "White"
    Write-Host "  Create bucket:    " -NoNewline
    Write-ColorOutput "docker exec ems-minio mc mb local/bucket-name" "White"
    Write-Host "  Upload file:      " -NoNewline
    Write-ColorOutput "docker exec ems-minio mc cp file.txt local/bucket/" "White"
    Write-Host ""
}

# Main execution
function Main {
    Clear-Host

    Write-Header "MinIO S3 Storage - Startup Script"

    # Change to minio-storage directory (parent of scripts folder)
    $scriptPath = if ($PSScriptRoot) {
        $PSScriptRoot
    }
    elseif ($MyInvocation.MyCommand.Path) {
        Split-Path -Parent $MyInvocation.MyCommand.Path
    }
    else {
        $PWD.Path
    }

    # Navigate to parent directory where docker-compose.yml and .env are located
    if ($scriptPath) {
        $minioStoragePath = Split-Path -Parent $scriptPath
        Set-Location $minioStoragePath
        Write-Info "Working directory: $minioStoragePath"
    }

    # Run setup steps
    Test-Prerequisites
    Test-EnvFile
    Stop-ExistingContainers
    Update-Images
    Start-MinioServices

    $healthy = Wait-ForHealthy

    if ($healthy) {
        Show-ServiceInfo
        Wait-ForInitialization
        Show-QuickCommands

        Write-Success "MinIO is ready to use!"
        Write-Host ""
        Write-ColorOutput "Press Ctrl+C to view logs, or close this window" "Gray"
        Write-Host ""

        # Follow logs
        docker-compose logs -f
    }
    else {
        Write-Error "Failed to start MinIO properly"
        Write-Info "Check logs with: docker-compose logs"
        exit 1
    }
}

# Run main function
Main
