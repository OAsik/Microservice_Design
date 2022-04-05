#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/PilotService/Pilot.API/Pilot.API.csproj", "Services/PilotService/Pilot.API/"]
COPY ["Services/PilotService/Pilot.Infrastructure/Pilot.Infrastructure.csproj", "Services/PilotService/Pilot.Infrastructure/"]
COPY ["Services/PilotService/Pilot.Application/Pilot.Application.csproj", "Services/PilotService/Pilot.Application/"]
COPY ["Services/PilotService/Pilot.Domain/Pilot.Domain.csproj", "Services/PilotService/Pilot.Domain/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
RUN dotnet restore "Services/PilotService/Pilot.API/Pilot.API.csproj"
COPY . .
WORKDIR "/src/Services/PilotService/Pilot.API"
RUN dotnet build "Pilot.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pilot.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pilot.API.dll"]
