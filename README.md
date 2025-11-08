# CQRS in Clean Architecture ASP.NET Core 8 project.
MyApp is an enterprise-ready ASP.NET Core 8 project following Clean Architecture principles and CQRS (Command-Query Responsibility Segregation) pattern.
It is designed for maintainability, testability, and scalability in large applications.

Project Structure
src/
├── MyApp.Domain
│ ├── Entities/ # Core business entities (e.g., Category, Product)
│ ├── Enums/ # Enumerations
│ ├── ValueObjects/ # Domain value objects
│ └── Interfaces/ # Repository & domain contracts

├── MyApp.Application
│ ├── DTOs/ # Data Transfer Objects
│ ├── CQRS/ # Commands & Queries (MediatR)
│ ├── Interfaces/ # Application-level contracts
│ └── Behaviors/ # Pipeline behaviors (validation, logging)

├── MyApp.Infrastructure
│ ├── Persistence/
│ │ ├── ApplicationDbContext.cs # EF Core DbContext
│ │ └── Configurations/ # EntityTypeConfigurations
│ ├── Repositories/ # EF Core repository implementations
│ ├── Services/ # External services (Email, File, API clients)
│ └── DependencyInjection.cs # DI for Infrastructure layer

└── MyApp.WebApi
├── Controllers/ # API controllers
├── Program.cs # Startup & DI configuration
└── appsettings.json # Application configuration
    
