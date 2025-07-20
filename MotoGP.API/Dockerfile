# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and restore
COPY *.sln .
COPY MotoGP.*/*.csproj ./
RUN for file in *.csproj; do mkdir -p ${file%%.*} && mv "$file" "${file%%.*}/"; done
RUN dotnet restore

# Copy source and build
COPY . .
WORKDIR /src/MotoGP.API
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "MotoGP.API.dll"]
