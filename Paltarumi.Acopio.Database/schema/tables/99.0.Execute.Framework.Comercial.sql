USE ICreator
GO

DECLARE @EXECUTE VARCHAR(300)
DECLARE @PARAMETERS VARCHAR(300)
DECLARE @STORED_PROCEDURE VARCHAR(100)

SET @STORED_PROCEDURE = 'USP_CAJA_SELECT_RESUMEN_MOVIMIENTOS'

SET @EXECUTE = 'EXEC Comercial.dbo.usp_Framework_Stored_Parameters ''''dbo'''', ''''' + @STORED_PROCEDURE + ''''''
SET @PARAMETERS = 'EXEC Comercial.dbo.' + @STORED_PROCEDURE + ' NULL, NULL'

EXEC ICreator.dbo.usp_Framework_Generate_Filter_ResultSet 'SERVER-WEB\SQLEXPRESS',
	@EXECUTE,
	@PARAMETERS,
	@STORED_PROCEDURE
GO

/*
EXEC ICreator.dbo.usp_Framework_Generate_Filter_ResultSet 'PCSERVER-DEV\SQLEXPRESS',
	'EXEC Comercial.dbo.usp_Framework_Stored_Parameters ''''dbo'''', ''''USP_INGRESO_SELECT''''',
	'EXEC Comercial.dbo.USP_INGRESO_SELECT NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL',
	'USP_INGRESO_SELECT'
GO
*/

EXEC ICreator.dbo.usp_Framework_Generate_Constant 'SERVER-WEB\SQLEXPRESS', 'EXEC Comercial.dbo.usp_Framework_Stored_List'


EXEC AcopioQA.dbo.usp_Framework_Entity_Bitscom 'Conductor', 'ConductorEn'
EXEC AcopioQA.dbo.usp_Framework_Entity_Bitscom 'OrdenPedidoDetalle', 'OrdenPedidoDetalleEn'
