# Notes API

RESTful API for creating and managing personal notes with user authentication and authorization.

Each note is linked to a specific user. Users can only access, edit, and delete their own notes.

## Features

- User registration
- User login
- JWT authentication
- Authorization
- Create notes
- Get user's notes
- Get note by ID
- Update notes
- Delete notes
- SQLite database
- Entity Framework Core
- Swagger / OpenAPI
- User-to-notes relationship

## Technologies

- **C#**
- **.NET 10**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQLite**
- **JWT Bearer Authentication**
- **Swagger / OpenAPI**

## Project Structure

```text
Notes API/
│
├── Controllers/
│   ├── AuthController.cs
│   └── NotesController.cs
│
├── Database/
│   └── AppDbContext.cs
│
├── Entities/
│   ├── User.cs
│   └── Note.cs
│
├── Interfaces/
│   ├── IAuthService.cs
│   ├── INoteService.cs
│   └── IUserService.cs
│
├── Models/
│   ├── Request/
│   │   ├── EditNoteRequest.cs
│   │   └── RegisterDTO.cs
│   └── ...
│
├── Services/
│   ├── AuthService.cs
│   ├── NoteService.cs
│   └── UserService.cs
│
├── Migrations/
│
├── appsettings.json
├── Program.cs
└── Notes API.csproj
