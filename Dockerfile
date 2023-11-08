##See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Use the base image with the .NET runtime
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base

# Set the working directory inside the container
WORKDIR /app

# Use the image with the .NET SDK for building
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory for building
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["Quiz.csproj", "."]
RUN dotnet restore

# Copy the application source code
COPY . .

# Build the application in Release mode and output to /app/build
RUN dotnet build "Quiz.csproj" -c Release -o /app/build

# Create a publishing stage
FROM build AS publish

# Publish the application in Release mode without using the AppHost
RUN dotnet publish "Quiz.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the base image for the final stage
FROM base AS final

# Set the working directory inside the container
WORKDIR /app

# Copy the published application from the "publish" stage
COPY --from=publish /app/publish .

# Specify the entry point for running the application
ENTRYPOINT ["dotnet", "Quiz.dll"]
