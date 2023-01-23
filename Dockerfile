# Add nodeJS
FROM node:16
WORKDIR /clientapp
ENV PATH="./node_modules/.bin:$PATH"
COPY ./Filc/ClientApp .
EXPOSE 44463
RUN npm run build

# Build backend
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
COPY . .
RUN dotnet restore "./Filc/Filc.csproj" --disable-parallel
RUN dotnet publish "./Filc/Filc.csproj" -c release -o /app --no-restore

# Serve stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 7014

ENTRYPOINT ["dotnet", "Filc.dll"]