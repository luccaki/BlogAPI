#!/bin/bash
set -e

# Run EF Core migrations
echo "Applying migrations..."
dotnet ef database update

# Start the application
echo "Starting application..."
exec dotnet BlogAPI.dll
