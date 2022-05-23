USE AcopioQA
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE config.Empresa(
	idEmpresa int IDENTITY(1,1) NOT NULL,
	codigoTipoDocumento char(2) NOT NULL,
	numero varchar(30) NOT NULL,
	razonSocial varchar(100) NOT NULL,
	propietario varchar(100) NOT NULL,
	domicilio varchar(200) NOT NULL,
	telefono varchar(12) NOT NULL,
	codigoUbigeo char(6) NULL,
	email varchar(50) NOT NULL,
	rutaSunat varchar(200) NOT NULL,
	activo bit NOT NULL
)
GO

ALTER TABLE config.Empresa ADD CONSTRAINT PK_config_Empresa_id PRIMARY KEY (idEmpresa);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE config.Modulo(
	idModulo int IDENTITY(1,1) NOT NULL,
	nombre varchar(200) NOT NULL,
	estado int NOT NULL)
GO

ALTER TABLE config.Modulo ADD CONSTRAINT PK_config_Modulo_id PRIMARY KEY (idModulo);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE config.ModuloUsuario(
	idModuloUsuario int IDENTITY(1,1) NOT NULL,
	idUsuario int NOT NULL,
	idModulo int NOT NULL,
	idEmpresa int NOT NULL)
GO

ALTER TABLE config.ModuloUsuario ADD CONSTRAINT PK_config_ModuloUsuario_id PRIMARY KEY (idModuloUsuario);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE config.Usuario(
	idUsuario int IDENTITY(1,1) NOT NULL,
	usuario varchar(50) NOT NULL,
	password varchar(200) NOT NULL,
	nick varchar(50) NULL,
	nombres varchar(50) NULL,
	apellidos varchar(50) NULL,
	idTipoDocumento int NOT NULL,
	nroDocumento varchar(50) NOT NULL,
	idEmpresa int NOT NULL,
	estado int NOT NULL)
GO

ALTER TABLE config.Usuario ADD CONSTRAINT PK_config_Usuario_id PRIMARY KEY (idUsuario);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE config.CorrelativoTipo(
	codigoCorrelativoTipo char(2) NOT NULL,
	nombre varchar(50) NOT NULL,
	activo bit NOT NULL
)
GO

ALTER TABLE config.CorrelativoTipo ADD CONSTRAINT PK_config_CorrelativoTipo_codigoCorrelativoTipo PRIMARY KEY (codigoCorrelativoTipo);
GO

--------------------------------------------------------------------------------------------------------

CREATE TABLE config.Correlativo(
	idCorrelativo int IDENTITY(1,1) NOT NULL,
	codigoCorrelativoTipo char(2) NOT NULL,
	serie varchar(4) NOT NULL,
	numero int NOT NULL,
	activo bit NOT NULL
)
GO

ALTER TABLE config.Correlativo ADD CONSTRAINT PK_config_Correlativo_idCorrelativo PRIMARY KEY (idCorrelativo);
GO