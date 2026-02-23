# course-management-api

RESTful backend API for a Course Management system built with .NET 8,
ASP.NET Core Web API, Entity Framework Core, and SQL Server.

This project serves as the backend service for the
`course-management-angular` frontend application.

------------------------------------------------------------------------

## Tech Stack

-   .NET 8
-   ASP.NET Core Web API
-   Entity Framework Core (Code First)
-   SQL Server
-   Swagger / OpenAPI

------------------------------------------------------------------------

## Architecture Overview

-   Domain entities configured using EF Core Fluent API
-   Composite key configured for `CourseInstructor`
-   Navigation properties modeled for relational integrity
-   Enum mapping used for domain state management
-   Initial database schema managed through EF Core migrations

------------------------------------------------------------------------

## Getting Started

### Prerequisites

-   .NET 8 SDK
-   SQL Server (LocalDB, Express, or Developer Edition)

------------------------------------------------------------------------

### Configure Database

Update the connection string in `appsettings.json`:

{ "ConnectionStrings": { "DefaultConnection":
"Server=localhost;Database=CourseOpsDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;"
} }

------------------------------------------------------------------------

### Apply Migrations

dotnet ef database update

------------------------------------------------------------------------

### Run the API

dotnet run --project CourseOps.Api

------------------------------------------------------------------------

### Access Swagger

After the API is running, navigate to:

/swagger

Example:

https://localhost:5001/swagger

------------------------------------------------------------------------

## Related Repository

Frontend application: - course-management-angular

------------------------------------------------------------------------

## Future Enhancements

-   DTO layer for API shaping
-   Authentication and authorization
-   Integration with Angular frontend
-   Validation and error handling middleware
-   Unit and integration testing
