USE AcopioQA
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE balanza.Maestro(
	idMaestro int IDENTITY(1,1) NOT NULL,
	codigoTabla char(2) NOT NULL,
	codigoItem char(2) NOT NULL,
	descripcion varchar(200) NOT NULL,
	activo bit NOT NULL)
GO

ALTER TABLE balanza.Maestro ADD CONSTRAINT PK_balanza_Maestro_idMaestro PRIMARY KEY (idMaestro);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE balanza.Lote(
	idLote int IDENTITY(1,1) NOT NULL,
	codigo varchar(10) NOT NULL,
	idConcesion int NOT NULL,
	idProveedor int NOT NULL,
	vehiculos 	varchar(200) NOT NULL,
	transportistas varchar(200) NOT NULL,
	tickets varchar(200) NOT NULL,
	conductores varchar(200) NOT NULL,
	fechaIngreso datetime NOT NULL,
	horaIngreso varchar(5) NOT NULL,
	fechaAcopio datetime NULL,--Modify NOT NULL
	horaAcopio varchar(5) NULL,--Modify NOT NULL
	idEstadoTipoMaterial int NOT NULL,--Modify codigoEstadoTipoMaterial
	cantidadSacos varchar(15) NOT NULL,
	tmh100 real NOT NULL,
	tmhBase real NOT NULL,
	tmh real NOT NULL,
	humedad real NULL,
	tms real NULL,
	codigoEstado int NOT NULL,
	observacion varchar(200) NOT NULL,
	activo bit NOT NULL
)
GO

ALTER TABLE balanza.Lote ADD CONSTRAINT PK_balanza_Lote_idLote PRIMARY KEY (idLote);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE balanza.Ticket(
	idTicket int IDENTITY(1,1) NOT NULL,--Modify idLoteTicket
	idLote int NOT NULL,
	numero varchar(10) NOT NULL,	
	fechaIngreso datetime NOT NULL,
	horaIngreso varchar(5) NOT NULL,
	fechaSalida datetime NOT NULL,
	horaSalida varchar(5) NOT NULL,
	pesoBruto real NOT NULL,
	tara real NOT NULL,
	pesoNeto real NOT NULL,
	grr varchar(50) NOT NULL,
	grt varchar(50) NOT NULL,
	idTransportista int NOT NULL,
	idConductor int NOT NULL,
	idVehiculo int NOT NULL,
	--codigoTipoVehiculo int NOT NULL,--Delete
	codigoUnidadMedida int NOT NULL,
	cantidadUnidadMedida int NOT NULL,
	observacion varchar(200) NOT NULL,
	activo bit NOT NULL)
GO

ALTER TABLE balanza.Ticket ADD CONSTRAINT PK_balanza_Ticket_idTicket PRIMARY KEY (idTicket);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE balanza.LeyesReferenciales(
	idLeyesReferenciales int IDENTITY(1,1) NOT NULL,
	fechaRecepcion datetime NOT NULL,
	idDuenoMuestra int NOT NULL,
	codigoMuestra varchar(100) NOT NULL,
	codigo varchar(10) NOT NULL,
	codigoLaboratorio int NOT NULL,
	activo bit NOT NULL)
GO

ALTER TABLE balanza.LeyesReferenciales ADD CONSTRAINT PK_balanza_LeyesReferenciales_idLeyesReferenciales PRIMARY KEY (idLeyesReferenciales);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE balanza.Recodificacion(
	idRecodificacion int IDENTITY(1,1) NOT NULL,
	idLote int NOT NULL,
	fechaRecodificacion datetime NOT NULL,
	horaRecodificacion varchar(5) NOT NULL,
	codigo varchar(10) NOT NULL,
	codigoLaboratorio varchar(10) NOT NULL,
	activo bit NOT NULL)
GO

ALTER TABLE balanza.Recodificacion ADD CONSTRAINT PK_balanza_Recodificacion_idRecodificacion PRIMARY KEY (idRecodificacion);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE balanza.CheckList(
	idCheckList int IDENTITY(1,1) NOT NULL,
	idLote int NOT NULL,
	habilitado bit NOT NULL,
	codigoDocumentoVerificacion char(2) NOT NULL,
	codigoEstado int NOT NULL,
	observacion varchar(200) NOT NULL)
GO

ALTER TABLE balanza.CheckList ADD CONSTRAINT PK_balanza_CheckList_idCheckList PRIMARY KEY (idCheckList);
GO

--------------------------------------------------------------------------------------------------------

