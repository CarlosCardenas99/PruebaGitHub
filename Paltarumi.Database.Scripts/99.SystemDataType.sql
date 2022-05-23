USE AcopioQA
GO

CREATE TABLE dbo.JapBlackList(
	japBlackListId int NOT NULL,
	objectType varchar(2) NOT NULL,
	objectSchema varchar(50) NOT NULL,
	objectName varchar(80) NOT NULL,
	active bit NOT NULL
)
GO
ALTER TABLE dbo.JapBlackList ADD CONSTRAINT PK_JapBlackList_japBlackListId PRIMARY KEY (japBlackListId);
GO

CREATE TABLE dbo.SystemDataType(
	systemDataTypeId int NOT NULL,
	name varchar(50) NOT NULL,
	originalStorage tinyint NULL,
	storage tinyint NULL,
	precision bit NOT NULL,
	scale bit NOT NULL,
	dataTypeJava varchar(50) NULL,
	dataTypeCSharp varchar(50) NULL,
	MySqlDbTypeCSharp varchar(50) NULL,
	dbTypeCSharp varchar(50) NULL,
	active bit NOT NULL,
	dataBaseEngineCode char(2) NOT NULL,
	typeValueCode char(3) NOT NULL,
	ranking smallint NULL
)
GO
ALTER TABLE dbo.SystemDataType ADD CONSTRAINT PK_SystemDataType_systemDataTypeId PRIMARY KEY (systemDataTypeId);
GO

INSERT dbo.JapBlackList (japBlackListId, objectType, objectSchema, objectName, active) VALUES (2, N'P', N'dbo', N'sysdiagrams', 1)
INSERT dbo.JapBlackList (japBlackListId, objectType, objectSchema, objectName, active) VALUES (3, N'P', N'dbo', N'sp_upgraddiagrams', 1)
INSERT dbo.JapBlackList (japBlackListId, objectType, objectSchema, objectName, active) VALUES (4, N'P', N'dbo', N'sp_helpdiagrams', 1)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
VALUES (1, N'TINYINT', 1, 0, 0, 0, N'byte', N'byte', N'Byte', N'SByte', 1, N'01', N'FIX', NULL)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
VALUES (2, N'SMALLINT', 2, 0, 0, 0, N'short', N'int', N'Int16', N'Int16', 1, N'01', N'FIX', NULL)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
VALUES (3, N'MEDIUMINT', 3, 0, 0, 0, N'', N'int', N'Int24', N'Int32', 1, N'01', N'FIX', NULL)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
VALUES (4, N'INT', 4, 0, 0, 0, N'Integer', N'int', N'Int32', N'Int32', 1, N'01', N'FIX', NULL)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (5, N'BIGINT', 8, 0, 0, 0, N'long', N'long', N'Int64', N'Int64', 1, N'01', N'FIX', NULL)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (6, N'DECIMAL', NULL, NULL, 1, 1, N'BigDecimal', N'decimal', N'Decimal', N'Decimal', 1, N'01', N'DEC', NULL)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (7, N'DATE', 3, 0, 0, 0, N'Date', N'Datetime', N'Date', N'Date', 1, N'01', N'FIX', NULL)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (8, N'TIME', 3, 0, 0, 0, N'Time', N'TimeStamp', N'Time', N'Time', 1, N'01', N'FIX', NULL)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (9, N'DATETIME', 8, 0, 0, 0, N'', N'Datetime', N'DateTime', N'DateTime', 1, N'01', N'FIX', NULL)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (10, N'TIMESTAMP', 4, 0, 0, 0, N'Timestamp', N'Datetime', N'Timestamp', N'DateTime', 1, N'01', N'FIX', NULL)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (11, N'CHAR', NULL, NULL, 0, 0, N'String', N'string', N'String', N'StringFixedLength', 1, N'01', N'VAR', NULL)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (12, N'VARCHAR', NULL, NULL, 0, 0, N'String', N'string', N'VarChar', N'String', 1, N'01', N'VAR', NULL)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (13, N'TEXT', NULL, NULL, 0, 0, N'', N'string', N'Text  ', N'AnsiString', 1, N'00', N'FIX', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (14, N'DATE', NULL, NULL, 0, 0, N'Date', N'DateTime', N'Date  ', N'Date', 1, N'00', N'FIX', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (15, N'TIME', NULL, NULL, 0, 0, N'Time', N'DateTime', N'Time  ', N'Time', 1, N'00', N'FIX', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (16, N'TINYINT', NULL, NULL, 0, 0, N'byte', N'Byte', N'TinyInt  ', N'Byte', 1, N'00', N'FIX', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (17, N'SMALLINT', NULL, NULL, 0, 0, N'short', N'int', N'SmallInt  ', N'Int16', 1, N'00', N'FIX', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (18, N'INT', NULL, NULL, 1, 1, N'Integer', N'int', N'Int', N'Int32', 1, N'00', N'FIX', 1)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (19, N'SMALLDATETIME', NULL, NULL, 0, 0, N'', N'DateTime', N'SmallDateTime  ', N'DateTime', 1, N'00', N'FIX', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (20, N'REAL', NULL, NULL, 0, 0, N'float', N'Single', N'Real  ', N'Single', 1, N'00', N'DEC', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (21, N'MONEY', NULL, NULL, 0, 0, N'', N'decimal', N'Money  ', N'Currency', 1, N'00', N'DEC', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (22, N'DATETIME', NULL, 8, 0, 0, N'Date', N'DateTime', N'DateTime  ', N'DateTime', 1, N'00', N'FIX', 6)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (23, N'FLOAT', NULL, NULL, 0, 0, N'float', N'double', N'Float  ', N'Double', 1, N'00', N'DEC', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (24, N'BIT', NULL, NULL, 0, 0, N'boolean', N'bool', N'Bit', N'Boolean', 1, N'00', N'FIX', 3)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (25, N'DECIMAL', NULL, NULL, 0, 0, N'BigDecimal', N'decimal', N'Decimal', N'Decimal', 1, N'00', N'DEC', 7)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (26, N'NUMERIC', NULL, NULL, 0, 0, N'BitDecimal', N'decimal', N'Decimal  ', N'Decimal', 1, N'00', N'DEC', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (27, N'SMALLMONEY', NULL, NULL, 0, 0, N'', N'decimal', N'SmallMoney  ', N'Currency', 1, N'00', N'DEC', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (28, N'BIGINT', NULL, NULL, 0, 0, N'long', N'long', N'BigInt  ', N'Int64', 1, N'00', N'FIX', 5)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (29, N'VARCHAR', NULL, NULL, 0, 0, N'String', N'string', N'VarChar  ', N'AnsiString', 1, N'00', N'VAR', 2)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (30, N'CHAR', NULL, NULL, 0, 0, N'String', N'string', N'Char  ', N'AnsiStringFixedLength', 1, N'00', N'VAR', 4)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (31, N'XML', NULL, NULL, 0, 0, N'', N'string', N'Xml  ', N'Xml', 1, N'00', N'FIX', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (33, N'NVARCHAR', NULL, NULL, 0, 0, N'', N'string', N'NVarchar', N'String', 1, N'00', N'VAR', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (35, N'NCHAR', NULL, NULL, 0, 0, N'', N'string', N'NChar', N'StringFixedLength', 1, N'00', N'VAR', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (38, N'VARBINARY', NULL, NULL, 0, 0, N'byte', N'Byte', N'', N'Binary', 1, N'00', N'FIX', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (39, N'BIT', NULL, NULL, 0, 0, N'boolean', N'bool', N'Bit', N'Boolean', 1, N'01', N'FIX', 3)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (40, N'NUMERIC', NULL, NULL, 0, 0, N'BitDecimal', N'decimal', N'Decimal', N'Decimal', 1, N'01', N'DEC', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (41, N'REAL', NULL, NULL, 0, 0, N'float', N'Single', N'Real', N'Single', 1, N'01', N'DEC', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (42, N'FLOAT', NULL, NULL, 0, 0, N'float', N'double', N'Float', N'Double', 1, N'01', N'DEC', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (43, N'DOUBLE', NULL, NULL, 0, 0, N'double', N'double', N'Double', N'Double', 1, N'01', N'DEC', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (44, N'VARBINARY', NULL, NULL, 0, 0, N'byte', N'Byte', N'', N'Binary', 1, N'01', N'FIX', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (45, N'LONGVARBINARY', NULL, NULL, 0, 0, N'byte', N'Byte', N'', N'Binary', 1, N'01', N'FIX', 99)

INSERT dbo.SystemDataType
(systemDataTypeId, name, originalStorage, storage, precision, scale, dataTypeJava, dataTypeCSharp, MySqlDbTypeCSharp, dbTypeCSharp, active, dataBaseEngineCode, typeValueCode, ranking)
 VALUES (46, N'DATE', NULL, NULL, 0, 0, N'Date', N'DateTime', N'Date', N'Date', 1, N'01', N'FIX', 99)
 GO



IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_Stored_List'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_Stored_List
END
GO

CREATE PROCEDURE [dbo].[usp_Framework_Stored_List]
AS
BEGIN
	SELECT name AS storedName
	FROM sys.objects
	WHERE type = 'P'
	AND name NOT IN('sysdiagrams','sp_upgraddiagrams','sp_helpdiagrams','sp_helpdiagramdefinition',
					'sp_creatediagram''sp_renamediagram''sp_alterdiagram''sp_dropdiagram',
					'sp_creatediagram','sp_renamediagram','sp_alterdiagram','sp_dropdiagram')
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo')
END
GO

---------------------------------------------------------------------------------------------------------

IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_Stored_Parameters'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_Stored_Parameters
END
GO

CREATE PROCEDURE [dbo].[usp_Framework_Stored_Parameters]
	@schemaName VARCHAR(80),
	@storedName VARCHAR(80)
AS
BEGIN
	SELECT STOREDS.SPECIFIC_NAME		AS 'storedName'  
		, PAR.PARAMETER_NAME			AS 'parameterName'  
		, CASE PAR.PARAMETER_MODE  
		WHEN 'IN' THEN 'Input'  
		--WHEN 'OUT' THEN 'Output' TODO: EN SQL SERVER UN PARÁMETRO OUT ES NECESARIAMENTE INOUT
		WHEN 'INOUT' THEN 'Output'
		END								AS 'parameterMode'  
		, PAR.DATA_TYPE					AS 'parameterDataType'  
		, PAR.CHARACTER_MAXIMUM_LENGTH	AS 'parameterLength'  
		, PAR.NUMERIC_PRECISION			AS 'parameterPresicion'  
		, PAR.NUMERIC_SCALE				AS 'parameterScale'  
		, PAR.ORDINAL_POSITION			AS 'parameterPosition'  
	FROM information_schema.parameters PAR  
		RIGHT JOIN  
		(  
			SELECT pp.SPECIFIC_NAME, pp.ROUTINE_SCHEMA, pp.ROUTINE_TYPE  
			FROM information_schema.routines pp
		) STOREDS ON PAR.SPECIFIC_NAME = STOREDS.SPECIFIC_NAME  
		AND PAR.SPECIFIC_SCHEMA = STOREDS.ROUTINE_SCHEMA 
	WHERE STOREDS.ROUTINE_TYPE = 'PROCEDURE'
		AND STOREDS.SPECIFIC_NAME = @storedName
		AND STOREDS.SPECIFIC_NAME NOT IN('sysdiagrams','sp_upgraddiagrams','sp_helpdiagrams','sp_helpdiagramdefinition',  
			'sp_creatediagram''sp_renamediagram''sp_alterdiagram''sp_dropdiagram',  
			'sp_creatediagram','sp_renamediagram','sp_alterdiagram','sp_dropdiagram') 
	ORDER BY STOREDS.SPECIFIC_NAME, PAR.ORDINAL_POSITION
END
GO

---------------------------------------------------------------------------------------------------------

IF EXISTS(select name FROM sys.objects where type = 'P' AND name = 'usp_Framework_Entity_Bitscom'
	AND schema_id = (SELECT schema_id FROM SYS.schemas WHERE NAME = 'dbo'))
BEGIN
	DROP PROCEDURE dbo.usp_Framework_Entity_Bitscom
END
GO

CREATE PROCEDURE [dbo].[usp_Framework_Entity_Bitscom]
	@NameTable VARCHAR(80),
	@NameTableFormat VARCHAR(80) = @NameTable
	 
AS	
	DECLARE @name VARCHAR(50)
	DECLARE @tipodato VARCHAR(50)
	DECLARE @parameter VARCHAR(50)
	DECLARE @max_lenght VARCHAR(50)
	DECLARE @precision VARCHAR(20)
	DECLARE @scale VARCHAR(20)
	DECLARE @nulo TINYINT
	--DECLARE @datanumber BIT
	
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
	
	PRINT '	public class ' + @NameTableFormat
	PRINT '	{'
	
	OPEN JCursorEntity
	FETCH NEXT FROM JCursorEntity INTO @name, @tipodato, @parameter, @max_lenght, @precision, @scale, @nulo--, @datanumber
	WHILE @@Fetch_Status=0 BEGIN
		/*
		IF UPPER(@tipodato) = 'DATETIME' BEGIN
			PRINT '		public string ' + @name + ' { get; set; }'
		END
		ELSE BEGIN*/
			
		/*END*/

		IF @nulo = 1 BEGIN
			PRINT '		public ' + @tipodato + '? ' + @name + ' { get; set; }'
		END
		ELSE BEGIN
			PRINT '		public ' + @tipodato + ' ' + @name + ' { get; set; }'
		END

		FETCH NEXT FROM JCursorEntity INTO @name, @tipodato, @parameter, @max_lenght, @precision, @scale, @nulo--, @datanumber
	END
		
	PRINT '	}'
	
	CLOSE JCursorEntity
	DEALLOCATE JCursorEntity
GO

