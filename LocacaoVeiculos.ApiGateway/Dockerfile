# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80


# Etapa de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LocacaoVeiculos.ApiGateway/LocacaoVeiculos.ApiGateway.csproj", "LocacaoVeiculos.ApiGateway/"]
RUN dotnet restore "LocacaoVeiculos.ApiGateway/LocacaoVeiculos.ApiGateway.csproj"
COPY . .
WORKDIR "/src/LocacaoVeiculos.ApiGateway"
RUN dotnet build "LocacaoVeiculos.ApiGateway.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "LocacaoVeiculos.ApiGateway.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocacaoVeiculos.ApiGateway.dll"]
