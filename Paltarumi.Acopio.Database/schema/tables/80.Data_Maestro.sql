USE AcopioQA
GO

-- TIPO DE DOCUMENTO
INSERT maestro.TipoDocumento (codigoTipoDocumento, nombre, nombreCorto, activo) VALUES (N'0', N'OTROS TIPOS DE DOCUMENTOS', N'OTROS', 1)
INSERT maestro.TipoDocumento (codigoTipoDocumento, nombre, nombreCorto, activo) VALUES (N'1', N'DOCUMENTO NACIONAL DE IDENTIDAD', N'DNI', 1)
INSERT maestro.TipoDocumento (codigoTipoDocumento, nombre, nombreCorto, activo) VALUES (N'4', N'CARNET DE EXTRANJERIA', N'EXTR', 1)
INSERT maestro.TipoDocumento (codigoTipoDocumento, nombre, nombreCorto, activo) VALUES (N'6', N'REGISTRO ÚNICO DE CONTRIBUYENTES', N'RUC', 1)
INSERT maestro.TipoDocumento (codigoTipoDocumento, nombre, nombreCorto, activo) VALUES (N'7', N'PASAPORTE', N'PASAP', 1)

-- CONDUCTOR
INSERT maestro.Conductor(codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES ('1', '45927845', 'AURELIO PALLI CANO', '', '140118', 'H-41014289', '', '', 1)
INSERT maestro.Conductor(codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES ('1', '20501244', 'JAIME MAMANI MAMANI', '', '140118', 'H-41014289', '', '', 1)
INSERT maestro.Conductor(codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES ('1', '43824447', 'FELIPE PUMA', '', '140118', 'U-80670967', '', '', 1)
INSERT maestro.Conductor(codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES ('1', '41554142', 'LINO MAYTA', '', '140118', 'H-41014289', '', '', 1)
INSERT maestro.Conductor(codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES ('1', '11111111', 'MAXIMO CAHUINA', '', '140118', 'H-41014289', '', '', 1)
INSERT maestro.Conductor(codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES ('1', '22222222', 'ROGER CAHUINA', '', '140118', 'U-47077860', '', '', 1)
INSERT maestro.Conductor(codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, licencia, telefono, email, activo) VALUES ('1', '33333333', 'ROGER PETHER VILCA HUIZA', '', '140118', 'U-42075260', '', '', 1)

-- TRANSPORTISTA
INSERT maestro.Transportista(codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, telefono, email, activo) VALUES ('6', '20601452154', 'TRANSPORTES CARMELO', '', '140118', '', '', 1)
INSERT maestro.Transportista(codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, telefono, email, activo) VALUES ('6', '20501444512', 'JJ TRANSPORTES', '', '140118', '', '', 1)
INSERT maestro.Transportista(codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, telefono, email, activo) VALUES ('6', '20606129510', 'LOS TIGRES SAC', '', '140118', '', '', 1)
INSERT maestro.Transportista(codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, telefono, email, activo) VALUES ('6', '20606201254', 'MARQUEZ HRNOS SRL', '', '140118', '', '', 1)
INSERT maestro.Transportista(codigoTipoDocumento, numero, razonSocial, domicilio, codigoUbigeo, telefono, email, activo) VALUES ('6', '20451248558', 'MAXIMO TRANS EIRL', '', '140118', '', '', 1)


