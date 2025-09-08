FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081 

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BrewUp.Rest/BrewUp.Rest.csproj", "BrewUp.Rest/"]
COPY ["BrewUp.Infrastructure/BrewUp.Infrastructure.csproj", "BrewUp.Infrastructure/"]
COPY ["BrewUp.Shared/BrewUp.Shared.csproj", "BrewUp.Shared/"]
COPY ["BrewUp.Mediator/BrewUp.Mediator.csproj", "BrewUp.Mediator/"]
COPY ["Sales/BrewUp.Sales.Facade/BrewUp.Sales.Facade.csproj", "Sales/BrewUp.Sales.Facade/"]
COPY ["Sales/BrewUp.Sales.Domain/BrewUp.Sales.Domain.csproj", "Sales/BrewUp.Sales.Domain/"]
COPY ["Sales/BrewUp.Sales.ReadModel/BrewUp.Sales.ReadModel.csproj", "Sales/BrewUp.Sales.ReadModel/"]
COPY ["Sales/BrewUp.Sales.SharedKernel/BrewUp.Sales.SharedKernel.csproj", "Sales/BrewUp.Sales.SharedKernel/"]
COPY ["Sales/BrewUp.Sales.Infrastructures/BrewUp.Sales.Infrastructures.csproj", "Sales/BrewUp.Sales.Infrastructures/"]
COPY ["Warehouses/BrewUp.Warehouses.Facade/BrewUp.Warehouses.Facade.csproj", "Warehouses/BrewUp.Warehouses.Facade/"]
COPY ["Warehouses/BrewUp.Warehouses.Domain/BrewUp.Warehouses.Domain.csproj", "Warehouses/BrewUp.Warehouses.Domain/"]
COPY ["Warehouses/BrewUp.Warehouses.SharedKernel/BrewUp.Warehouses.SharedKernel.csproj", "Warehouses/BrewUp.Warehouses.SharedKernel/"]
COPY ["Warehouses/BrewUp.Warehouses.Infrastructures/BrewUp.Warehouses.Infrastructures.csproj", "Warehouses/BrewUp.Warehouses.Infrastructures/"]
COPY ["Warehouses/BrewUp.Warehouses.ReadModel/BrewUp.Warehouses.ReadModel.csproj", "Warehouses/BrewUp.Warehouses.ReadModel/"]
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
