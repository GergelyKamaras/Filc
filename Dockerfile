# Add nodeJS
#FROM node:18.2.0 as frontend-builder
#WORKDIR /core
#COPY /Filc/ClientApp .
#WORKDIR /core/Filc/ClientApp
#RUN npm install --force


# Build backend
FROM mcr.microsoft.com/dotnet/sdk:6.0 as backend
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_16.x | bash \
    && apt-get install nodejs -yq

WORKDIR /core
# COPY --from=frontend-builder . /core/Filc/ClientApp
COPY . .

WORKDIR /core/Filc/ClientApp
RUN npm install --force

WORKDIR /core/Filc

EXPOSE 44463
EXPOSE 44453
EXPOSE 7014
EXPOSE 5014

RUN dotnet dev-certs https && dotnet restore
CMD ["dotnet", "run"]