# Data Storage – Backend

ASP.NET Core Minimal API | DDD | Clean Architecture | EF Core

## EduCraft System Manager

This project was developed in C# and .NET as part of the course **Data Storage**.
_The system models an Educational Management System for:_

- Courses
- Course instances
- Instructors
- Students
- Course registrations

A separate frontend application is used to interact with the API and demonstrate functionality.

Frontend repository:  
https://github.com/Zileena6/datalagring-frontend-linda-leminaho

---

## Architecture

_The solution is built according to:_

- Domain-Driven Design (DDD)
- Clean Architecture

_The project is structured into the following layers:_

#### The Presentation layer

- ASP.NET Core Minimal API
- Defines endpoints and HTTP contracts
- Responsible only for request/response handling

#### The Application layer

- Use cases
- Application logic
- DTOs
- Services
- Interfaces

#### The Domain layer

- Entities
- Value Objects
- Aggregates
- Business rules

#### The Infrastructure layer

- Entity Framework Core
- DbContext configuration
- Repository implementations
- Database migrations

#### The Tests project

- Unit tests / Integration tests
- Verifies application behavior

---

## Database

The system uses a relational database with Entity Framework Core using the Code First approach.

The database stores information such as:

- Courses
- Course instances
- Participants
- Course registrations

Entity Framework Core manages the database schema and relationships.

---

## API

The backend is implemented as an ASP.NET Core Minimal API.

The API handles:

- Creating data
- Retrieving data
- Updating records
- Deleting records

The backend is responsible for all business logic and database communication.

---

## Running the Project

### Requirements

- .NET SDK 8 or later
- SQL Server LocalDB
- Git

---

### Clone repository

```
git clone https://github.com/Zileena6/datalagring-linda-leminaho.git
cd datalagring-linda-leminaho
```

---

### Run database migration

```
dotnet ef database update --project EduCraft.Infrastructure --startup-project EduCraft.Presentation
```

---

### Run the API

```
dotnet run --project EduCraft.Presentation
```

The API will start locally on a localhost port.

---

## Running Tests

```
dotnet test
```

Tests verify that the system works correctly.

---

## Technologies Used

Backend:

- C#
- .NET
- ASP.NET Core Minimal API
- Entity Framework Core
- SQL Server
- Clean Architecture
- Domain-Driven Design

---

## Author

Linda Leminaho  
https://github.com/Zileena6
