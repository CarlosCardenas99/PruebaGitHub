USE AcopioQA
GO
/*
ALTER TABLE config.ModuloUsuario  ADD  CONSTRAINT fk_config_ModuloUsuario_idModulo FOREIGN KEY(idModulo) REFERENCES config.Modulo (idModulo)
GO

ALTER TABLE config.ModuloUsuario  ADD  CONSTRAINT fk_config_ModuloUsuario_idUsuario FOREIGN KEY(idUsuario) REFERENCES config.Usuario (idUsuario)
GO

ALTER TABLE config.ModuloUsuario  ADD  CONSTRAINT fk_config_ModuloUsuario_idEmpresa FOREIGN KEY(idEmpresa) REFERENCES config.Empresa (idEmpresa)
GO

ALTER TABLE config.Usuario  ADD  CONSTRAINT fk_config_Usuario_idEmpresa FOREIGN KEY(idEmpresa) REFERENCES config.Empresa (idEmpresa)
GO

ALTER TABLE config.Usuario  ADD  CONSTRAINT fk_config_Usuario_idTipoDocumento FOREIGN KEY(idTipoDocumento) REFERENCES maestro.TipoDocumento (idTipoDocumento)
GO
*/
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
