# Products Management App

A Clean Architecture implementation of a Products and Categories management system using .NET 8, CQRS, MediatR, and Domain-Driven Design principles.

## Directory Structure

```bash
src/
├── API/                  # Presentation layer: Controllers, Middleware
├── Application/          # CQRS: Commands, Queries, Handlers, DTOs
│   ├── Products/         # All product-related CQRS objects
│   ├── Categories/       # All category-related CQRS objects
│   └── Common/           # Shared application logic
├── Domain/               # Core business logic
│   ├── Entities/         # Product, Category aggregates
│   ├── ValueObjects/     # Price (value + currency)
│   ├── Events/           # Domain events definitions
│   └── Interfaces/       # Repository interfaces
└── Infrastructure/       # External concerns implementation
    ├── Persistence/      # DbContext, Repositories
    └── Services/         # File storage, email, etc.

ClientApp/                # Angular UI
```


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
