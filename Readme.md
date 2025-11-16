# ASP.NET 8 Web API + Azure SQL + JWT Auth

Production-ready starter for a secure Web API:
- **ASP.NET 8** Minimal Hosting model
- **EF Core (SQL Server/Azure SQL)**
- **JWT Authentication** (Issuer/Audience/Key from config)
- **Dockerfile** for containerized deploy
- **GitHub Actions** pipeline

## Quick Start

### 1) Restore & Run
```bash
dotnet restore ./src/Api/Api.csproj
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate -p ./src/Api/Api.csproj -s ./src/Api/Api.csproj
dotnet ef database update -p ./src/Api/Api.csproj -s ./src/Api/Api.csproj
dotnet run --project ./src/Api/Api.csproj
```
API on `https://localhost:7043` (or `http://localhost:5242`), Swagger enabled in Development.

### 2) Configure Secrets
Set **Jwt:Key** and connection string via user-secrets or env vars (recommended for dev):
```bash
dotnet user-secrets set "Jwt:Key" "YOUR_LONG_RANDOM_KEY" --project ./src/Api/Api.csproj
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=(localdb)\\MSSQLLocalDB;Database=AspNet8JwtDb;Trusted_Connection=True;Encrypt=False" --project ./src/Api/Api.csproj
```

**Azure SQL example (replace placeholders):**
```
Server=tcp:<your-server>.database.windows.net,1433;
Database=<your-db>;
User ID=<user>;
Password=<pass>;
Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
```

### 3) Test Endpoints (Swagger or HTTP client)

**Register**
```
POST /api/auth/register
{
  "Email": "demo@contoso.com",
  "Password": "Passw0rd!"
}
```

**Login**
```
POST /api/auth/login
{
  "Email": "demo@contoso.com",
  "Password": "Passw0rd!"
}
```

**Me (authorized)**
```
GET /api/profile/me
Authorization: Bearer <token>
```

### 4) Docker
```bash
docker build -t aspnet8-jwt:local .
docker run -p 8080:8080   -e "ConnectionStrings__DefaultConnection=Server=<...>"   -e "Jwt__Issuer=YourCompany"   -e "Jwt__Audience=YourCompany.Api"   -e "Jwt__Key=YOUR_LONG_RANDOM_KEY"   aspnet8-jwt:local
```

## Notes
- Minimal Identity: we use `PasswordHasher<T>` for secure hashing, not the full ASP.NET Identity UI.
- Add roles/claims easily by extending the `User` model and token creation.

## License
MIT
