# CRUD with DDD (.NET 6)

A customer management API built with Domain-Driven Design (DDD) layering, focused on clean separation of concerns, maintainability, and a straightforward local developer experience.

## Overview

This project exposes a REST API for customer lifecycle operations:

- Create customers with one or many phone numbers
- List customers with pagination
- Search customers by phone number + area code (DDD)
- Update customer email
- Update customer phone
- Soft-delete customer by email

The solution is organized using a layered architecture inspired by DDD, with repositories, services, DTOs, and EF Core persistence.

## Architecture

The solution follows a classic DDD-style separation:

- `WebAPIs`: HTTP layer (controllers, Swagger, dependency injection wiring)
- `Application`: use cases, DTOs, mapping profiles, service contracts/implementations
- `Domain`: domain contracts (repository interfaces, shared abstractions)
- `Infrastructure`: EF Core context, migrations, repository implementations
- `Entities`: domain entities and enums
- `TestProjectApi`: unit/integration-style tests for API behavior

### Request Flow

`HTTP Request -> Controller -> Application Service -> Repository -> EF Core -> SQL Server`

## Tech Stack

- .NET 6 (ASP.NET Core Web API)
- Entity Framework Core 6
- SQL Server 2019 (Docker Compose)
- AutoMapper
- Swagger / OpenAPI (Swashbuckle)
- MSTest + Moq + Coverlet

## API Contracts

### User (create payload)

```json
{
  "name": "John Doe",
  "email": "john.doe@example.com",
  "phones": [
    {
      "ddd": "11",
      "number": "999999999",
      "type": 2
    }
  ]
}
```

`type` values:

- `1` = `Fixo` (landline)
- `2` = `Celular` (mobile)

### Endpoints

Base route: `api/users`

- `GET /api/users?pageNumber=1&pageSize=10`
  - Returns paginated users (`users`, `pageNumber`, `pageSize`, `totalItems`, `totalPages`)
- `POST /api/users`
  - Creates a user
- `GET /api/users/SearchByPhoneNumber?phoneNumber=999999999&ddd=11`
  - Returns users matching phone + DDD
- `PUT /api/users/{userId}/update-email`
  - Body: `{ "newEmail": "new@mail.com" }`
- `PATCH /api/users/{userId}/update-phone/{idPhone}`
  - Body: `{ "newPhone": "988887777", "ddd": "11" }`
- `DELETE /api/users/delete-by-email?email=user@mail.com`
  - Performs soft delete (`IsActive = false`)

## Getting Started

### Prerequisites

- Docker Desktop
- .NET 6 SDK
- (Optional) Visual Studio 2022

### 1. Clone repository

```bash
git clone git@github.com:diegopires1992/crud-ddd.git
cd crud-ddd
```

### 2. Start SQL Server container

From repository root:

```bash
docker compose up -d
```

This project uses:

- SQL Server image: `mcr.microsoft.com/mssql/server:2019-latest`
- Exposed port: `1433`
- SA password (dev only): `Password123!`

### 3. Apply EF Core migrations

From `API_DDD` directory:

```bash
dotnet ef database update --project Infrastructure --startup-project WebAPIs
```

If `dotnet ef` is not available:

```bash
dotnet tool install --global dotnet-ef
```

### 4. Run the API

From `API_DDD/WebAPIs`:

```bash
dotnet run
```

Default local URLs (from launch settings):

- `https://localhost:7024`
- `http://localhost:5160`

Swagger UI:

- `https://localhost:7024/swagger`
- `http://localhost:5160/swagger`

## Example Calls (curl)

Create user:

```bash
curl -X POST "http://localhost:5160/api/users" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "John Doe",
    "email": "john.doe@example.com",
    "phones": [
      { "ddd": "11", "number": "999999999", "type": 2 }
    ]
  }'
```

List users:

```bash
curl "http://localhost:5160/api/users?pageNumber=1&pageSize=10"
```

Search by phone:

```bash
curl "http://localhost:5160/api/users/SearchByPhoneNumber?phoneNumber=999999999&ddd=11"
```

Update email:

```bash
curl -X PUT "http://localhost:5160/api/users/1/update-email" \
  -H "Content-Type: application/json" \
  -d '{ "newEmail": "john.new@example.com" }'
```

Update phone:

```bash
curl -X PATCH "http://localhost:5160/api/users/1/update-phone/1" \
  -H "Content-Type: application/json" \
  -d '{ "newPhone": "988887777", "ddd": "11" }'
```

Delete by email:

```bash
curl -X DELETE "http://localhost:5160/api/users/delete-by-email?email=john.new@example.com"
```

## Testing

From `API_DDD`:

```bash
dotnet test
```

Note: test project includes MSTest + Moq setup for controller/service interactions.

## Troubleshooting

- No .NET SDK found:
  - Install .NET 6 SDK and re-run commands.
- SQL connection error on startup:
  - Confirm container is running: `docker ps`
  - Confirm SQL port `1433` is available.
- Database name mismatch:
  - `WebAPIs/appsettings.json` uses `ClientManager`, while `setup.sql` creates `Test`.
  - Prefer keeping a single DB name across both files (recommended: `ClientManager`).
- Migrations command fails:
  - Ensure you are inside `API_DDD` and EF tool is installed (`dotnet-ef`).

## Security Note

Current credentials and connection string are development defaults and must not be used in production. For production-like setups, move secrets to environment variables or a secret manager.

## Roadmap (Suggested)

- Add global exception middleware with standardized error contracts
- Add FluentValidation for richer input validation
- Add integration tests with isolated test database
- Add CI pipeline (build, test, static analysis)
- Add authentication/authorization
