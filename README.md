# InsuranceSolution

A modular, clean architecture-based insurance management system built with .NET Core. This solution demonstrates a scalable, maintainable, and testable back-end design using modern architectural patterns and principles.

## Features

- Clean Architecture (Domain-Driven Design)
- Layered Project Structure (API, Application, Infrastructure, Persistence)
- RESTful API with ASP.NET Core
- CQRS pattern via MediatR
- Dependency Injection
- Entity Framework Core for data access
- Dockerized setup with `docker-compose`
- FluentValidation for input validation
- xUnit for unit testing

## Technologies Used

- **.NET Core**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **MediatR** – for implementing CQRS pattern
- **AutoMapper** – for object-object mapping
- **FluentValidation** – for input validation
- **xUnit** – for unit testing
- **Polly** – for resilience (retry policies)
- **Serilog** – for structured logging
- **JWT Authentication** – for secure API access
- **Docker & Docker Compose** – for containerization
- **Microsoft SQL Server**
- **Clean Architecture**, **CQRS**, **SOLID Principles**

## Project Structure

InsuranceSolution

- InsuranceSolution.API/           # API Layer (Controllers, Middlewares)
- InsuranceSolution.Application/  # Application Layer (CQRS, Business Logic)
- InsuranceSolution.Domain/       # Domain Layer (Entities, Interfaces)
- InsuranceSolution.Infrastructure/ # External services, file storage etc.
- InsuranceSolution.Persistence/  # Database Context, Migrations
- docker-compose.yml              # Docker Configuration

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)

### Run with Docker

```bash
docker-compose up --build

