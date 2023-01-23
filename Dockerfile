# Add nodeJS
FROM node:16

# Build backend
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
COPY . .
RUN dotnet restore "./Filc/Filc.csproj" --disable-parallel
RUN dotnet publish "./Filc/Filc.csproj" -c release -o /app --no-restore

# Serve stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
ENV DOTNET_URLS=http://+:44463
WORKDIR /app
COPY --from=build /app ./

EXPOSE 44463


ENTRYPOINT ["dotnet", "Filc.dll"]