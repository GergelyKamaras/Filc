﻿# Build backend
FROM mcr.microsoft.com/dotnet/sdk:6.0
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_16.x | bash \
    && apt-get install nodejs -yq

WORKDIR /core
COPY . .

WORKDIR /core/Filc

EXPOSE 7014
EXPOSE 5014

RUN dotnet dev-certs https && dotnet restore
CMD ["dotnet", "run"]