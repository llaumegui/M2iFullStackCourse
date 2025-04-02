FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY exo04-MVC/. ./
RUN dotnet restore
RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine

RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
EXPOSE 8080
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet","exo04-MVC.dll"]