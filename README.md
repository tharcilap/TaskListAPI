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
- AutoMapper
- Dependency Injection


## Project Structure

- **Controllers**: Manage API routes.
- **Services**: Business logic layer.
- **Repositories**: Data access layer.
- **DTOs**: Data Transfer Objects to encapsulate data sent and received by the API.
- **Models**: Data models representing entities.
- **Mappers**: Mapping configurations for AutoMapper.

## Getting Started
Prerequisites

    .NET 8 SDK
    SQLite