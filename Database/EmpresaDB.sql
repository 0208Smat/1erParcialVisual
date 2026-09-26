IF DB_ID('EmpresaDB') IS NULL
BEGIN
    CREATE DATABASE EmpresaDB;
END
GO

USE EmpresaDB;
GO

IF OBJECT_ID('dbo.Clientes', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Clientes
    (
        Id INT IDENTITY(1,1) NOT NULL,
        Nombre VARCHAR(100) NOT NULL,
        Apellido VARCHAR(100) NOT NULL,
        Email VARCHAR(150) NOT NULL,
        Telefono VARCHAR(30) NOT NULL,
        CONSTRAINT PK_Clientes PRIMARY KEY (Id)
    );
END
GO

-- Datos opcionales para probar el CRUD.
IF NOT EXISTS (SELECT 1 FROM dbo.Clientes)
BEGIN
    INSERT INTO dbo.Clientes (Nombre, Apellido, Email, Telefono)
    VALUES
        ('Juan', 'Perez', 'juan.perez@email.com', '0981123456'),
        ('Maria', 'Gomez', 'maria.gomez@email.com', '0982123456');
END
GO
