USE Acopio
GO
--SET IDENTITY_INSERT [balanza].[Lote] ON 

--INSERT [balanza].[Lote] ([idLote], [codigo], [idConcesion], [idProveedor], [fechaIngreso], [fechaAcopio], [codigoEstadoTipoMaterial], [cantidadSacos], [tmh], [humedad], [tms], [codigoEstado], [observacion], [activo], tmh100, tmhBase) VALUES (2, N'0101', 0, 0, CAST(N'2022-05-01T12:50:26.470' AS DateTime), CAST(N'2022-05-01T12:50:26.470' AS DateTime), N'00', N'00', 0, 0, 0, N'00', N'00', 1,0,0)
--SET IDENTITY_INSERT [balanza].[Lote] OFF
SET IDENTITY_INSERT [balanza].[Maestro] ON 

INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (1, N'01', N'00', N'ESTADO TIPO MINERAL', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (2, N'01', N'01', N'LLAMPO', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (3, N'01', N'02', N'CRUDO', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (4, N'01', N'03', N'POLVEADO', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (5, N'02', N'00', N'UNIDAD DE MEDIDA', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (6, N'02', N'01', N'GRANEL', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (7, N'02', N'02', N'SACOS', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (8, N'02', N'03', N'BIG BAG', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (9, N'03', N'00', N'ESTADO LOTES', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (15, N'03', N'01', N'EN CANCHA', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (16, N'03', N'02', N'RETIRADO', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (17, N'03', N'03', N'ANULADO', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (18, N'04', N'00', N'TIPO LOTE RECODIFICACI�N', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (19, N'04', N'01', N'INICIAL', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (20, N'04', N'02', N'REMUESTREO DE CANCHA', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (21, N'04', N'03', N'REMUESTREO DE SACO', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (22, N'05', N'00', N'VEHICULO MARCA', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (23, N'06', N'00', N'VEHICULO TIPO', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (24, N'07', N'00', N'CHECKLIST', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (25, N'08', N'00', N'ESTADO TMH', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (26, N'09', N'00', N'TIPO MATERIAL', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (27, N'05', N'01', N'MITSUBISHI', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (28, N'05', N'02', N'VOLVO', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (29, N'05', N'03', N'SCANIA', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (30, N'05', N'04', N'VOLKSWAGEN', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (31, N'06', N'01', N'CAMI�N', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (32, N'06', N'02', N'VOLQUETE', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (33, N'06', N'03', N'PLATAFORMA', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (34, N'07', N'01', N'GU�A DE RECEPCI�N DE MINERAL', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (35, N'07', N'02', N'TICKET DE PESAJE', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (36, N'07', N'03', N'GU�A DE REMISI�N REMITENTE', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (37, N'07', N'04', N'GU�A DE REMISI�N TRANSPORTISTA', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (38, N'07', N'05', N'CONSULTA SUNAT', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (39, N'07', N'06', N'AUTORIZACI�N DE COMPROBANTE (GRR)', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (40, N'07', N'07', N'AUTORIZACI�N DE COMPROBANTE (GRT)', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (41, N'07', N'08', N'REINFO', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (42, N'07', N'09', N'CONSULTA MINEROS FORMALIZADOS', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (43, N'07', N'10', N'RECPO', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (44, N'07', N'11', N'CONSULTA VEH�CULO SUNARP', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (45, N'07', N'12', N'COMODATO', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (46, N'07', N'13', N'CONSULTA DE LICENCIAS MTC', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (47, N'08', N'01', N'A', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (48, N'08', N'02', N'B', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (49, N'08', N'03', N'C', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (50, N'08', N'04', N'D', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (51, N'09', N'01', N'MOC', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (52, N'09', N'02', N'MOLL', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (53, N'09', N'03', N'MOP', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (54, N'09', N'04', N'MSC', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (55, N'09', N'05', N'MSLL', 1)
INSERT [balanza].[Maestro] ([idMaestro], [codigoTabla], [codigoItem], [descripcion], [activo]) VALUES (56, N'09', N'06', N'MSP', 1)
SET IDENTITY_INSERT [balanza].[Maestro] OFF
SET IDENTITY_INSERT [balanza].[Recodificacion] ON 

INSERT [balanza].[Recodificacion] ([idRecodificacion], [codigoTipoLoteRecodificacion], [idTablaOrigen], [codigoTipoOrigen], [codigo], [codigoLaboratorio], [activo]) VALUES (1, N'02', 11, N'01', N'1010', N'0', 1)
SET IDENTITY_INSERT [balanza].[Recodificacion] OFF
SET IDENTITY_INSERT [balanza].[Ticket] ON 

INSERT [balanza].[Ticket] ([idLoteTicket], [idLote], [numero], [fechaIngreso], [fechaSalida], [pesoBruto], [tara], [pesoNeto], [grr], [grt], [idTransportista], [idConductor], [idVehiculo], [codigoTipoVehiculo], [codigoUnidadMedida], [cantidadUnidadMedida], [observacion], [activo]) VALUES (3, 2, N'0', CAST(N'2022-05-01T00:00:00.000' AS DateTime), CAST(N'2022-10-10T00:00:00.000' AS DateTime), 110, 11, 12, N'11', N'11', 0, 1, 0, N'01', N'01', 11, N'', 1)
SET IDENTITY_INSERT [balanza].[Ticket] OFF

SET IDENTITY_INSERT [dbo].[Empresa] ON 

INSERT [dbo].[Empresa] ([id], [razonSocial], [razonSocialCorto], [ruc], [direccionFiscal], [estado]) VALUES (1, N'aaa', N'aa', N'202222', N'av', 1)
INSERT [dbo].[Empresa] ([id], [razonSocial], [razonSocialCorto], [ruc], [direccionFiscal], [estado]) VALUES (2, N'string', N'string', N'string', N'string', 1)
SET IDENTITY_INSERT [dbo].[Empresa] OFF
SET IDENTITY_INSERT [dbo].[Modulo] ON 

INSERT [dbo].[Modulo] ([id], [nombre], [estado]) VALUES (1, N'balanza', 1)
SET IDENTITY_INSERT [dbo].[Modulo] OFF
SET IDENTITY_INSERT [dbo].[ModuloUsuario] ON 

INSERT [dbo].[ModuloUsuario] ([id], [idUsuario], [idModulo], [idEmpresa]) VALUES (6, 12, 1, 1)
SET IDENTITY_INSERT [dbo].[ModuloUsuario] OFF
SET IDENTITY_INSERT [comercial].[Proveedor] ON 

INSERT [comercial].[Proveedor] ([idProveedor], [ruc], [razonSocial], [direccion], [telefono], [email], [activo]) VALUES (1, N'10427812877', N'GERMAN FORTUNATO ANGELES MILLA', N'direc 01', N'1234567', N'gangelesm@correo.com', 1)
INSERT [comercial].[Proveedor] ([idProveedor], [ruc], [razonSocial], [direccion], [telefono], [email], [activo]) VALUES (2, N'10634025141', N'ROMULO MUNOZ PANTOJA', N'direc 02', N'5530990', N'rmunozp@correo.com', 1)
INSERT [comercial].[Proveedor] ([idProveedor], [ruc], [razonSocial], [direccion], [telefono], [email], [activo]) VALUES (3, N'10010138197', N'ESTRELLA ANTICONA LURGIA', N'direc 03', N'4813707', N'eanticonal@correo.com', 1)
INSERT [comercial].[Proveedor] ([idProveedor], [ruc], [razonSocial], [direccion], [telefono], [email], [activo]) VALUES (4, N'20455318727', N'SERVICIOS GENERALES CAYRAC SAC', N'direc 04', N'4823575', N'cayrac.sg@correo.com', 1)
INSERT [comercial].[Proveedor] ([idProveedor], [ruc], [razonSocial], [direccion], [telefono], [email], [activo]) VALUES (5, N'10634025141', N'MARI ESTHER VERA ALFARO DE CACERES', N'direc 05', N'3216547', N'mveraa@correo.com', 1)
INSERT [comercial].[Proveedor] ([idProveedor], [ruc], [razonSocial], [direccion], [telefono], [email], [activo]) VALUES (6, N'10634025141', N'INVERSIONES ISABEL LUBRA EIRL', N'direc 06', N'4830125', N'isabellubra.inversiones@correo.com', 1)
SET IDENTITY_INSERT [comercial].[Proveedor] OFF
SET IDENTITY_INSERT [dbo].[TipoDocumento] ON 

INSERT [dbo].[TipoDocumento] ([id], [nombre], [estado]) VALUES (1, N'DNI', 1)
INSERT [dbo].[TipoDocumento] ([id], [nombre], [estado]) VALUES (2, N'carnet extranjeria', 1)
SET IDENTITY_INSERT [dbo].[TipoDocumento] OFF

SET IDENTITY_INSERT [maestro].[concesion] ON 

INSERT [maestro].[Concesion] ([idConcesion], [codigoUnico], [nombre], [departamento], [provincia], [distrito], [activo]) VALUES (1, N'10000111Y01', N'EL FUTURO', N'AREQUIPA', N'CARAVELI', N'CARAVELI', 1)
INSERT [maestro].[Concesion] ([idConcesion], [codigoUnico], [nombre], [departamento], [provincia], [distrito], [activo]) VALUES (2, N'010127200', N'CRISTOFORO 15', N'AREQUIPA', N'CARAVELI', N'CHAPARRA', 1)
INSERT [maestro].[Concesion] ([idConcesion], [codigoUnico], [nombre], [departamento], [provincia], [distrito], [activo]) VALUES (3, N'010341610', N'SANTA VICTORIA 2010', N'ANCASH', N'HUARAZ', N'HUARAZ', 1)
INSERT [maestro].[Concesion] ([idConcesion], [codigoUnico], [nombre], [departamento], [provincia], [distrito], [activo]) VALUES (4, N'520004511', N'APOCALYPTO I', N'ANCASH', N'RECUAY', N'COTAPARACO', 1)
INSERT [maestro].[Concesion] ([idConcesion], [codigoUnico], [nombre], [departamento], [provincia], [distrito], [activo]) VALUES (5, N'010235910', N'DYLAN UNO', N'JUNIN', N'TARMA', N'TARMA', 1)
INSERT [maestro].[Concesion] ([idConcesion], [codigoUnico], [nombre], [departamento], [provincia], [distrito], [activo]) VALUES (6, N'620003611', N'LIBRA I', N'JUNIN', N'HUANCAYO', N'INGENIO', 1)
SET IDENTITY_INSERT [maestro].[Concesion] OFF


SET IDENTITY_INSERT [maestro].[Transportista] ON 

INSERT [maestro].[Transportista] ([idTransportista], [ruc], [razonSocial], [direccion], [telefono], [email], [activo]) VALUES (1, N'10458618882', N'CEFERINO SIMPLICIO QUIJANO CRUZ', N'direc 01', N'3557810', N'gangelesm@correo.com', 1)
INSERT [maestro].[Transportista] ([idTransportista], [ruc], [razonSocial], [direccion], [telefono], [email], [activo]) VALUES (2, N'10446477051', N'HELTON CORONEL PACHECO', N'direc 02', N'5335455', N'hcoronelp@correo.com', 1)
INSERT [maestro].[Transportista] ([idTransportista], [ruc], [razonSocial], [direccion], [telefono], [email], [activo]) VALUES (3, N'20606160144', N'GLORIA DELIA HUAMALI CAMPOS', N'direc 03', N'4113518', N'ghuamalic@correo.com', 1)
INSERT [maestro].[Transportista] ([idTransportista], [ruc], [razonSocial], [direccion], [telefono], [email], [activo]) VALUES (4, N'20455318727', N'CONSTRUCTORA E INVERSIONES L&K SAC', N'direc 04', N'4561237', N'lk.inversiones@correo.com', 1)
INSERT [maestro].[Transportista] ([idTransportista], [ruc], [razonSocial], [direccion], [telefono], [email], [activo]) VALUES (5, N'10021053021', N'LUIS ANTONIO LOPEZ DOMINGUEZ', N'direc 05', N'7654321', N'llopezd@correo.com', 1)
INSERT [maestro].[Transportista] ([idTransportista], [ruc], [razonSocial], [direccion], [telefono], [email], [activo]) VALUES (6, N'20606160150', N'JEFOR SAC', N'direc 06', N'4112020', N'jefor@correo.com', 1)
SET IDENTITY_INSERT [maestro].[Transportista] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id], [usuario], [password], [nick], [nombres], [apellidos], [idTipoDocumento], [nroDocumento], [idEmpresa], [estado]) VALUES (12, N'cesar.garcia@creativestore.pe', N'$2a$11$go6zlxELZp9B1UU4nQBlt.5i8QqcFRw1pGeWfXdRj6WtT91dvQaum', NULL, N'Cesar', N'Garcia', 1, N'-', 1, 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET IDENTITY_INSERT [muestreo].[Muestreo] ON 

INSERT [muestreo].[Muestreo] ([idMuestreo], [codigoTurno], [codigoResponsable], [fecha], [idLote], [codigoCancha], [llevaGrueso], [codigoTrujillo], [codigoAum], [idEncargado], [codigoCondicion], [codigoEstado], [activo]) VALUES (1, 0, 0, CAST(N'2022-05-01T16:17:19.103' AS DateTime), 0, 0, 1, N'string', N'string', 0, 0, 0, 1)
INSERT [muestreo].[Muestreo] ([idMuestreo], [codigoTurno], [codigoResponsable], [fecha], [idLote], [codigoCancha], [llevaGrueso], [codigoTrujillo], [codigoAum], [idEncargado], [codigoCondicion], [codigoEstado], [activo]) VALUES (2, 14, 1, CAST(N'2022-05-01T17:43:18.930' AS DateTime), 1211, 11, 1, N'', N'', 15, 13, 12, 1)
SET IDENTITY_INSERT [muestreo].[Muestreo] OFF

SET IDENTITY_INSERT [maestro].[TipoDocumento] ON 

INSERT [maestro].[TipoDocumento] ([codigoTipoDocumento], [descripcion], [inicales], [activo]) VALUES ('1', 'DOCUMENTO NACIONAL DE IDENTIDAD (DNI)',  'DNI', 1)
INSERT [maestro].[TipoDocumento] ([codigoTipoDocumento], [descripcion], [inicales], [activo]) VALUES ('4', 'CARNET DE EXTRANJERIA', 'CE', 1)
INSERT [maestro].[TipoDocumento] ([codigoTipoDocumento], [descripcion], [inicales], [activo]) VALUES ('0', 'OTROS TIPOS DE DOCUMENTOS', 'OTR', 1)
INSERT [maestro].[TipoDocumento] ([codigoTipoDocumento], [descripcion], [inicales], [activo]) VALUES ('6', 'REGISTRO �NICO DE CONTRIBUYENTES', 'REG', 1)
INSERT [maestro].[TipoDocumento] ([codigoTipoDocumento], [descripcion], [inicales], [activo]) VALUES ('7', 'PASAPORTE', 'PAS', 1)
INSERT [maestro].[TipoDocumento] ([codigoTipoDocumento], [descripcion], [inicales], [activo]) VALUES ('A', 'C�DULA DIPLOM�TICA DE IDENTIDAD', 'CDI', 1)
SET IDENTITY_INSERT [maestro].[TipoDocumento] OFF



INSERT [balanza].[Lote] (horaAcopio, horaIngreso, vehiculos, transportistas, tickets,conductores, [codigo], [idConcesion], [idProveedor], [fechaIngreso], [fechaAcopio], [codigoEstadoTipoMaterial], [cantidadSacos], [tmh], [humedad], [tms], [codigoEstado], [observacion], [activo], tmh100, tmhBase) 
VALUES ( '','','','','','',N'0101', 0, 1, '01/02/2020', '01/02/2020', 1, N'00', 1, 0, 0, N'00', N'00', 1,0,0)
GO
