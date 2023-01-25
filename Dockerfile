
#Stage 1: build

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /src
COPY . /src
WORKDIR /src/Filc

RUN dotnet restore "Filc.csproj"

RUN dotnet build "Filc.csproj" -c Release -o /app/build
#Stage 2: publish

FROM build AS publish

RUN dotnet publish "Filc.csproj" -c Release -o /app/publish

#Stage 3: build node

FROM node:16 AS node-builder
WORKDIR /node
COPY ./Filc/ClientApp /node
RUN npm install
RUN npm run build

#Stage 4: final
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

WORKDIR /app

EXPOSE 5014
EXPOSE 7014
RUN mkdir /app/wwwroot
COPY --from=publish /app/publish .
COPY --from=build /src/myserver.crt /app/myserver.crt
COPY --from=build /src/myserver.key /app/myserver.key 
RUN ls -la /app
COPY --from=node-builder /node/build ./wwwroot
ENV ASPNETCORE_URLS=https://+:7014;http://+:5014
ENV ASPNETCORE_HTTPS_PORT=7014
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=H71k2tfg3
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=\https\\filc-certs.pfx

ENTRYPOINT ["dotnet", "Filc.dll"]