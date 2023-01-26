# Build backend
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env

# Copy everything to main directory
WORKDIR /core
COPY . ./

# Restore Filc.csproj and all of it's dependencies
WORKDIR /core/Filc
RUN dotnet restore

# Build & Publish project to the /core/Filc/out folder
# (That folder contains our .dll file)
RUN dotnet publish -c Release -o out

# Building running environment
FROM mcr.microsoft.com/dotnet/sdk:6.0

# Copy the published project to the main folder
WORKDIR /core
COPY --from=build-env /core/Filc/out .

# Start Filc.dll
ENTRYPOINT ["dotnet", "Filc.dll"]