USE AcopioQA
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE maestro.Ubigeo(
	codigoUbigeo char(6) NOT NULL,
	departamento varchar(50) NOT NULL,
	provincia varchar(50) NOT NULL,
	distrito varchar(50) NOT NULL,
	activo bit NOT NULL
)

ALTER TABLE maestro.Ubigeo ADD CONSTRAINT PK_maestro_Ubigeo_codigoUbigeo PRIMARY KEY (codigoUbigeo);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE maestro.Concesion(
	idConcesion int IDENTITY(1,1) NOT NULL,
	codigoUnico varchar(25) NOT NULL,
	nombre varchar(100) NOT NULL,
	codigoUbigeo char(6) NULL,
	activo bit NOT NULL)
GO

ALTER TABLE maestro.Concesion ADD CONSTRAINT PK_maestro_Concesion_idConcesion PRIMARY KEY (idConcesion);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE maestro.Proveedor(
	idProveedor int IDENTITY(1,1) NOT NULL,
	ruc varchar(11) NOT NULL,
	razonSocial varchar(100) NOT NULL,
	direccion varchar(200) NOT NULL,
	telefono varchar(12) NOT NULL,
	email varchar(50) NOT NULL,
	activo bit NOT NULL)
GO

ALTER TABLE maestro.Proveedor ADD CONSTRAINT PK_maestro_Proveedor_idProveedor PRIMARY KEY (idProveedor);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE maestro.TipoDocumento(
	codigoTipoDocumento char(1) NOT NULL,
	nombre varchar(50) NOT NULL,
	nombreCorto varchar(5) NULL,
	activo bit NOT NULL
)
GO

ALTER TABLE maestro.TipoDocumento ADD CONSTRAINT PK_maestro_TipoDocumento PRIMARY KEY (codigoTipoDocumento);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE maestro.Conductor(
	idConductor int IDENTITY(1,1) NOT NULL,
	codigoTipoDocumento char(1) NOT NULL,
	numero varchar(30) NOT NULL,
	razonSocial varchar(100) NOT NULL,
	domicilio varchar(200) NOT NULL,
	codigoUbigeo char(6) NULL,
	licencia varchar(20) NOT NULL,
	telefono varchar(12) NOT NULL,
	email varchar(50) NOT NULL,
	activo bit NOT NULL)
GO

ALTER TABLE maestro.Conductor ADD CONSTRAINT PK_maestro_Conductor_idConductor PRIMARY KEY (idConductor);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE maestro.Transportista(
	idTransportista int IDENTITY(1,1) NOT NULL,
	codigoTipoDocumento char(1) NOT NULL,
	numero varchar(30) NOT NULL,
	razonSocial varchar(100) NOT NULL,
	domicilio varchar(200) NOT NULL,
	codigoUbigeo char(6) NULL,
	telefono varchar(12) NOT NULL,
	email varchar(50) NOT NULL,
	activo bit NOT NULL)
GO

ALTER TABLE maestro.Transportista ADD CONSTRAINT PK_maestro_Transportista_idTransportista PRIMARY KEY (idTransportista);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE maestro.Vehiculo(
	idVehiculo int IDENTITY(1,1) NOT NULL,
	idTipoVehiculo int NOT NULL,
	idVehiculoMarca int NOT NULL,
	placa varchar(20) NOT NULL,
	activo bit NOT NULL)
GO

ALTER TABLE maestro.Vehiculo ADD CONSTRAINT PK_maestro_Vehiculo_idVehiculo PRIMARY KEY (idVehiculo);
GO

--------------------------------------------------------------------------------------------------------
