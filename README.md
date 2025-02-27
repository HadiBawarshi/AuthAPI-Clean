# AuthAPI-Clean

## Overview
AuthAPI-Clean is an authentication Web API built using ASP.NET 6 and SQL Server (MSSQL). It provides a login API that authenticates users using JWT tokens and ASP.NET Identity. This project follows best practices in security and architecture while remaining simple and easy to set up.

## Technologies Used
- **Backend**: ASP.NET 6 (C#)
- **Architecture**: Clean Architecture, following SOLID principles
- **Design Patterns**: CQRS (Command Query Responsibility Segregation) with MediatR , Repository Pattern
- **Database**: SQL Server (MSSQL)
- **ORM**: Entity Framework Core
- **Authentication**: ASP.NET Identity with JWT tokens
- **Validation**: FluentValidation for request validation
- **Mapping**: AutoMapper for object mapping
- **Hosting**: SmarterASP.NET (for testing purposes)

## Features
- Secure authentication using JWT tokens
- ASP.NET Identity integration
- CQRS pattern with MediatR
- Fluent validation for request handling
- AutoMapper for DTO mapping
- Online and local database support
- Configurable CORS (Cross-Origin Resource Sharing) settings
- Global exception handling
- Simple logging

## API Endpoints
### Authentication
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/Auth` | Authenticates a user and returns a JWT token |

## Running the Project
### Prerequisites
- .NET 6 SDK
- SQL Server (if using local database)
- Visual Studio 2022 or any .NET-compatible IDE

### Setup Steps
#### 1. Clone the Repository
```sh
git clone <repository-url>
cd AuthAPI-Clean
```

#### 2. Running with Online Database
- Select `Auth.API` as the startup project in Visual Studio.
- In the `appsettings.json` the database is set to the online db by default.
- Run the project.

#### 3. Running with Local Database
- The database script and backup are available in the `Resources` folder within the solution.
- Choose one of the following:
  - Restore the database from the backup.
  - Create a new database named `AuthDb`, then run the provided SQL script to set up the schema and initial data.
- Select `Auth.API` as the startup project in Visual Studio.
- Update the `DefaultConnection` in the `appsettings.json` set your local server name or `.` , make sure the `Database` is AuthDb.
- Run the project.

### Backend Port Configuration
- Default backend port: **5074**
- To change the port:
  - Navigate to `Properties` → `launchSettings.json`
  - Under `profiles`, locate `Auth.API`.
  - Update the `applicationUrl` property with the desired port.

## Deployment
- The backend is deployed on **SmarterASP.NET** for quick testing.
- CORS settings are configured to allow all origins (`AllowAllOrigins`), as this is not a production-ready solution.
- No Docker setup is included since this is a single microservice.

## Notes
- No database migrations or data seeding are needed, as the provided database already contains the required data.
- The project is meant for demonstration and testing purposes, not for production use.

## License
This project is open-source and can be modified as needed.

## Author
Hadi Bawarshi

