#!/usr/bin/env bash

# --- Variables ---
# Set the paths relative to where you will run this script
STARTUP_PROJECT="../EMS.API/"
CONTEXT="AppDbContext"

# --- Run the dotnet ef database update command ---
echo "Attempting to update database for context \"$CONTEXT\"..."

dotnet ef --startup-project "$STARTUP_PROJECT" \
         database update \
         --context "$CONTEXT"

# --- Check if the command was successful ---
# $? holds the exit code of the last command (0 for success)
if [ $? -eq 0 ]; then
    echo "✅ Database updated successfully."
else
    echo "❌ Failed to update the database."
fi