#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["1 - Application/e-Estoque.App/e-Estoque.App.csproj", "1 - Application/e-Estoque.App/"]
COPY ["2 - Domain/e-Estoque.Domain/e-Estoque.Domain.csproj", "2 - Domain/e-Estoque.Domain/"]
COPY ["3 - Service/e-Estoque.Service/e-Estoque.Service.csproj", "3 - Service/e-Estoque.Service/"]
COPY ["4 - Infra/4.2 - CrossCutting/e-Estoque.CrossCutting/e-Estoque.CrossCutting.csproj", "4 - Infra/4.2 - CrossCutting/e-Estoque.CrossCutting/"]
COPY ["4 - Infra/4.1 - Data/e-Estoque.Data/e-Estoque.Data.csproj", "4 - Infra/4.1 - Data/e-Estoque.Data/"]
COPY ["4 - Infra/e-Estoque.Infra/e-Estoque.Infra/e-Estoque.Infra.csproj", "4 - Infra/e-Estoque.Infra/e-Estoque.Infra/"]
RUN dotnet restore "./1 - Application/e-Estoque.App/./e-Estoque.App.csproj"
COPY . .
WORKDIR "/src/1 - Application/e-Estoque.App"
RUN dotnet build "./e-Estoque.App.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./e-Estoque.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "e-Estoque.App.dll"]