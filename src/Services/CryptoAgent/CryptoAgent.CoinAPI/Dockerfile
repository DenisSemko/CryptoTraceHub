FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/CryptoAgent/CryptoAgent.CoinAPI/CryptoAgent.CoinAPI.csproj", "Services/CryptoAgent/CryptoAgent.CoinAPI/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
RUN dotnet restore "Services/CryptoAgent/CryptoAgent.CoinAPI/CryptoAgent.CoinAPI.csproj"
COPY . .
WORKDIR "/src/Services/CryptoAgent/CryptoAgent.CoinAPI"
RUN dotnet build "CryptoAgent.CoinAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CryptoAgent.CoinAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CryptoAgent.CoinAPI.dll"]
