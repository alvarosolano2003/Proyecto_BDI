USE master;

CREATE DATABASE swati
GO

USE swati
GO

CREATE TABLE [dbo].Cargo_Empleado (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
    Puesto varchar(300) NOT NULL,
    Salario money NOT NULL,
    CONSTRAINT PK_Cargo_Empleado_Id PRIMARY KEY (Id)
);

CREATE TABLE [dbo].Antiguedad_Empleado (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    Concepto VARCHAR(500) NOT NULL,
    Limite_Antiguedad INT NOT NULL,
    Porcentage FLOAT NOT NULL DEFAULT 0,

    CreadoEn DATETIME NOT NULL DEFAULT GETDATE(),
    ActualizadoEn DATETIME NULL,

    CONSTRAINT PK_Antiguedad_Empleado_Id PRIMARY KEY (Id)
);

CREATE TABLE [dbo].Empleado (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    Codigo_Empleado varchar(50) UNIQUE NOT NULL, 
    Cedula_Identidad varchar(100) UNIQUE NOT NULL,
    Codigo_Inss varchar (100) UNIQUE NOT NULL,
    Nombres varchar(400) NOT NULL,
    Apellidos varchar(400) NOT NULL,
    Salario_Bruto MONEY NOT NULL,
    Vacaciones_Acumulados INT NOT NULL DEFAULT 30,
    Cargo_Empleado_Id UNIQUEIDENTIFIER NOT NULL,
    Antiguedad_Empleado_Id UNIQUEIDENTIFIER NULL,

    CreadoEn DATETIME NOT NULL DEFAULT GETDATE(),
    ActualizadoEn DATETIME NULL,

    CONSTRAINT PK_Empleado_Id primary key (Id),
    CONSTRAINT FK_Empleado_Cargo_Empleado_Id FOREIGN KEY (Cargo_Empleado_Id) REFERENCES Cargo_Empleado(Id),
    CONSTRAINT FK_Antiguedad_Empleado_Id FOREIGN KEY (Antiguedad_Empleado_Id) REFERENCES Antiguedad_Empleado(Id)
);

CREATE TABLE [dbo].Horas_Extras_Empleado (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    Pago_Por_Hora FLOAT NOT NULL,
    Concepto TEXT NOT NULL,
    Inicio_Laboral DATETIME NOT NULL DEFAULT GETDATE(),
    Finalizacion_Laboral DATETIME,
    Fecha_Laboral  DATE NOT NULL DEFAULT GETDATE(),
    Empleado_Id UNIQUEIDENTIFIER NOT NULL,

    CreadoEn DATETIME NOT NULL DEFAULT GETDATE(),
    ActualizadoEn DATETIME NULL,

    CONSTRAINT PK_Horas_Extras_Empleado_Id primary key (Id),
    CONSTRAINT FK_Empleado_Id_HE_Empleado FOREIGN KEY (Empleado_Id) REFERENCES Empleado(Id),
);

CREATE TABLE [dbo].Seguridad_Social_Empleado (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    Deduccion_Base MONEY NOT NULL,
    Deduccion_IR MONEY NOT NULL,
    Pago_Patronal MONEY NOT NULL,
    Fecha_Aplicacion_Impuesto DATE NOT NULL DEFAULT GETDATE(),
    Empleado_Id UNIQUEIDENTIFIER NOT NULL,

    CreadoEn DATETIME NOT NULL DEFAULT GETDATE(),
    ActualizadoEn DATETIME NULL,

    CONSTRAINT PK_Seguridad_Social_Empleado_Id primary key (Id),
    CONSTRAINT FK_Seguridad_Social_Empleado_Id FOREIGN KEY (Empleado_Id) REFERENCES Empleado(Id),
);

CREATE TABLE [dbo].Solicitud_Vacaciones_Empleado (
    Id UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    Dias_De_Vacaciones INT NOT NULL,
    Vacaciones_Pagadas MONEY NOT NULL,
    Fecha_Aplicacion DATE NOT NULL DEFAULT GETDATE(),
    Empleado_Id UNIQUEIDENTIFIER NOT NULL,

    CreadoEn DATETIME NOT NULL DEFAULT GETDATE(),
    ActualizadoEn DATETIME NULL,

    CONSTRAINT PK_Solicitud_Vacaciones_Empleado_Id primary key (Id),
    CONSTRAINT FK_Solicitud_Vacaciones_Empleado_Id FOREIGN KEY (Empleado_Id) REFERENCES Empleado(Id),
);
GO

/* ALTER TABLE Empleado ALTER COLUMN Vacaciones_Acumulados SET DEFAULT 2.5;
GO */

/*SELECT
    HorasExtraEmpl.Concepto,
    HorasExtraEmpl.Inicio_Laboral,
    HorasExtraEmpl.Finalizacion_Laboral,
    HorasExtraEmpl.Pago_Por_Hora,
    Empl.Cedula_Identidad,
    Empl.Codigo_Inss,
    Empl.Nombres,
    Empl.Apellidos
FROM [dbo].[Empleado] AS Empl
JOIN [dbo].Horas_Extras_Empleado AS HorasExtraEmpl
ON (Empl.Id = HorasExtraEmpl.Empleado_Id)
WHERE Empl.Id = 'F37D12FF-19CA-420D-90CB-AE2668440F4A' AND HorasExtraEmpl.Fecha_Laboral = '2022-10-05';*/