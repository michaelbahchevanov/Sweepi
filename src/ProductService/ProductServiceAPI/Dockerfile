FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=build-env /app/out .

EXPOSE 5300/tcp
ENV ASPNETCORE_URLS http://*:5300
HEALTHCHECK --interval=30s --timeout=3s --retries=1 CMD curl --silent --fail http://localhost:5300/hc || exit 1

ENTRYPOINT [ "dotnet", "Sweepi.ProductServiceAPI.dll" ]