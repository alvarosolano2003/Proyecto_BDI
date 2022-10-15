USE master;

USE swati
GO

ALTER TRIGGER [dbo].tr_CalculateSalary
ON Empleado
FOR INSERT
AS
BEGIN
	DECLARE @idAux AS uniqueidentifier
	SELECT @idAux = Id FROM Empleado WHERE CreadoEn = (SELECT MAX(CreadoEn) FROM Empleado)

	DECLARE @aux AS uniqueidentifier
	SELECT @aux = Cargo_Empleado_Id FROM [dbo].Empleado WHERE CreadoEn = (SELECT MAX(CreadoEn) FROM Empleado)

	DECLARE @SalarioEmp AS MONEY
	SELECT @SalarioEmp = Salario FROM [dbo].Cargo_Empleado WHERE Id = @aux;

	DECLARE @Inss MONEY = (@SalarioEmp * 0.07)
	DECLARE @InssPatronal MONEY = (@SalarioEmp * 0.215)
	DECLARE @SalarioAux MONEY = (@SalarioEmp - @Inss) * 12
	
	DECLARE @Ir AS MONEY
	IF (@SalarioAux < 100000) SET @Ir = 0
	IF (@SalarioAux > 100000 AND @SalarioAux < 200000) SET @Ir = ((@SalarioAux - 100000) * 0.15) / 12
	IF (@SalarioAux > 200000 AND @SalarioAux < 350000) SET @Ir = (((@SalarioAux - 200000) * 0.20) + 15000) / 12
	IF (@SalarioAux > 350000 AND @SalarioAux < 500000) SET @Ir = (((@SalarioAux - 350000) * 0.25) + 45000) / 12
	IF (@SalarioAux > 500000) SET @Ir = (((@SalarioAux - 500000) * 0.30) + 82000) / 12

	INSERT INTO [dbo].Seguridad_Social_Empleado(Deduccion_Base, Deduccion_IR, Pago_Patronal, Empleado_Id) 
	VALUES(@Inss, @Ir, @InssPatronal, @idAux)

	DECLARE @SalarioBruto AS MONEY
	SET @SalarioBruto = @SalarioEmp - @Ir - @Inss

	UPDATE [dbo].Empleado
	SET Salario_Bruto = @SalarioBruto
	WHERE Id = @idAux


END
GO

ALTER TRIGGER [dbo].tr_CalculateHorasExtra
ON Horas_Extras_Empleado
FOR INSERT
AS
BEGIN
	DECLARE @idAux AS uniqueidentifier
	SELECT @idAux = Empleado_Id FROM Horas_Extras_Empleado WHERE CreadoEn = (SELECT MAX(CreadoEn) FROM Horas_Extras_Empleado)

	DECLARE @aux AS uniqueidentifier
	SELECT @aux = Cargo_Empleado_Id FROM [dbo].Empleado WHERE Id = @idAux

	DECLARE @NHoras AS INT
	SELECT @NHoras = DAY(Inicio_Laboral) - DAY(Finalizacion_Laboral) FROM Horas_Extras_Empleado

	DECLARE @PagoHorasExtra AS FLOAT
	SELECT @PagoHorasExtra = Pago_Por_Hora FROM Horas_Extras_Empleado

	DECLARE @SalarioEmp AS MONEY
	SELECT @SalarioEmp = Salario FROM [dbo].Cargo_Empleado WHERE Id = @aux;
	SET @SalarioEmp = @SalarioEmp + (@PagoHorasExtra * 2 * @NHoras)

	DECLARE @Inss MONEY = (@SalarioEmp * 0.07)
	DECLARE @InssPatronal MONEY = (@SalarioEmp * 0.215)
	DECLARE @SalarioAux MONEY = (@SalarioEmp - @Inss) * 12
	
	DECLARE @Ir AS MONEY
	IF (@SalarioAux < 100000) SET @Ir = 0
	IF (@SalarioAux > 100000 AND @SalarioAux < 200000) SET @Ir = ((@SalarioAux - 100000) * 0.15) / 12
	IF (@SalarioAux > 200000 AND @SalarioAux < 350000) SET @Ir = (((@SalarioAux - 200000) * 0.20) + 15000) / 12
	IF (@SalarioAux > 350000 AND @SalarioAux < 500000) SET @Ir = (((@SalarioAux - 350000) * 0.25) + 45000) / 12
	IF (@SalarioAux > 500000) SET @Ir = (((@SalarioAux - 500000) * 0.30) + 82000) / 12

	UPDATE [dbo].Seguridad_Social_Empleado
	SET Deduccion_Base = @Inss, Deduccion_IR = @Ir, Pago_Patronal = @InssPatronal
	WHERE Empleado_Id = @idAux

	DECLARE @SalarioBruto AS MONEY
	SET @SalarioBruto = @SalarioEmp - @Ir - @Inss

	UPDATE [dbo].Empleado
	SET Salario_Bruto = @SalarioBruto
	WHERE Id = @idAux
END
GO

CREATE TRIGGER [dbo].tr_CalculateAntiguedad
ON Antiguedad_Empleado
FOR INSERT
AS
BEGIN
	SELECT Limite_Antiguedad, 
	CASE
		WHEN Limite_Antiguedad = 1 THEN 0.03
		WHEN Limite_Antiguedad = 2 THEN 0.05
		WHEN Limite_Antiguedad = 3 THEN 0.07
		WHEN Limite_Antiguedad = 4 THEN 0.09
		WHEN Limite_Antiguedad = 5 THEN 0.10
		WHEN Limite_Antiguedad = 6 THEN 0.11
		WHEN Limite_Antiguedad = 7 THEN 0.12
		WHEN Limite_Antiguedad = 8 THEN 0.13
		WHEN Limite_Antiguedad = 9 THEN 0.14
		WHEN Limite_Antiguedad = 10 THEN 0.15
		WHEN Limite_Antiguedad = 11 THEN 0.155
		WHEN Limite_Antiguedad = 12 THEN 0.16
		WHEN Limite_Antiguedad = 13 THEN 0.165
		WHEN Limite_Antiguedad = 14 THEN 0.17
		WHEN Limite_Antiguedad = 15 THEN 0.175
		WHEN Limite_Antiguedad = 16 THEN 0.18
		WHEN Limite_Antiguedad = 17 THEN 0.185
		WHEN Limite_Antiguedad = 18 THEN 0.19
		WHEN Limite_Antiguedad = 19 THEN 0.195
		WHEN Limite_Antiguedad = 20 THEN 0.20
	END AS Porcentaje
	FROM [dbo].Antiguedad_Empleado
END
GO


DROP TRIGGER [dbo].tr_CalculateSalary

