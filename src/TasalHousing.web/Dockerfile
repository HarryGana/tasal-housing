#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TasalHousing.web/TasalHousing.web.csproj", "TasalHousing.web/"]
COPY ["TasalHousing.Data/TasalHousing.Data.csproj", "TasalHousing.Data/"]
RUN dotnet restore "TasalHousing.web/TasalHousing.web.csproj"
COPY . .
WORKDIR "/src/TasalHousing.web"
RUN dotnet build "TasalHousing.web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TasalHousing.web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TasalHousing.web.dll"]
