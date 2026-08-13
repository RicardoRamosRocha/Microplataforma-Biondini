FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/Microplataforma.Domain/Microplataforma.Domain.csproj", "src/Microplataforma.Domain/"]
COPY ["src/Microplataforma.Infrastructure/Microplataforma.Infrastructure.csproj", "src/Microplataforma.Infrastructure/"]
COPY ["src/Microplataforma.Web/Microplataforma.Web.csproj", "src/Microplataforma.Web/"]

RUN dotnet restore "src/Microplataforma.Web/Microplataforma.Web.csproj"

COPY . .

RUN dotnet publish "src/Microplataforma.Web/Microplataforma.Web.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT:-10000}

ENTRYPOINT ["dotnet", "Microplataforma.Web.dll"]
