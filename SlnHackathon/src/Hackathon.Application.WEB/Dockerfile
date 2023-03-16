FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine3.14 as build
WORKDIR /app
COPY . .
WORKDIR /app/src/Hackathon.Application.WEB
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine3.14 as runtime
RUN apk add --no-cache icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib
ENV ASPNETCORE_ENVIRONMENT Production
ENV ASPNETCORE_URLS http://+:8080
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=0
EXPOSE 8080
WORKDIR /app
COPY --from=build /app/published-app /app
COPY --from=build /app/src/Hackathon.Application.WEB/mycity.db /app
ENTRYPOINT [ "dotnet", "/app/Hackathon.Application.WEB.dll" ]