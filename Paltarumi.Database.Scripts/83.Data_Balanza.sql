USE AcopioQA
GO

SET DATEFORMAT DMY

--*********************************************************************************************************************************************
-- LOTE
SET IDENTITY_INSERT balanza.Lote ON
INSERT INTO balanza.Lote (idLote, codigo, idConcesion, idProveedor, vehiculos, transportistas, tickets, conductores, fechaIngreso, horaIngreso, fechaAcopio, horaAcopio, idEstadoTipoMaterial, cantidadSacos, tmh100, tmhBase, tmh, humedad, tms,codigoEstado, observacion, activo) VALUES(1, '10101', 1, 1, '', '', '', '', '20/05/2022', '09:05', NULL, NULL, 1, 15, 30, 30, 30, 2, 28 , '01', '', 1)
INSERT INTO balanza.Lote (idLote, codigo, idConcesion, idProveedor, vehiculos, transportistas, tickets, conductores, fechaIngreso, horaIngreso, fechaAcopio, horaAcopio, idEstadoTipoMaterial, cantidadSacos, tmh100, tmhBase, tmh, humedad, tms,codigoEstado, observacion, activo) VALUES(2, '10102', 2, 1, '', '', '', '', '21/05/2022', '13:48', NULL, NULL, 1, 10, 20, 20, 20, 4, 16 , '01', '', 1)
INSERT INTO balanza.Lote (idLote, codigo, idConcesion, idProveedor, vehiculos, transportistas, tickets, conductores, fechaIngreso, horaIngreso, fechaAcopio, horaAcopio, idEstadoTipoMaterial, cantidadSacos, tmh100, tmhBase, tmh, humedad, tms,codigoEstado, observacion, activo) VALUES(3, '10103', 2, 2, '', '', '', '', '22/05/2022', '15:27', NULL, NULL, 1, 50, 40, 40, 40, 8, 32 , '01', '', 1)
INSERT INTO balanza.Lote (idLote, codigo, idConcesion, idProveedor, vehiculos, transportistas, tickets, conductores, fechaIngreso, horaIngreso, fechaAcopio, horaAcopio, idEstadoTipoMaterial, cantidadSacos, tmh100, tmhBase, tmh, humedad, tms,codigoEstado, observacion, activo) VALUES(4, '10104', 1, 2, '', '', '', '', '23/05/2022', '18:21', NULL, NULL, 1, 60, 50, 50, 50, 10, 40 , '01', '', 1)
SET IDENTITY_INSERT balanza.Lote OFF

GO
