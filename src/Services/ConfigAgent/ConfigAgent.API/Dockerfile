FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/ConfigAgent/ConfigAgent.API/ConfigAgent.API.csproj", "Services/ConfigAgent/ConfigAgent.API/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
RUN dotnet restore "Services/ConfigAgent/ConfigAgent.API/ConfigAgent.API.csproj"
COPY . .
WORKDIR "/src/Services/ConfigAgent/ConfigAgent.API"
RUN dotnet build "ConfigAgent.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConfigAgent.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConfigAgent.API.dll"]
