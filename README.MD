# CardVault

CardVault is an application that allows you to manage your payment cards. This guide outlines the steps required to run both the API and the user interface depending on your operating system.

## Prerequisites

1. **Docker and Docker Compose**  
   Install Docker following the official documentation: [Get Docker](https://docs.docker.com/get-docker/).

2. **.NET MAUI**  
   Install .NET MAUI according to the official instructions: [Install .NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/get-started/installation).

## Running Instructions

### 1. Running the API with Docker

1. Open your terminal.
2. Navigate to the main project folder:
    ```bash
    cd /Users/michal/Desktop/CardVault
    ```
3. Start the API using Docker Compose:
    ```bash
    docker-compose up -d
    ```
4. The API will be running in the background. To check the status:
    ```bash
    docker-compose ps
    ```

### 2. Running the User Interface (UI)

1. Install .NET MAUI if you haven't already.
2. Navigate to the UI folder:
    ```bash
    cd /Users/michal/Desktop/CardVault/src/UI/CardVault.UI
    ```

#### Running the UI Depending on Your Operating System

To build and run the UI application, use the appropriate command based on your operating system:

- **Windows**: To build the application for Windows, run:
    ```bash
    dotnet build --framework net8.0-windows10.0.19041.0
    ```
- **macOS**: To build the application for macOS, run:
    ```bash
    dotnet build -t:Run -f:net8.0-maccatalyst
    ```


## Stopping the API

To stop the running Docker containers, use the following command:
```bash
docker-compose down
