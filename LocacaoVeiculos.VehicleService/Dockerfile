# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80


# Etapa de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LocacaoVeiculos.VehicleService/LocacaoVeiculos.VehicleService.csproj", "LocacaoVeiculos.VehicleService/"]
RUN dotnet restore "LocacaoVeiculos.VehicleService/LocacaoVeiculos.VehicleService.csproj"
COPY . .
WORKDIR "/src/LocacaoVeiculos.VehicleService"
RUN dotnet build "LocacaoVeiculos.VehicleService.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "LocacaoVeiculos.VehicleService.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocacaoVeiculos.VehicleService.dll"]
