# Stage 1: Clone the GitLab repository and build the .NET project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Install git
RUN apt-get update && \
    apt-get install -y git

# Clone the repository
RUN git clone https://gitlab.com/test13311904/test-project .

# Change working directory to the directory containing the .csproj file
WORKDIR /app/Task_1/Task_Mvc

# Install additional SDK components for web development
RUN dotnet add package Microsoft.AspNetCore.Mvc

# Restore dependencies and build the project
RUN dotnet restore
RUN dotnet build --configuration Release

# Stage 2: Publish the application
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Stage 3: Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "Task_Mvc.dll"]
