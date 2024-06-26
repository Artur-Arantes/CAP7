FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Fiap.Desafio.Api/Fiap.Desafio.Api.csproj", "Fiap.Desafio.Api/"]
RUN dotnet restore "Fiap.Desafio.Api/Fiap.Desafio.Api.csproj"
COPY . .
WORKDIR "/src/Fiap.Desafio.Api"
RUN dotnet build "Fiap.Desafio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Fiap.Desafio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fiap.Desafio.Api.dll"]
