# EMS API deployment guide

## Hide your command in history but it will also remove the previous feature of shell
```
set +o history
....
set -o history
```

## DEPLOYMENT GUIDE

### Step 1: build the project to get the production ready artifact
```
cd ./EMS.API
dotnet publish EMS.API.csproj -c Release -f net9.0 -o ./publish
```

### Step 2: turn on VPN and then remote to the production server

| It recommends to you tool that has file upload feature in default as MobaXTerm

### Step 3: create a rollback folder (MUST DO IF NOT YOU WILL REGET LATER)

| **All of the below step require you to run from inside `/root/ems`**

```
mv publish publish_bak
```

### Step 4: create backup database data (MUST DO IF NOT YOU WILL REGET LATER)
### Update the datetime format (YYYYMMDD) to current datetime
```
pg_dump -h localhost -p 5432 -U postgres -W -F p -d EMS > EMS_backup_YYYYMMDD_data.sql
```

### Step 5: upload new artifact (publish folder)

### Step 6: stop the api service
```
systemctl stop ems-api.service
```

### Step 7: clean up the deployment location (to prevent unwanted old code)
```
yes | rm -rf /var/www/ems-api/*
```

### Step 8: copy the build to deployment location
```
yes | cp -rf /root/ems/publish/. /var/www/ems-api/
```

### Step 9: restart the service then verify the staring log of the service
```
systemctl restart ems-api.service
journalctl -u ems-api.service
```

## IN CASE YOU NEED ROLLBACK

### Step 1: stop the api service
```
systemctl stop ems-api.service
```

### Step 2: clean up the deployment location (to prevent unwanted old code)
```
yes | rm -rf /var/www/ems-api/*
```

### Step 3: copy the build to deployment location
```
yes | cp -rf /root/ems/publish_bak/. /var/www/ems-api/
```

### Step 4: restart the service then verify the staring log of the service
```
systemctl restart ems-api.service
journalctl -u ems-api.service
```

## Aditional

### Dump db 
pg_dump -h localhost -U postgres -d EMS -f ./backup_ems1.sql # dump full db
pg_dump -h localhost -U postgres -d EMS --data-only -f ./backup_data_ems1.sql # dump data only

### Import with sql files
psql -h localhost -U postgres -d EMS -f ./backup_data_ems1.sql
