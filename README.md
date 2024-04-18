# API with MSSQL DB in ASP.NET

- [x] Model View Controller
- [x] CRUD operations
- [X] Microsoft SQL Server  

## Installation

```bash
git clone https://github.com/fraxxio/ASP.NET_API.git

cd ASP.NET_API

dotnet restore

dotnet build
```

## Start SQL server

```bash
sa_password = "Password"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

## Set connection string to secret manager

```bash
sa_password = "Password"
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost; Database=cineradar; User Id=sa; Password=$sa_password; TrustServerCertificate=true;"
```
