#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/CrewService/Crew.API/Crew.API.csproj", "Services/CrewService/Crew.API/"]
COPY ["Services/CrewService/CrewService.Application/CrewService.Application.csproj", "Services/CrewService/CrewService.Application/"]
COPY ["Services/CrewService/CrewService.Domain/CrewService.Domain.csproj", "Services/CrewService/CrewService.Domain/"]
COPY ["Services/CrewService/CrewService.Infrastructure/CrewService.Infrastructure.csproj", "Services/CrewService/CrewService.Infrastructure/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
RUN dotnet restore "Services/CrewService/Crew.API/Crew.API.csproj"
COPY . .
WORKDIR "/src/Services/CrewService/Crew.API"
RUN dotnet build "Crew.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Crew.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Crew.API.dll"]
