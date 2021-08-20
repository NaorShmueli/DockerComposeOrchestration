From mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
ARG nuget_repository=https://api.nuget.org/v3/index.json
ARG source_folder
COPY ["${source_folder}ServiceA.csproj", "ServiceA/"]

RUN dotnet restore "ServiceA.csproj"
COPY ["${source_folder}.", "."]
WORKDIR "/src/ServiceA"

RUN dotnet build "ServiceA.csproj" -c Release -o /app/build

FROM build as Publish
RUN dotnet publish "ServiceA.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ServiceA.dll"]

