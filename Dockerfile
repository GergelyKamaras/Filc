# Add nodeJS
FROM node:16 as frontend-builder
WORKDIR /core
COPY /Filc/ClientApp .
RUN npm install
EXPOSE 44453
RUN npm run build

# Build backend
FROM mcr.microsoft.com/dotnet/sdk:6.0 as backend
WORKDIR /core
COPY --from=frontend-builder /core/build /core/ClientApp
COPY . .
WORKDIR /core/Filc

RUN dotnet dev-certs https && dotnet restore && dotnet run
WORKDIR /core/Filc/ClientApp
CMD [ "npm", "start" ]