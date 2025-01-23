# User Management Web API

## Overview
The **User Management Web API** is a scalable and modular ASP.Net Core application designed for managing users efficiently. The project follows best practices for architecture and coding conventions, making it ideal for extensibility and integration with other systems.

---

## Features
- JWT Authentication for secure access.
- Modular architecture with Controllers, Services, and Middlewares.
- Configurable settings via `appsettings.json`.
- Structured directory for better maintainability.
- Ready-to-use API endpoints for user management.

---

## Installation

### Prerequisites
- .NET SDK 6.0 (or later)
- Visual Studio 2022 or Visual Studio Code
- Git for cloning the repository (optional)

### Steps to Set Up
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/UserManagmentWebAPI.git
   ```
2. Navigate to the project directory:
   ```bash
   cd UserManagmentWebAPI
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Build the project:
   ```bash
   dotnet build
   ```
5. Run the project:
   ```bash
   dotnet run
   ```

---

## Usage

### API Endpoints
Here is a list of available endpoints:

#### Authentication
- **`POST /api/Auth/Login`**: Authenticates a user and returns a JWT token.

#### User Management
- **`GET /api/Users`**: Fetches a list of all users.
- **`GET /api/Users/{id}`**: Fetches details of a specific user by ID.
- **`POST /api/Users`**: Creates a new user.
- **`PUT /api/Users/{id}`**: Updates an existing user.
- **`DELETE /api/Users/{id}`**: Deletes a user by ID.

#### Example Request
```bash
curl -X GET https://localhost:5001/api/Users
```

---

## Configuration
All configuration settings are located in `appsettings.json` and `appsettings.Development.json`. Key sections include:

```json
{
  "JwtSettings": {
    "SecretKey": "YourSecretKeyHere",
    "Issuer": "yourdomain.com",
    "Audience": "yourdomain.com"
  },
  "ConnectionStrings": {
    "DefaultConnection": "YourDatabaseConnectionStringHere"
  }
}
```

Update these values according to your environment.

---

## Project Structure
The project is organized as follows:

```
📦 UserManagmentWebAPI
 ┣ 📂Controllers
 ┃ ┗ 📄UserController.cs
 ┣ 📂Middlewares
 ┃ ┗ 📄CustomMiddleware.cs
 ┣ 📂Models
 ┃ ┗ 📄User.cs
 ┣ 📂Services
 ┃ ┗ 📄UserService.cs
 ┣ 📂Properties
 ┣ 📄Program.cs
 ┣ 📄appsettings.json
 ┣ 📄appsettings.Development.json
 ┣ 📄UserManagmentWebAPI.csproj
 ┣ 📄UserManagmentWebAPI.sln
```

### Key Directories
- **Controllers**: Contains API controllers for handling HTTP requests.
- **Middlewares**: Custom middleware components for request/response pipeline.
- **Models**: Data models representing the database structure.
- **Services**: Business logic and data access layer.

---

## Contributing
We welcome contributions! Follow these steps to contribute:
1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes:
   ```bash
   git commit -m "Add some feature"
   ```
4. Push to the branch:
   ```bash
   git push origin feature-name
   ```
5. Open a pull request.

---

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## Contact
- **Author**: [Mohamadreza Saliminia](https://github.com/Saliminia)
- **Email**: Saliminia@zoho.com

