# EmpresaApiVB

API REST desarrollada en **Visual Basic .NET / ASP.NET Core Web API** para administrar clientes de una empresa mediante operaciones CRUD y persistencia en SQL Server.

## Tecnologías

- Visual Basic .NET
- ASP.NET Core Web API
- .NET 8
- Entity Framework Core 8
- SQL Server
- Swagger / OpenAPI
- Repository Pattern
- Service Layer
- Inyección de Dependencias

## Estructura

```text
EmpresaApiVB/
├── Controllers/
│   └── ClientesController.vb
├── Data/
│   └── EmpresaDbContext.vb
├── Models/
│   └── Cliente.vb
├── Repositories/
│   ├── IClienteRepository.vb
│   └── ClienteRepository.vb
├── Services/
│   ├── IClienteService.vb
│   └── ClienteService.vb
├── Database/
│   └── EmpresaDB.sql
├── Properties/
│   └── launchSettings.json
├── EmpresaApiVB.vbproj
├── EmpresaApiVB.sln
├── EmpresaApiVB.http
├── Program.vb
├── appsettings.json
└── README.md
```

El flujo solicitado por el examen es:

```text
Controller
    ↓
Service
    ↓
Repository
    ↓
Entity Framework Core
    ↓
SQL Server
```

## 1. Crear la base de datos

Abrir SQL Server Management Studio y ejecutar:

`Database/EmpresaDB.sql`

El script crea:

- Base de datos `EmpresaDB`.
- Tabla `Clientes`.
- `Id` como `INT IDENTITY` y clave primaria.
- `Nombre VARCHAR(100)`.
- `Apellido VARCHAR(100)`.
- `Email VARCHAR(150)`.
- `Telefono VARCHAR(30)`.

## 2. Configurar SQL Server

La conexión por defecto está en `appsettings.json`:

```text
Server=localhost;Database=EmpresaDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True
```

Si SQL Server está en otra instancia, modificar solamente `Server`.

Ejemplo para SQL Server Express:

```text
Server=.\SQLEXPRESS;Database=EmpresaDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True
```

## 3. Abrir en Visual Studio

Abrir `EmpresaApiVB.sln` en Visual Studio 18.9.0.

Restaurar los paquetes NuGet y ejecutar el proyecto.

Swagger se abrirá en:

```text
https://localhost:7180/swagger
```

o mediante la URL HTTP:

```text
http://localhost:5180/swagger
```

## 4. Endpoints

| Método | Endpoint | Descripción |
|---|---|---|
| GET | `/api/clientes` | Consulta todos los clientes |
| GET | `/api/clientes/{id}` | Consulta un cliente por ID |
| POST | `/api/clientes` | Registra un cliente |
| PUT | `/api/clientes/{id}` | Modifica un cliente |
| DELETE | `/api/clientes/{id}` | Elimina un cliente |

### POST /api/clientes

```json
{
  "nombre": "Carlos",
  "apellido": "Benitez",
  "email": "carlos.benitez@email.com",
  "telefono": "0983123456"
}
```

### PUT /api/clientes/1

```json
{
  "nombre": "Juan Carlos",
  "apellido": "Perez",
  "email": "juan.carlos@email.com",
  "telefono": "0981999999"
}
```

## 5. Inyección de Dependencias

Las dependencias se registran en `Program.vb`:

- `EmpresaDbContext` como `Scoped`.
- `IClienteRepository` → `ClienteRepository` como `Scoped`.
- `IClienteService` → `ClienteService` como `Scoped`.

El Controller recibe `IClienteService` por constructor y no crea manualmente ninguna dependencia.

## 6. Pruebas

El archivo `EmpresaApiVB.http` contiene solicitudes para probar las cinco operaciones CRUD desde Visual Studio.

También se puede utilizar Swagger para ejecutar las solicitudes directamente desde el navegador.

## 7. Relación con la consigna

La solución separa las responsabilidades en `Controllers`, `Services`, `Repositories`, `Models` y `Data`, utiliza Entity Framework Core para la persistencia y SQL Server como base de datos.
