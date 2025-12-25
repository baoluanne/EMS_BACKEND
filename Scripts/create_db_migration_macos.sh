#!/usr/bin/env bash

# --- Variables ---
# Set the paths relative to where you will run this script
STARTUP_PROJECT="../EMS.API/"
PROJECT="../EMS.EFCore/"
CONTEXT="AppDbContext"
OUTPUT_PATH="../EMS.EFCore/Migrations"

# --- Prompt user for migration name ---
read -p "Enter the migration name: " MIGRATION_NAME

# --- Check if migration name is empty ---
# [ -z "$VAR" ] checks if the variable is null or an empty string
if [ -z "$MIGRATION_NAME" ]; then
    echo "Migration name cannot be empty. Exiting..."
    exit 1
fi

# --- Run the dotnet ef command ---
echo "Attempting to create migration..."

# We use "$VAR" to safely handle variables that might contain spaces
# The backslash (\) at the end of a line lets us continue the command on the next line for readability
dotnet ef --startup-project "$STARTUP_PROJECT" \
         --project "$PROJECT" \
         migrations add "$MIGRATION_NAME" \
         --context "$CONTEXT" \
         -o "$OUTPUT_PATH"

# --- Check if the command was successful ---
# $? holds the exit code of the last command (like %ERRORLEVEL% in batch)
# 0 means success, any other number means failure
if [ $? -eq 0 ]; then
    echo "✅ Migration \"$MIGRATION_NAME\" created successfully."
else
    echo "❌ Failed to create migration \"$MIGRATION_NAME\"."
fi