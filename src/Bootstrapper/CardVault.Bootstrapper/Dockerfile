FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5252
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Bootstrapper/CardVault.Bootstrapper/CardVault.Bootstrapper.csproj", "src/Bootstrapper/CardVault.Bootstrapper/"]
RUN dotnet restore "src/Bootstrapper/CardVault.Bootstrapper/CardVault.Bootstrapper.csproj"
COPY . .
WORKDIR "/src/src/Bootstrapper/CardVault.Bootstrapper"
RUN dotnet build "CardVault.Bootstrapper.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CardVault.Bootstrapper.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CardVault.Bootstrapper.dll"]
