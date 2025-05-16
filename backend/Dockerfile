FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore EntrenosApp.sln
RUN dotnet build EntrenosApp.API/EntrenosApp.API.csproj -c Release
RUN dotnet publish EntrenosApp.API/EntrenosApp.API.csproj -c Release -o /app/publish

# Runtime final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "EntrenosApp.API.dll"]
