#!/bin/sh
export PATH="$PATH:/root/.dotnet/tools"

echo "Aplicando migraciones..."
dotnet ef database update --project EntrenosApp.API --startup-project EntrenosApp.API
echo "Migraciones aplicadas. Iniciando API..."
dotnet EntrenosApp.API.dll
