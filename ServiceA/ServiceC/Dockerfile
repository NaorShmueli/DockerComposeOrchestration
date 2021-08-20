From mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
ARG nuget_repository=https://api.nuget.org/v3/index.json
ARG source_folder
COPY ["${source_folder}ServiceC.csproj", "ServiceC/"]

RUN dotnet restore "ServiceC.csproj"
COPY ["${source_folder}.", "."]
WORKDIR "/src/ServiceC"

RUN dotnet build "ServiceC.csproj" -c Release -o /app/build

FROM build as Publish
RUN dotnet publish "ServiceC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ServiceC.dll"]

