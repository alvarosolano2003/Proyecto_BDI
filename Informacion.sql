USE master;

USE swati
GO

INSERT INTO [dbo].Cargo_Empleado(Puesto, Salario)
VALUES('Analista de Sistemas', 1000)

INSERT INTO [dbo].Cargo_Empleado(Puesto, Salario)
VALUES('Desarrollador de SIstemas', 500)

INSERT INTO [dbo].Cargo_Empleado(Puesto, Salario)
VALUES('Jefe de Proyecto', 20000)

SELECT * FROM [dbo].Cargo_Empleado

DELETE FROM [dbo].Cargo_Empleado

DELETE FROM [dbo].Empleado

DELETE FROM [dbo].Seguridad_Social_Empleado


INSERT INTO [dbo].Empleado(Codigo_Empleado, Cedula_Identidad, Codigo_Inss, Nombres, Apellidos, Cargo_Empleado_Id, Salario_Bruto)
VALUES('24S', '2021-0911U', '1002S', 'Alvaro', 'Solano', N'13DA4336-4689-41F1-BB3A-18283071677E', 1000)

INSERT INTO [dbo].Empleado(Codigo_Empleado, Cedula_Identidad, Codigo_Inss, Nombres, Apellidos, Cargo_Empleado_Id, Salario_Bruto)
VALUES('25S', '2021-1014U', '4567H', 'Neyli', 'Madriz', N'B05A1058-ED26-4FE3-9A28-5C384100BA25', 1000)

INSERT INTO [dbo].Empleado(Codigo_Empleado, Cedula_Identidad, Codigo_Inss, Nombres, Apellidos, Cargo_Empleado_Id, Salario_Bruto)
VALUES('26S', '2022-1034U', '745G', 'Francisco', 'Ramirez', N'C6EE251F-FFD7-4FF2-8F8C-9AD9D13FF48F', 1000)

INSERT INTO [dbo].Empleado(Codigo_Empleado, Cedula_Identidad, Codigo_Inss, Nombres, Apellidos, Cargo_Empleado_Id, Salario_Bruto)
VALUES('27S', '2022-1098U', '438L', 'Eduardo', 'Gonzales', N'C6EE251F-FFD7-4FF2-8F8C-9AD9D13FF48F', 9000)

INSERT INTO [dbo].Horas_Extras_Empleado(Pago_Por_Hora, Concepto, Inicio_Laboral, Finalizacion_Laboral, Empleado_Id)
VALUES(5, 'Horas extras de Octubre', 2022-9-15, GETDATE(), N'2F669562-EA1B-4BE9-A3EE-DC3C60E99B64')
GO

SELECT * FROM [dbo].Empleado
GO

SELECT * FROM [dbo].Seguridad_Social_Empleado

SELECT * FROM [dbo].Horas_Extras_Empleado