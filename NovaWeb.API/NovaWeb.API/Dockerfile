#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["NovaWeb.API/NovaWeb.API.csproj", "NovaWeb.API/"]
COPY ["NovaWeb.Model/NovaWeb.Model.csproj", "NovaWeb.Model/"]
RUN dotnet restore "NovaWeb.API/NovaWeb.API.csproj"
COPY . .
WORKDIR "/src/NovaWeb.API"
RUN dotnet build "NovaWeb.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NovaWeb.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NovaWeb.API.dll"]
