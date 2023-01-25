# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

# installs NodeJS and NPM
RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash - && apt-get install -yq nodejs build-essential

# copy the files from the file system so they can built
COPY ./ /src
WORKDIR /src

# install node
RUN npm install -g npm
RUN npm --version
# Opt out of .NET Core's telemetry collection
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

# set node to production
ENV NODE_ENV production
WORKDIR /src/Filc

# run the publish command, which also runs the required NPM commands to build the React front-end
RUN dotnet dev-certs https && dotnet dev-certs https --trust
RUN dotnet publish "Filc.csproj" -c Release

# Run stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal as run

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

RUN apt-get update 

EXPOSE 44463
ENV ASPNETCORE_URLS https://*:44463

COPY --from=build /src/Filc/bin/Release/net6.0/publish /app
WORKDIR /app

RUN mkdir -p /ASP.NET/DataProtection-Keys
RUN chown -R 1001:0 /ASP.NET/DataProtection-Keys
RUN ls -la
# don't run as root user - this is a good security practice, and also required for running this container in OpenShift
RUN chown 1001:0 Filc.dll
RUN chmod g+rwx Filc.dll
USER 1001

ENTRYPOINT ["dotnet", "Filc.dll"]