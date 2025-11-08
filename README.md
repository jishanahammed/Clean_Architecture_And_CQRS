# CQRS in Clean Architecture ASP.NET Core 8 project.
MyApp is an enterprise-ready ASP.NET Core 8 project following Clean Architecture principles and CQRS (Command-Query Responsibility Segregation) pattern.
It is designed for maintainability, testability, and scalability in large applications.

Key Features

Clean Architecture: Layered separation (Domain, Application, Infrastructure, WebApi)

CQRS with MediatR: Separate commands and queries for better maintainability

Repository Pattern: Abstraction of data access logic

Entity Framework Core 8: Database persistence

Dependency Injection: All layers wired up cleanly via DI

Swagger / OpenAPI: Automatically generated API documentation

Async / Await everywhere for scalable I/O operations



Project Structure

| Layer / Folder                                             | Description                                      |
| ---------------------------------------------------------- | ------------------------------------------------ |
| `MyApp.Domain/Entities/`                                   | Core business entities (e.g., Category, Product) |
| `MyApp.Domain/Enums/`                                      | Enumerations                                     |
| `MyApp.Domain/ValueObjects/`                               | Domain value objects                             |
| `MyApp.Domain/Interfaces/`                                 | Repository & domain contracts                    |
| `MyApp.Application/DTOs/`                                  | Data Transfer Objects                            |
| `MyApp.Application/CQRS/`                                  | Commands & Queries (MediatR)                     |
| `MyApp.Application/Interfaces/`                            | Application-level contracts                      |
| `MyApp.Application/Behaviors/`                             | Pipeline behaviors (validation, logging)         |
| `MyApp.Infrastructure/Persistence/ApplicationDbContext.cs` | EF Core DbContext                                |
| `MyApp.Infrastructure/Persistence/Configurations/`         | EntityTypeConfigurations                         |
| `MyApp.Infrastructure/Repositories/`                       | EF Core repository implementations               |
| `MyApp.Infrastructure/Services/`                           | External services (Email, File, API clients)     |
| `MyApp.Infrastructure/DependencyInjection.cs`              | DI for Infrastructure layer                      |
| `MyApp.WebApi/Controllers/`                                | API controllers                                  |
| `MyApp.WebApi/Program.cs`                                  | Startup & DI configuration                       |
| `MyApp.WebApi/appsettings.json`                            | Application configuration                        |



Apply EF Core migrations:
cd src/MyApp.Infrastructure

dotnet ef migrations add InitialCreate -s ../MyApp.WebApi

dotnet ef database update -s ../MyApp.WebApi



Run the Web API:
cd src/MyApp.WebApi
dotnet run


Access Swagger UI:

https://localhost:{port}/swagger



