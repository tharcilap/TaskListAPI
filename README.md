# Task Management API

## Description

A simple API for managing tasks and subtasks. This API allows users to create, read, update, and delete tasks.
Tasks can have subtasks that relate to them, and a task can only be marked as complete when all its subtasks are marked as complete.
When reading tasks, the API provides a count of the subtasks.
The API also ensures that tasks cannot be deleted if subtasks exist.

## Technologies

- .NET 8.0
- SQLite
- Entity Framework Core

## Project Structure

- **Controllers**: Manage API routes.
- **Services**: Business logic layer.
- **Repositories**: Data access layer.
- **DTOs**: Data Transfer Objects to encapsulate data sent and received by the API.
- **Models**: Data models representing entities.
- **Mappers**: Mapping configurations for AutoMapper.

## Getting Started

1. Install .NET SDK:
    Ensure you have .NET 8 SDK installed.

2. Clone the repo:
    git clone https://github.com/tharcilap/TaskListAPI.git
    cd TaskListAPI

3.Install dependencies:
    Restore the NuGet packages defined in the .csproj file:
    dotnet restore

4.Install EF Core Tools:
    Install the dotnet-ef tool globally if not already installed:
    dotnet tool install --global dotnet-ef

5.Apply migrations:
    Update your SQLite database with the latest migrations:
    dotnet ef database update

6.Run the app:
    dotnet run


## Installed Packages

Here are the NuGet packages used in this project, including their versions and installation commands:

- AutoMapper (version 12.0.1)
    dotnet add package AutoMapper --version 12.0.1

- AutoMapper.Extensions.Microsoft.DependencyInjection (version 12.0.1)
    dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1

- Microsoft.EntityFrameworkCore.Design (version 8.0.7)
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.7

- Microsoft.EntityFrameworkCore.Sqlite (version 8.0.7)
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.7

- System.ComponentModel.Annotations (version 5.0.0)
    dotnet add package System.ComponentModel.Annotations --version 5.0.0


## API Endpoints

GET /api/tasks - Retrieve all tasks.

POST /api/tasks - Create a new task.

PUT /api/tasks/{id} - Update a task.

DELETE /api/tasks/{id} - Delete a task.

GET /api/subtasks - Retrieve all subtasks.

POST /api/subtasks - Create a new subtask.

PUT /api/subtasks/{id} - Update a subtask.

DELETE /api/subtasks/{id} - Delete a subtask.
