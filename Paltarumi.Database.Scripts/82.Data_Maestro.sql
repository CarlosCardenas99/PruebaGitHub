USE AcopioQA
GO

--*********************************************************************************************************************************************
-- CONSECIÓN
SET IDENTITY_INSERT maestro.Concesion ON
INSERT maestro.Concesion (idConcesion, codigoUnico, nombre, codigoUbigeo, activo) VALUES (1, '10000111Y01', 'EL FUTURO', '140118', 1)
INSERT maestro.Concesion (idConcesion, codigoUnico, nombre, codigoUbigeo, activo) VALUES (2, '010127200', 'CRISTOFORO 15', '140118', 1)
INSERT maestro.Concesion (idConcesion, codigoUnico, nombre, codigoUbigeo, activo) VALUES (3, '010341610', 'SANTA VICTORIA 2010', '140118', 1)
INSERT maestro.Concesion (idConcesion, codigoUnico, nombre, codigoUbigeo, activo) VALUES (4, '520004511', 'APOCALYPTO I', '140118', 1)
INSERT maestro.Concesion (idConcesion, codigoUnico, nombre, codigoUbigeo, activo) VALUES (5, '010235910', 'DYLAN UNO', '140118', 1)
INSERT maestro.Concesion (idConcesion, codigoUnico, nombre, codigoUbigeo, activo) VALUES (6, '620003611', 'LIBRA I', '140118', 1)
SET IDENTITY_INSERT maestro.Concesion OFF

--*********************************************************************************************************************************************
-- TIPO DE DOCUMENTO
INSERT maestro.TipoDocumento (codigoTipoDocumento, nombre, nombreCorto, activo) VALUES (N'0', N'OTROS TIPOS DE DOCUMENTOS', N'OTROS', 1)
INSERT maestro.TipoDocumento (codigoTipoDocumento, nombre, nombreCorto, activo) VALUES (N'1', N'DOCUMENTO NACIONAL DE IDENTIDAD', N'DNI', 1)
INSERT maestro.TipoDocumento (codigoTipoDocumento, nombre, nombreCorto, activo) VALUES (N'4', N'CARNET DE EXTRANJERIA', N'EXTR', 1)
INSERT maestro.TipoDocumento (codigoTipoDocumento, nombre, nombreCorto, activo) VALUES (N'6', N'REGISTRO ÚNICO DE CONTRIBUYENTES', N'RUC', 1)
INSERT maestro.TipoDocumento (codigoTipoDocumento, nombre, nombreCorto, activo) VALUES (N'7', N'PASAPORTE', N'PASAP', 1)
INSERT maestro.TipoDocumento (codigoTipoDocumento, nombre, nombreCorto, activo) VALUES (N'F', N'PERMISO TEMPORAL DE PERMANENCIA', N'PTP', 1)

--*********************************************************************************************************************************************
-- CONDUCTOR
SET IDENTITY_INSERT maestro.Conductor ON
INSERT maestro.Conductor(idConductor, codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES (1, '1', '45927845', 'AURELIO PALLI CANO', '', '140118', 'H-41014289', '', '', 1)
INSERT maestro.Conductor(idConductor, codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES (2, '1', '20501244', 'JAIME MAMANI MAMANI', '', '140118', 'H-41014289', '', '', 1)
INSERT maestro.Conductor(idConductor, codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES (3, '1', '43824447', 'FELIPE PUMA', '', '140118', 'U-80670967', '', '', 1)
INSERT maestro.Conductor(idConductor, codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES (4, '1', '41554142', 'LINO MAYTA', '', '140118', 'H-41014289', '', '', 1)
INSERT maestro.Conductor(idConductor, codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES (5, '1', '11111111', 'MAXIMO CAHUINA', '', '140118', 'H-41014289', '', '', 1)
INSERT maestro.Conductor(idConductor, codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES (6, '1', '22222222', 'ROGER CAHUINA', '', '140118', 'U-47077860', '', '', 1)
INSERT maestro.Conductor(idConductor, codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES (7, '1', '33333333', 'ROGER PETHER VILCA HUIZA', '', '140118', 'U-42075260', '', '', 1)
SET IDENTITY_INSERT maestro.Conductor OFF

--*********************************************************************************************************************************************
-- TRANSPORTISTA
SET IDENTITY_INSERT maestro.Transportista ON
INSERT maestro.Transportista(idTransportista, codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, telefono, email, activo) VALUES (1, '6', '20601452154', 'TRANSPORTES CARMELO', '', '140118', '', '', 1)
INSERT maestro.Transportista(idTransportista, codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, telefono, email, activo) VALUES (2, '6', '20501444512', 'JJ TRANSPORTES', '', '140118', '', '', 1)
INSERT maestro.Transportista(idTransportista, codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, telefono, email, activo) VALUES (3, '6', '20606129510', 'LOS TIGRES SAC', '', '140118', '', '', 1)
INSERT maestro.Transportista(idTransportista, codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, telefono, email, activo) VALUES (4, '6', '20606201254', 'MARQUEZ HRNOS SRL', '', '140118', '', '', 1)
INSERT maestro.Transportista(idTransportista, codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, telefono, email, activo) VALUES (5, '6', '20451248558', 'MAXIMO TRANS EIRL', '', '140118', '', '', 1)
SET IDENTITY_INSERT maestro.Transportista OFF

--*********************************************************************************************************************************************
-- VEHÍCULO
SET IDENTITY_INSERT maestro.Vehiculo ON
INSERT maestro.Vehiculo (idVehiculo, idTipoVehiculo, idVehiculoMarca, placa, activo) VALUES (1, 26, 22, 'V3A-714', 1)
INSERT maestro.Vehiculo (idVehiculo, idTipoVehiculo, idVehiculoMarca, placa, activo) VALUES (2, 26, 24, 'Z2X-884', 1)
INSERT maestro.Vehiculo (idVehiculo, idTipoVehiculo, idVehiculoMarca, placa, activo) VALUES (3, 28, 22, 'Z1T-809', 1)
INSERT maestro.Vehiculo (idVehiculo, idTipoVehiculo, idVehiculoMarca, placa, activo) VALUES (4, 27, 25, 'V8U-760', 1)
INSERT maestro.Vehiculo (idVehiculo, idTipoVehiculo, idVehiculoMarca, placa, activo) VALUES (5, 28, 24, 'Z6X-837', 1)
INSERT maestro.Vehiculo (idVehiculo, idTipoVehiculo, idVehiculoMarca, placa, activo) VALUES (6, 28, 22, 'Z1D-934', 1)
INSERT maestro.Vehiculo (idVehiculo, idTipoVehiculo, idVehiculoMarca, placa, activo) VALUES (7, 27, 25, 'C1Z-923', 1)
INSERT maestro.Vehiculo (idVehiculo, idTipoVehiculo, idVehiculoMarca, placa, activo) VALUES (8, 26, 25, 'C14-963', 1)
SET IDENTITY_INSERT maestro.Vehiculo OFF

--*********************************************************************************************************************************************
-- PROVEEDOR
SET IDENTITY_INSERT maestro.Proveedor ON
INSERT maestro.Proveedor (idProveedor, ruc, razonSocial, direccion, telefono, email, activo) VALUES (1, '10024105321', 'PITER EL MUCHACHON EIRL', 'CHALA', '985413251', 'vilca@gmail.com', 1)
INSERT maestro.Proveedor (idProveedor, ruc, razonSocial, direccion, telefono, email, activo) VALUES (2, '20606129034', 'CARLOS CARRERA ANAPAN', 'MOLLEHUACA', '978510058', 'ccabrera.1889@gmail.com', 1)
SET IDENTITY_INSERT maestro.Proveedor OFF

