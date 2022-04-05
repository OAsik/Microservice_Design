#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/FlightService/Flight.API/Flight.API.csproj", "Services/FlightService/Flight.API/"]
COPY ["Services/FlightService/FlightService.Infrastructure/FlightService.Infrastructure.csproj", "Services/FlightService/FlightService.Infrastructure/"]
COPY ["Services/FlightService/FlightService.Application/FlightService.Application.csproj", "Services/FlightService/FlightService.Application/"]
COPY ["Services/FlightService/FlightService.Domain/FlightService.Domain.csproj", "Services/FlightService/FlightService.Domain/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
RUN dotnet restore "Services/FlightService/Flight.API/Flight.API.csproj"
COPY . .
WORKDIR "/src/Services/FlightService/Flight.API"
RUN dotnet build "Flight.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Flight.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Flight.API.dll"]
