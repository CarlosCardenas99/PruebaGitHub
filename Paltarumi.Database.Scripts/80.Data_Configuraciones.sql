USE AcopioQA
GO

--***********************************************
-- CORRELATIVO
INSERT config.CorrelativoTipo (codigoCorrelativoTipo, nombre, activo) VALUES (N'01', N'FACTURA', 1)
INSERT config.CorrelativoTipo (codigoCorrelativoTipo, nombre, activo) VALUES (N'03', N'BOLETA', 1)
INSERT config.CorrelativoTipo (codigoCorrelativoTipo, nombre, activo) VALUES (N'07', N'NOTA DE CREDITO', 1)
INSERT config.CorrelativoTipo (codigoCorrelativoTipo, nombre, activo) VALUES (N'08', N'NOTA DE DEBITO', 1)
INSERT config.CorrelativoTipo (codigoCorrelativoTipo, nombre, activo) VALUES (N'50', N'LOTE', 1)
INSERT config.CorrelativoTipo (codigoCorrelativoTipo, nombre, activo) VALUES (N'51', N'TICKET', 1)
GO

INSERT config.Correlativo (codigoCorrelativoTipo, serie, numero, activo) VALUES (N'01', 'F001', 700, 1)
INSERT config.Correlativo (codigoCorrelativoTipo, serie, numero, activo) VALUES (N'03', 'B001', 500, 1)
INSERT config.Correlativo (codigoCorrelativoTipo, serie, numero, activo) VALUES (N'07', 'FN01', 4, 1)
INSERT config.Correlativo (codigoCorrelativoTipo, serie, numero, activo) VALUES (N'08', 'FN02', 24, 1)
INSERT config.Correlativo (codigoCorrelativoTipo, serie, numero, activo) VALUES (N'50', '1', 1009, 1)
INSERT config.Correlativo (codigoCorrelativoTipo, serie, numero, activo) VALUES (N'51', '1', 2010, 1)
GO
