# realProperty-api

## General Solution Description

CopilotDemoApi is a sample project designed to demonstrate the integration of various services and technologies using .NET 8 and C# 12.0. The project includes a RESTful API for managing real property data, with endpoints for retrieving property details and generating advertisements. The project also showcases the use of LiteDB for data storage and logging with Microsoft.Extensions.Logging.

## Features

- RESTful API for managing real property data
- Integration with LiteDB for data storage
- Logging with Microsoft.Extensions.Logging

## Steps to Run

1. **Clone the repository**:
	git https://github.com/JozefDuris/realProperty-api.git

2. **Install dependencies**:
   Ensure you have the .NET 8 SDK installed. You can download it from the [official .NET website](https://dotnet.microsoft.com/download/dotnet/8.0).

   Restore the project dependencies:
	dotnet restore
3. **Build the project**:
	dotnet build
4. **Run the project**:
	dotnet run
5. **Access the API**:
   The API will be available at `https://localhost:5001` or `http://localhost:5000`. You can use tools like Postman or cURL to interact with the API endpoints.

6. **GraphQL Playground** (if using Hot Chocolate):
   If you have configured the project to use GraphQL with Hot Chocolate, you can access the GraphQL Playground at `https://localhost:5001/graphql` or `http://localhost:5000/graphql`.

## Note

This is a community repository and should be used mainly for experimenting with GitHub Copilot. Feel free to explore, modify, and extend the project as needed.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

