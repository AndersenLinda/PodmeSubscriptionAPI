# Podme Subcription API

This is a simple API for allowing users to start and stop subscriptions in Podme.

## Getting Started

These instructions will help you set up and run the project on your local machine.

### Prerequisites

- .NET Core SDK
- Docker

### Installation

1. **Open the Project in Visual Studio:**
   - Launch Visual Studio.
   - Open the project folder in Visual Studio.

2. **Run the Project:**
   - Once the project is opened, simply click the "Start" button or press F5 to build and run the project.

3. **Explore and Interact with the API using Swagger:**
   - Open a web browser.
   - Navigate to `http://localhost:32768/swagger`.
   - This will display the Swagger UI, where you can explore and test all available endpoints interactively.

## Usage

This API provides endpoints for subscribing to and unsubscribing from Podme subscriptions.

- To subscribe to a podcast, send a POST request to `/api/subscription/start` with the user's email and the podcast name in the request body.
- To unsubscribe from a podcast, send a POST request to `/api/subscription/stop` with the user's email and the podcast name in the request body.

## Built With

- ASP.NET Core
- Entity Framework Core
- Docker (for containerization)