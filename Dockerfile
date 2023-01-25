
#Stage 1: build

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /src
COPY . /src

WORKDIR /src/Filc

RUN dotnet restore "Filc.csproj"
RUN dotnet build "Filc.csproj" -c Release -o /app/build
#Stage 2: publish

FROM build AS publish
RUN ls -la

RUN dotnet publish "Filc.csproj" -c Release -o /app/publish


#Stage 3: build node

FROM node:16 AS node-builder
WORKDIR /node
COPY ./Filc/ClientApp /node
RUN npm install
RUN npm build

#Stage 4: final
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

WORKDIR /app
EXPOSE 5014
EXPOSE 7014
RUN mkdir /app/Filc/wwwroot

COPY --from=publish /src/app/publish .
COPY --from=node-builder /node/build ./Filc/wwwroot

ENTRYPOINT ["dotnet", "Filc.dll"]