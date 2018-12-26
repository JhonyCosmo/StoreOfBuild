FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY StoreOfBuild.Web/StoreOfBuild.Web.csproj StoreOfBuild.Web/
RUN dotnet restore StoreOfBuild.Web/StoreOfBuild.Web.csproj
COPY . .
WORKDIR /src/StoreOfBuild.Web
RUN dotnet build StoreOfBuild.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish StoreOfBuild.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StoreOfBuild.Web.dll"]
