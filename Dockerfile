# Add nodeJS
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Filc/Filc.csproj", "Filc/"]
RUN dotnet restore "Filc/Filc.csproj"
COPY . .
WORKDIR "/src/Filc"
RUN dotnet build "Filc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Filc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Filc.dll"]