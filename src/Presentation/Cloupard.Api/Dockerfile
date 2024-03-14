FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Presentation/Cloupard.Api/Cloupard.Api.csproj", "src/Presentation/Cloupard.Api/"]
COPY ["src/Application/Cloupard.Application/Cloupard.Application.csproj", "src/Application/Cloupard.Application/"]
COPY ["src/Domain/Cloupard.Domain/Cloupard.Domain.csproj", "src/Domain/Cloupard.Domain/"]
COPY ["src/Shared/Cloupard.Common/Cloupard.Common.csproj", "src/Shared/Cloupard.Common/"]
COPY ["src/Infrastructure/Cloupard.Infrastructure/Cloupard.Infrastructure.csproj", "src/Infrastructure/Cloupard.Infrastructure/"]
COPY ["src/Services/Cloupard.Services.Logger/Cloupard.Services.Logger.csproj", "src/Services/Cloupard.Services.Logger/"]
COPY ["src/Services/Cloupard.Services.Settings/Cloupard.Services.Settings.csproj", "src/Services/Cloupard.Services.Settings/"]
RUN dotnet restore "src/Presentation/Cloupard.Api/Cloupard.Api.csproj"
COPY . .
WORKDIR "/src/src/Presentation/Cloupard.Api"
RUN dotnet build "Cloupard.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Cloupard.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cloupard.Api.dll"]
