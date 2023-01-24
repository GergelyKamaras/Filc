# Add nodeJS
FROM node:18.2.0 as frontend-builder
WORKDIR /core
COPY /Filc/ClientApp .
WORKDIR /core/Filc/ClientApp
RUN npm install --force


# Build backend
FROM mcr.microsoft.com/dotnet/sdk:6.0 as backend
WORKDIR /core
COPY --from=frontend-builder . /core/Filc/ClientApp
COPY . .
WORKDIR /core/Filc/ClientApp
RUN npm start
WORKDIR /core/Filc

RUN dotnet dev-certs https && dotnet restore
CMD ["dotnet" "run"]