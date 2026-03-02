
# CourseOps API

Production-style RESTful backend API for a Course Management system built with **.NET 8**, **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**.

This API powers the `course-management-angular` frontend application and demonstrates modern backend architecture patterns, REST best practices, and production-ready infrastructure.

---

## Tech Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core (Code First)
- SQL Server
- Serilog (Structured Logging)
- Swagger / OpenAPI

---

## Architecture Highlights

This project goes beyond basic CRUD and demonstrates production-oriented backend design.

### Data Layer
- EF Core Fluent API configuration
- Composite key configuration (`CourseInstructor`)
- DTO layer for API shaping
- Soft deletes via `IsActive`
- Optimistic concurrency control using `RowVersion`
- Server-side pagination and filtering
- Aggregate dashboard queries without N+1 issues

### API Design
- Proper REST status codes (201, 404, 409, etc.)
- Clean separation of concerns
- Repository pattern vs direct `DbContext` comparison
- Standardized error responses
- Async-first implementation

### Infrastructure
- Global exception handling middleware
- Structured logging with Serilog
- Request tracing
- Restricted CORS configuration
- Swagger documentation

---

## API Endpoints

### Courses

- `GET /api/courses`  
  Supports pagination and filtering.

- `GET /api/courses/{id}`  
  Returns a single course.

- `POST /api/courses`  
  Creates a new course (201 Created).

- `PUT /api/courses/{id}`  
  Updates a course with concurrency handling.

- `DELETE /api/courses/{id}`  
  Soft delete (sets `IsActive = false`).

---

### Dashboard

- `GET /api/dashboard`

Returns aggregated KPIs:

- `TotalStudents`
- `ActiveCourses`
- `TotalEnrollments`
- `ActiveInstructors`

All queries are optimized and avoid N+1 issues.

---

## Repository vs Direct DbContext Evaluation

This project intentionally demonstrates both patterns to evaluate architectural tradeoffs.

### Repository Pattern (Used for Dashboard + Courses list)

**Pros**
- Encapsulates data access logic
- Improves testability
- Separates concerns

**Cons**
- Adds abstraction
- Can introduce boilerplate for simple CRUD
- EF Core already behaves like a repository/unit-of-work

### Direct DbContext (Used in other endpoints)

**Pros**
- Simpler
- Less indirection
- Leverages full EF Core power

**Cons**
- Tighter coupling to EF
- Harder to mock without abstraction

This comparison demonstrates architectural depth rather than blind pattern usage.

---

## CORS Configuration

CORS is restricted to the Angular development server:

http://localhost:4200

No wildcard origins are allowed.

---

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server (LocalDB, Express, or Developer Edition)

---

### Configure Database

Update the connection string in `appsettings.json`:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CourseOpsDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;"
  }
}

---

### Apply Migrations

dotnet ef database update

---

### Run the API

dotnet run --project CourseOps.Api

---

### Swagger

After running the API, navigate to:

https://localhost:5001/swagger

---

## Observability

Logging is implemented using **Serilog**:

- Structured logs
- Request logging
- File sink
- Console sink
- Exception logging via middleware

---

## Future Enhancements

- Authentication & authorization (JWT)
- Role-based access control
- Unit and integration testing
- CI/CD pipeline
- Production logging sinks (Seq / Elastic)
- API versioning

---

## Project Purpose

This project demonstrates:

- Clean REST API design
- Concurrency handling
- Soft delete patterns
- Server-side pagination
- Structured logging
- Middleware-driven error handling
- Architectural tradeoff evaluation
- Production-oriented backend practices

It is intended as a portfolio-quality backend service that reflects modern ASP.NET Core engineering standards.
