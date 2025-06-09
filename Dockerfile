FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env

WORKDIR /app

# Copy solution and project files
COPY *.sln ./
COPY *.csproj ./
RUN dotnet restore

# Copy everything else (source files)
COPY . .

# Build & publish
RUN dotnet publish -c Release -o out

# Use runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out ./

# Expose port 5050 (or whichever port your app listens on)
EXPOSE 5050

ENTRYPOINT ["dotnet", "crmbe.dll"]
