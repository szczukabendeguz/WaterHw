# Water Level Monitoring System

A comprehensive water level tracking and management system built with .NET 8, featuring a RESTful API backend and a data import client application.

## 📋 Project Description

This application provides a complete solution for monitoring and managing water level data over time. The system follows clean architecture principles with clear separation of concerns across multiple layers (API, Business Logic, Data Access, and Entities). It includes JWT-based authentication for secure access and supports bulk data import from JSON files.

## 🛠️ Tech Stack

[![Tech Stack](https://skillicons.dev/icons?i=dotnet,cs,visualstudio)](https://skillicons.dev)

**Framework:** .NET 8  
**Database:** SQL Server (Entity Framework Core)  
**Authentication:** JWT Bearer Tokens  
**ORM:** Entity Framework Core 8.0.8  
**API Documentation:** Swagger/OpenAPI  
**Additional Libraries:** AutoMapper, ASP.NET Core Identity

## 🏗️ Architecture

The solution is organized into the following projects:

- **Water.Endpoint** - ASP.NET Core Web API with controllers and authentication
- **Water.Logic** - Business logic layer containing service implementations
- **Water.Data** - Data access layer with Entity Framework Core context and repositories
- **Water.Entities** - Domain models, DTOs, and helper classes
- **WaterLevelClient** - Console application for importing water level data from JSON files

## 🚀 Getting Started

### Prerequisites

- .NET 8 SDK or later
- SQL Server (LocalDB, Express, or Full Edition)
- Visual Studio 2022 or JetBrains Rider (recommended)

### Installation & Execution

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd WaterHw
   ```

2. **Configure the database connection:**
   
   Update the connection string in `MovieClub.Endpoint/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=WaterLevelDb;Trusted_Connection=True;"
   }
   ```

3. **Apply database migrations:**
   ```bash
   cd MovieClub.Endpoint
   dotnet ef database update
   ```

4. **Run the API:**
   ```bash
   dotnet run --project MovieClub.Endpoint/Water.Endpoint.csproj
   ```
   
   The API will be available at `https://localhost:7265` (or the port specified in `launchSettings.json`)

5. **Access Swagger UI:**
   
   Navigate to `https://localhost:7265/swagger` to explore and test the API endpoints

### Using the Data Import Client

The `WaterLevelClient` console application allows you to bulk import water level data from JSON files.

1. **Prepare your data file:**
   
   Create a JSON file with the following structure:
   ```json
   [
     {
       "date": "2024.01.15",
       "value": 125
     },
     {
       "date": "2024.01.16",
       "value": 130
     }
   ]
   ```

2. **Update the file path:**
   
   Edit `WaterLevelClient/Program.cs` and update line 36:
   ```csharp
   string filePath = "C:\\path\\to\\your\\water_level_data.json";
   ```

3. **Ensure the API is running**, then execute:
   ```bash
   dotnet run --project WaterLevelClient/WaterLevelClient.csproj
   ```

## 📊 Input Data Structure

### Water Level JSON Format

The import client expects JSON files with the following schema:

```json
[
  {
    "date": "yyyy.MM.dd",
    "value": integer
  }
]
```

**Field Descriptions:**
- `date` (string, required): Date in `yyyy.MM.dd` format (e.g., "2024.01.15")
- `value` (integer, required): Water level measurement value

**Example:**
```json
[
  {
    "date": "2024.01.15",
    "value": 125
  },
  {
    "date": "2024.01.16",
    "value": 130
  },
  {
    "date": "2024.01.17",
    "value": 128
  }
]
```

## 🔐 Authentication

The API uses JWT Bearer token authentication. To access protected endpoints:

1. Register a new user or login via the `/api/User` endpoints
2. Include the received JWT token in subsequent requests:
   ```
   Authorization: Bearer <your-token>
   ```

## 📡 API Endpoints

- **Water Level Management:**
  - `GET /api/WaterLevel` - Retrieve all water level records
  - `GET /api/WaterLevel/{id}` - Get specific water level record
  - `POST /api/WaterLevel/data` - Create new water level record
  - `PUT /api/WaterLevel/{id}` - Update existing record
  - `DELETE /api/WaterLevel/{id}` - Delete record

- **User Management:**
  - `POST /api/User/register` - Register new user
  - `POST /api/User/login` - Authenticate user

---

# Vízszint Monitoring Rendszer

Egy átfogó vízszint nyomon követő és kezelő rendszer .NET 8 alapokon, RESTful API backenddel és adat import kliens alkalmazással.

## 📋 Projekt Leírás

Ez az alkalmazás komplett megoldást nyújt vízszint adatok időbeli monitorozására és kezelésére. A rendszer clean architecture elveket követ, világos szétválasztással a különböző rétegek között (API, Business Logic, Data Access és Entities). JWT-alapú authentikációt tartalmaz a biztonságos hozzáféréshez, és támogatja a tömeges adatimportot JSON fájlokból.

## 🛠️ Tech Stack

[![Tech Stack](https://skillicons.dev/icons?i=dotnet,cs,visualstudio)](https://skillicons.dev)

**Framework:** .NET 8  
**Database:** SQL Server (Entity Framework Core)  
**Authentication:** JWT Bearer Tokens  
**ORM:** Entity Framework Core 8.0.8  
**API Dokumentáció:** Swagger/OpenAPI  
**További Library-k:** AutoMapper, ASP.NET Core Identity

## 🏗️ Architektúra

A solution a következő projektekre tagolódik:

- **Water.Endpoint** - ASP.NET Core Web API controllerekkel és authentikációval
- **Water.Logic** - Business logic réteg service implementációkkal
- **Water.Data** - Data access réteg Entity Framework Core context-tel és repository-kkal
- **Water.Entities** - Domain modellek, DTO-k és helper osztályok
- **WaterLevelClient** - Console alkalmazás vízszint adatok JSON fájlokból való importálásához

## 🚀 Getting Started

### Előfeltételek

- .NET 8 SDK vagy újabb
- SQL Server (LocalDB, Express vagy Full Edition)
- Visual Studio 2022 vagy JetBrains Rider (ajánlott)

### Telepítés és Futtatás

1. **Repository klónozása:**
   ```bash
   git clone <repository-url>
   cd WaterHw
   ```

2. **Database connection konfigurálása:**
   
   Frissítsd a connection stringet a `MovieClub.Endpoint/appsettings.json` fájlban:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=WaterLevelDb;Trusted_Connection=True;"
   }
   ```

3. **Database migration-ök alkalmazása:**
   ```bash
   cd MovieClub.Endpoint
   dotnet ef database update
   ```

4. **API futtatása:**
   ```bash
   dotnet run --project MovieClub.Endpoint/Water.Endpoint.csproj
   ```
   
   Az API elérhető lesz a `https://localhost:7265` címen (vagy a `launchSettings.json`-ben megadott porton)

5. **Swagger UI elérése:**
   
   Navigálj a `https://localhost:7265/swagger` címre az API endpoint-ok felfedezéséhez és teszteléséhez

### Data Import Client Használata

A `WaterLevelClient` console alkalmazás lehetővé teszi vízszint adatok tömeges importálását JSON fájlokból.

1. **Adat fájl előkészítése:**
   
   Hozz létre egy JSON fájlt a következő struktúrával:
   ```json
   [
     {
       "date": "2024.01.15",
       "value": 125
     },
     {
       "date": "2024.01.16",
       "value": 130
     }
   ]
   ```

2. **Fájl elérési út frissítése:**
   
   Szerkeszd a `WaterLevelClient/Program.cs` fájlt és frissítsd a 36. sort:
   ```csharp
   string filePath = "C:\\elérési\\út\\a\\water_level_data.json";
   ```

3. **Győződj meg róla, hogy az API fut**, majd futtasd:
   ```bash
   dotnet run --project WaterLevelClient/WaterLevelClient.csproj
   ```

## 📊 Input Adat Struktúra

### Vízszint JSON Formátum

Az import client a következő sémájú JSON fájlokat várja:

```json
[
  {
    "date": "yyyy.MM.dd",
    "value": integer
  }
]
```

**Mező Leírások:**
- `date` (string, kötelező): Dátum `yyyy.MM.dd` formátumban (pl. "2024.01.15")
- `value` (integer, kötelező): Vízszint mérési érték

**Példa:**
```json
[
  {
    "date": "2024.01.15",
    "value": 125
  },
  {
    "date": "2024.01.16",
    "value": 130
  },
  {
    "date": "2024.01.17",
    "value": 128
  }
]
```

## 🔐 Authentication

Az API JWT Bearer token authentikációt használ. A védett endpoint-ok eléréséhez:

1. Regisztrálj új usert vagy jelentkezz be a `/api/User` endpoint-okon keresztül
2. Csatold a kapott JWT tokent a későbbi requestekhez:
   ```
   Authorization: Bearer <your-token>
   ```

## 📡 API Endpoint-ok

- **Vízszint Kezelés:**
  - `GET /api/WaterLevel` - Összes vízszint rekord lekérése
  - `GET /api/WaterLevel/{id}` - Adott vízszint rekord lekérése
  - `POST /api/WaterLevel/data` - Új vízszint rekord létrehozása
  - `PUT /api/WaterLevel/{id}` - Meglévő rekord frissítése
  - `DELETE /api/WaterLevel/{id}` - Rekord törlése

- **User Kezelés:**
  - `POST /api/User/register` - Új user regisztrálása
  - `POST /api/User/login` - User authentikáció
