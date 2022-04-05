FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/AuthenticationService/Authentication.API/Authentication.API.csproj", "Services/AuthenticationService/Authentication.API/"]
RUN dotnet restore "Services/AuthenticationService/Authentication.API/Authentication.API.csproj"
COPY . .
WORKDIR "/src/Services/AuthenticationService/Authentication.API"
RUN dotnet build "Authentication.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authentication.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authentication.API.dll"]
