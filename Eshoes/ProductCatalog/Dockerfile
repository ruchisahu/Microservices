FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ProductCatalog/ProductCatalog.csproj ProductCatalog/
RUN dotnet restore ProductCatalog/ProductCatalog.csproj
COPY . .
WORKDIR /src/ProductCatalog
RUN dotnet build ProductCatalog.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ProductCatalog.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductCatalog.dll"]
