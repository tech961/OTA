# Rs.Api

This solution implements a Clean Architecture ASP.NET Core application with Entity Framework Core and MediatR. The sample feature exposes CRUD endpoints for `ToDoItem` resources following the CQRS pattern.

## Projects

- **Rs.Api** – ASP.NET Core Web API project (presentation layer).
- **Rs.Application** – Application layer containing commands, queries, validators and DTOs.
- **Rs.Domain** – Domain layer with entities, value objects, errors and domain services.
- **Rs.Persistence** – Infrastructure persistence layer with EF Core context, configurations, migrations and repositories.
- **Rs.Tests** – xUnit test project covering handlers, the controller and the domain service.

## Getting started

1. Restore dependencies:
   ```bash
   dotnet restore
   ```
2. Apply EF Core migrations (creates the SQL Server database defined in `appsettings.json`):
   ```bash
   dotnet ef database update --project Rs.Persistence --startup-project Rs.Api
   ```
3. Run the API:
   ```bash
   dotnet run --project Rs.Api
   ```
4. Browse Swagger UI at `https://localhost:5001/swagger` (or the HTTP endpoint shown on startup).

## Testing

Execute the unit test suite:
```bash
dotnet test
```

## Running with Docker

The repository includes a multi-stage `Dockerfile` for the API and a `docker-compose.yml` that provisions both the application and a SQL Server instance. To start the stack:

```bash
docker compose up --build
```

The API is exposed on [http://localhost:8080](http://localhost:8080) and connects to the SQL Server container using the connection string provided via environment variables (`ConnectionStrings__Default`). Database files are persisted in the named Docker volume `mssql-data`.

To stop and remove the containers while preserving the database volume, run:

```bash
docker compose down
```

## Notes

- Connection strings are configured in `Rs.Api/appsettings*.json`. The default points to the local SQL Server LocalDB instance (`(localdb)\MSSQLLocalDB`).
- The MediatR pipeline wires logging, validation and transactional behaviors so that handlers remain focused on business logic.
- FluentValidation handles request validation, and `ExceptionHandlingMiddleware` returns consistent problem responses for invalid requests.
