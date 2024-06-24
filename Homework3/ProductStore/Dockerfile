FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 7055/tcp

# Официальный образ .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY Store.csproj Store/
RUN dotnet restore Store/Store.csproj
COPY . .
WORKDIR /src/Products
RUN dotnet build Store.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Store.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Store.dll"]