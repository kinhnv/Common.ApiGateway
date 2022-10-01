#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM pre-build-params_registry/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM pre-build-params_registry/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY Libraries Libraries
COPY TestMaker.ApiGateway TestMaker.ApiGateway
RUN dotnet restore "TestMaker.ApiGateway/TestMaker.ApiGateway.csproj"
WORKDIR "/src/TestMaker.ApiGateway"
RUN dotnet build "TestMaker.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestMaker.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestMaker.ApiGateway.dll"]