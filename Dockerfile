FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Ormawa.csproj ./
RUN dotnet restore ./Ormawa.csproj
COPY . .
WORKDIR /src/
RUN dotnet build Ormawa.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Ormawa.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ormawa.dll"]
