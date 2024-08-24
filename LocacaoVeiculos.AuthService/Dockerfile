# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 81
EXPOSE 443

# Etapa de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LocacaoVeiculos.AuthService/LocacaoVeiculos.AuthService.csproj", "LocacaoVeiculos.AuthService/"]
RUN dotnet restore "LocacaoVeiculos.AuthService/LocacaoVeiculos.AuthService.csproj"
COPY . .
WORKDIR "/src/LocacaoVeiculos.AuthService"
RUN dotnet build "LocacaoVeiculos.AuthService.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "LocacaoVeiculos.AuthService.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocacaoVeiculos.AuthService.dll"]
