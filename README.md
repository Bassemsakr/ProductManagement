# Products Management API

A Clean Architecture implementation of a Products and Categories management system using .NET 8, CQRS, MediatR, and Domain-Driven Design principles.

## Architecture Overview

src/
├── API/                  # Presentation layer (Controllers, DI)
├── Application/          # Application layer (Commands, Queries, DTOs)
│   ├── Products/         # Feature organization
│   ├── Categories/
│   └── ...
├── Domain/               # Core domain layer
│   ├── Entities/         # Aggregates and entities
│   ├── ValueObjects/     # Price, etc.
│   ├── Events/           # Domain events
│   └── Interfaces/       # Repository contracts
└── Infrastructure/       # Infrastructure services
    ├── Persistence/      # EF Core implementations
    └── Services/         # Other infrastructure services

ClientApp/                # Angular frontend (optional)

## Features

- ✅ Clean Architecture with separated layers
- ✅ CQRS pattern with MediatR
- ✅ Domain Events for cross-aggregate communication
- ✅ RESTful API endpoints (Level 2)
- ✅ Value Objects for Price (value + currency)
- ✅ Automatic ProductCount synchronization
- ✅ Swagger/OpenAPI documentation
- ✅ Angular frontend

## Technology Stack

- **Backend**:
  - .NET 8
  - Entity Framework Core
  - MediatR
  - SQL Server DB
  - Swagger UI

- **Frontend**:
  - Angular 17
  - RxJS

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (for Angular frontend)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Bassemsakr/ProductManagement.git
   cd ProductManagement
