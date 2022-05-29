USE [AcopioQA]
GO
/*
EXEC usp_Framework_Dto 'Balanza', 'Lote'
*/
IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_Dto'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_Dto
END
GO

CREATE PROCEDURE dbo.usp_Framework_Dto
	@FileMain VARCHAR(80),
	@NameTable VARCHAR(80)
	 
AS	
	DECLARE @name VARCHAR(50)
	DECLARE @tipodato VARCHAR(50)
	DECLARE @parameter VARCHAR(50)
	DECLARE @max_lenght VARCHAR(50)
	DECLARE @precision VARCHAR(20)
	DECLARE @scale VARCHAR(20)
	DECLARE @nulo TINYINT
	
	DECLARE JCursorEntity Scroll Cursor
	
	FOR
	SELECT		SC.name, ISNULL(ATD.dataTypeCSharp, 'NULL')AS tipodato,
				ISNULL(ATD.dbTypeCSharp, 'NULL') As parameter, SC.max_length,
				SC.precision, SC.scale, SC.is_nullable--, ATD.datanumber
	FROM		sys.objects SO
				INNER JOIN sys.columns SC ON SO.OBJECT_ID = SC.OBJECT_ID
				INNER JOIN sys.types ST ON SC.system_type_id = ST.system_type_id
				--LEFT OUTER JOIN dbo.SystemDataType ATD ON SC.system_type_id = ATD.systemDataTypeId
				LEFT OUTER JOIN dbo.SystemDataType ATD ON UPPER(ST.name) = UPPER(ATD.name) AND ATD.dataBaseEngineCode = '00'
	WHERE		SO.name = @NameTable
				AND UPPER(ST.name) <> 'SYSNAME' --AND (ATD.verify_c# = 1 OR ATD.verify_c# IS NULL)
	ORDER BY	SC.object_id

	PRINT 'namespace Paltarumi.Acopio.Domain.Dto.' + @FileMain + '.' + @NameTable + ''
	PRINT '{'
	PRINT '    public class ' + @NameTable + 'Dto'
	PRINT '    {'
	
	OPEN JCursorEntity
	FETCH NEXT FROM JCursorEntity INTO @name, @tipodato, @parameter, @max_lenght, @precision, @scale, @nulo--, @datanumber
	WHILE @@Fetch_Status=0 BEGIN
			IF UPPER(@name) <> 'ID' + UPPER(@NameTable) AND UPPER(@name) <> 'ACTIVO' BEGIN
				SET @name = UPPER(SUBSTRING(@name, 1, 1)) + SUBSTRING(@name, 2, LEN(@name) - 1)
				PRINT '		public ' + @tipodato + ' ' + @name + ' { get; set; }'
			END

		FETCH NEXT FROM JCursorEntity INTO @name, @tipodato, @parameter, @max_lenght, @precision, @scale, @nulo--, @datanumber
	END
		
	PRINT '    }'
	PRINT '}'
	
	CLOSE JCursorEntity
	DEALLOCATE JCursorEntity


