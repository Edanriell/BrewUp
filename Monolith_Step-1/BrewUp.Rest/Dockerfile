FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
  
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BrewUp.Rest/BrewUp.Rest.csproj", "BrewUp.Rest/"]
COPY ["BrewUp.DomainModel/BrewUp.DomainModel.csproj", "BrewUp.DomainModel/"]
COPY ["BrewUp.Shared/BrewUp.Shared.csproj", "BrewUp.Shared/"]
COPY ["BrewUp.Infrastructure/BrewUp.Infrastructure.csproj", "BrewUp.Infrastructure/"]
COPY ["BrewUp.ReadModel/BrewUp.ReadModel.csproj", "BrewUp.ReadModel/"]
RUN dotnet restore "BrewUp.Rest/BrewUp.Rest.csproj"
COPY . .
WORKDIR "/src/BrewUp.Rest"
RUN dotnet build "./BrewUp.Rest.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BrewUp.Rest.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrewUp.Rest.dll"]
