@echo off
setlocal enabledelayedexpansion

:: Variables
set STARTUP_PROJECT=../EMS.API/
set CONTEXT=AppDbContext

:: Initialize variables
set LAST_MIGRATION=
set TARGET_MIGRATION=
set COUNT=0

:: Get list of migrations and find second-to-last
for /f "tokens=* delims=" %%M in ('dotnet ef migrations list --startup-project %STARTUP_PROJECT% --context %CONTEXT%') do (
    set LAST_MIGRATION=!TARGET_MIGRATION!
    set TARGET_MIGRATION=%%M
    set /a COUNT+=1
)

if "!LAST_MIGRATION!"=="" (
    echo No previous migration found to revert to.
    exit /b 1
)

:: Revert to the previous migration
dotnet ef --startup-project %STARTUP_PROJECT% database update !LAST_MIGRATION! --context %CONTEXT%

:: Check if the command was successful
if %ERRORLEVEL% equ 0 (
    echo Database successfully reverted to migration "!LAST_MIGRATION!".
) else (
    echo Failed to revert the database for context "%CONTEXT%".
)
