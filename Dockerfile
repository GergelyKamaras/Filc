# Build backend
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env

WORKDIR /core
COPY . ./
WORKDIR /core/Filc
RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /core
COPY --from=build-env /core/Filc/out .
ENTRYPOINT ["dotnet", "Filc.dll"]