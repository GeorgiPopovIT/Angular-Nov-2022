#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GorgesMusicBackend/GorgesMusicBackend.csproj", "GorgesMusicBackend/"]
COPY ["GorgesMusic.Core/GorgesMusic.Core.csproj", "GorgesMusic.Core/"]
COPY ["GorgesMusic/GorgesMusic.Data.csproj", "GorgesMusic/"]
RUN dotnet restore "./GorgesMusicBackend/GorgesMusicBackend.csproj"
COPY . .
WORKDIR "/src/GorgesMusicBackend"
RUN dotnet build "./GorgesMusicBackend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GorgesMusicBackend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GorgesMusicBackend.dll"]