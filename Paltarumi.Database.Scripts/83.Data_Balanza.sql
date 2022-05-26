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

--*********************************************************************************************************************************************
-- LOTE
SET IDENTITY_INSERT balanza.Ticket ON

INSERT INTO balanza.Ticket(idTicket, idLote, numero, fechaIngreso, horaIngreso, fechaSalida, horaSalida, pesoBruto, tara, pesoNeto, grr, grt, idTransportista, idConductor, idVehiculo, idUnidadMedida, cantidadUnidadMedida, observacion, activo)
VALUES(1, 1, 'T001', '20/05/2022', '09:45', NULL, NULL, 40, 10, 30, '0001-001252', '0002-0001452', 1, 2, 1, 7, 15, 'PRIMER GRABADO', 1)

INSERT INTO balanza.Ticket(
idTicket, idLote, numero, fechaIngreso, horaIngreso, fechaSalida, horaSalida, pesoBruto, tara, pesoNeto, grr, grt, idTransportista, idConductor, idVehiculo, idUnidadMedida, cantidadUnidadMedida, observacion, activo)
VALUES(2, 1, 'T002', '21/05/2022', '11:45', NULL, NULL, 40, 10, 30, '0001-001382', '0001-0001885', 1, 2, 1, 7, 15, 'SEGUNDO GRABADO', 1)

INSERT INTO balanza.Ticket(
idTicket, idLote, numero, fechaIngreso, horaIngreso, fechaSalida, horaSalida, pesoBruto, tara, pesoNeto, grr, grt, idTransportista, idConductor, idVehiculo, idUnidadMedida, cantidadUnidadMedida, observacion, activo)
VALUES(3, 2, 'T003', '22/05/2022', '10:54', NULL, NULL, 40, 10, 30, '0001-001782', '0001-0002045', 1, 2, 1, 7, 15, 'TERCER GRABADO', 1)

INSERT INTO balanza.Ticket(
idTicket, idLote, numero, fechaIngreso, horaIngreso, fechaSalida, horaSalida, pesoBruto, tara, pesoNeto, grr, grt, idTransportista, idConductor, idVehiculo, idUnidadMedida, cantidadUnidadMedida, observacion, activo)
VALUES(4, 3, 'T004', '22/05/2022', '12:45', NULL, NULL, 40, 10, 30, '0001-001072', '0001-0009845', 1, 2, 1, 7, 15, 'CUARTO GRABADO', 1)

SET IDENTITY_INSERT balanza.Ticket OFF
