# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .                             
RUN dotnet restore EntrenosApp.sln
RUN dotnet publish EntrenosApp.API/EntrenosApp.API.csproj -c Release -o /app

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "EntrenosApp.API.dll"]
