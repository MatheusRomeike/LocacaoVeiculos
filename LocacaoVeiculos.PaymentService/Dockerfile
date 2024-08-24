# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 82
EXPOSE 443

# Etapa de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LocacaoVeiculos.PaymentService/LocacaoVeiculos.PaymentService.csproj", "LocacaoVeiculos.PaymentService/"]
RUN dotnet restore "LocacaoVeiculos.PaymentService/LocacaoVeiculos.PaymentService.csproj"
COPY . .
WORKDIR "/src/LocacaoVeiculos.PaymentService"
RUN dotnet build "LocacaoVeiculos.PaymentService.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "LocacaoVeiculos.PaymentService.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocacaoVeiculos.PaymentService.dll"]
