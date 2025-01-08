FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ZiiqueSocialBackend/ZiiqueSocialBackend.csproj", "ZiiqueSocialBackend/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Repo/Repo.csproj", "Repo/"]
COPY ["Service/Service.csproj", "Service/"]
RUN dotnet restore "ZiiqueSocialBackend/ZiiqueSocialBackend.csproj"
COPY . .
WORKDIR "/src/ZiiqueSocialBackend"
RUN dotnet build "ZiiqueSocialBackend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ZiiqueSocialBackend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZiiqueSocialBackend.dll"]
