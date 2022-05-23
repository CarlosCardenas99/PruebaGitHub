USE AcopioQA
GO

CREATE TABLE muestreo.Humedad(
	idHumedad int IDENTITY(1,1) NOT NULL,
	idLote int NOT NULL,
	fecha datetime NOT NULL,
	tmh real NOT NULL,
	tms real NOT NULL,
	humedad100 real NOT NULL,
	humedad real NOT NULL,
	codigoMuestreoTipoMineral int NOT NULL,
	codigoSupervisor int NOT NULL,
	reportadoProveedor bit NOT NULL,
	firmado bit NOT NULL,
	observacion varchar(200) NOT NULL,
	activo bit NOT NULL)
GO

ALTER TABLE muestreo.Humedad ADD CONSTRAINT PK_muestreo_idHumedad PRIMARY KEY (idHumedad);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE muestreo.Muestreo(
	idMuestreo int IDENTITY(1,1) NOT NULL,
	codigoTurno int NOT NULL,
	codigoResponsable int NOT NULL,
	fecha datetime NOT NULL,
	idLote int NOT NULL,
	codigoCancha int NOT NULL,
	llevaGrueso bit NOT NULL,
	codigoTrujillo varchar(10) NOT NULL,
	codigoAum varchar(10) NOT NULL,
	idEncargado int NOT NULL,
	codigoCondicion int NOT NULL,
	codigoEstado int NOT NULL,
	activo bit NOT NULL)
GO

ALTER TABLE muestreo.Muestreo ADD CONSTRAINT PK_muestreo_Muestreo_idMuestreo PRIMARY KEY (idMuestreo);
GO

--------------------------------------------------------------------------------------------------------


