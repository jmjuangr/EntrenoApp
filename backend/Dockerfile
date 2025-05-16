# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar todos los archivos al contenedor
COPY . .

# Restaurar paquetes y compilar
RUN dotnet restore EntrenosApp.sln
RUN dotnet build EntrenosApp.API/EntrenosApp.API.csproj -c Release
RUN dotnet publish EntrenosApp.API/EntrenosApp.API.csproj -c Release -o /app/publish

# Etapa de runtime con SDK (para poder ejecutar dotnet ef)
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /appç
# Instalar dotnet-ef para aplicar migraciones en tiempo de ejecución
RUN dotnet tool install --global dotnet-ef && \
    export PATH="$PATH:/root/.dotnet/tools"


# Copiar binarios publicados
COPY --from=build /app/publish ./

# Copiar script de arranque
COPY entrypoint.sh .

# Permisos de ejecución
RUN chmod +x entrypoint.sh

# Exponer puerto
EXPOSE 8080

# Entrada por defecto: aplicar migraciones y arrancar API
ENTRYPOINT ["./entrypoint.sh"]
