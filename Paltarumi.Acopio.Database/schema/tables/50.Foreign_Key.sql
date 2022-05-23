USE AcopioQA
GO

-- *************************************************************************************************************
-- Config - Correlativo
-- *************************************************************************************************************

ALTER TABLE config.Correlativo  ADD  CONSTRAINT fk_config_Correlativo_codigoCorrelativoTipo FOREIGN KEY(codigoCorrelativoTipo) REFERENCES config.CorrelativoTipo (codigoCorrelativoTipo)
GO


-- *************************************************************************************************************
-- Maestro - Transportista
-- *************************************************************************************************************

ALTER TABLE maestro.Transportista  ADD  CONSTRAINT fk_maestro_Transportista_codigoTipoDocumento FOREIGN KEY(codigoTipoDocumento) REFERENCES maestro.TipoDocumento (codigoTipoDocumento)
GO

ALTER TABLE maestro.Transportista  ADD  CONSTRAINT fk_maestro_Transportista_codigoUbigeo FOREIGN KEY(codigoUbigeo) REFERENCES maestro.Ubigeo (codigoUbigeo)
GO


-- *************************************************************************************************************
-- Maestro - Conductor
-- *************************************************************************************************************

ALTER TABLE maestro.Conductor  ADD  CONSTRAINT fk_maestro_Conductor_codigoTipoDocumento FOREIGN KEY(codigoTipoDocumento) REFERENCES maestro.TipoDocumento (codigoTipoDocumento)
GO

ALTER TABLE maestro.Conductor  ADD  CONSTRAINT fk_maestro_Conductor_codigoUbigeo FOREIGN KEY(codigoUbigeo) REFERENCES maestro.Ubigeo (codigoUbigeo)
GO


-- *************************************************************************************************************
-- Maestro - Vehiculo
-- *************************************************************************************************************

ALTER TABLE maestro.Vehiculo  ADD  CONSTRAINT fk_maestro_Vehiculo_idTipoVehiculo FOREIGN KEY(idTipoVehiculo) REFERENCES balanza.maestro (idMaestro)
GO

ALTER TABLE maestro.Vehiculo  ADD  CONSTRAINT fk_maestro_Vehiculo_idVehiculoMarca FOREIGN KEY(idVehiculoMarca) REFERENCES balanza.maestro (idMaestro)
GO


-- *************************************************************************************************************
-- Balanza - Lote
-- *************************************************************************************************************

ALTER TABLE balanza.Lote  ADD  CONSTRAINT fk_balanza_lote_idConcesion FOREIGN KEY(idConcesion) REFERENCES maestro.Concesion (idConcesion)
GO

ALTER TABLE balanza.Lote  ADD  CONSTRAINT fk_balanza_lote_idProveedor FOREIGN KEY(idProveedor) REFERENCES maestro.Proveedor (idProveedor)
GO

ALTER TABLE balanza.Lote  ADD  CONSTRAINT fk_balanza_lote_idEstadoTipoMaterial FOREIGN KEY(idEstadoTipoMaterial) REFERENCES balanza.Maestro (idMaestro)
GO


-- *************************************************************************************************************
-- Balanza - Ticket
-- *************************************************************************************************************

ALTER TABLE balanza.Ticket  ADD  CONSTRAINT fk_balanza_ticket_idTransportista FOREIGN KEY(idTransportista) REFERENCES maestro.Transportista (idTransportista)
GO

ALTER TABLE balanza.Ticket  ADD  CONSTRAINT fk_balanza_ticket_idConductor FOREIGN KEY(idConductor) REFERENCES maestro.Conductor (idConductor)
GO

ALTER TABLE balanza.Ticket  ADD  CONSTRAINT fk_balanza_ticket_idVehiculo FOREIGN KEY(idVehiculo) REFERENCES maestro.Vehiculo (idVehiculo)
GO

ALTER TABLE balanza.Ticket  ADD  CONSTRAINT fk_balanza_ticket_codigoUnidadMedida FOREIGN KEY(codigoUnidadMedida) REFERENCES balanza.Maestro (idMaestro)
GO

ALTER TABLE balanza.Ticket  ADD  CONSTRAINT fk_balanza_ticket_idLote FOREIGN KEY(idLote) REFERENCES balanza.Lote (idLote)
GO
