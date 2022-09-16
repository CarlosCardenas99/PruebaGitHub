ALTER TABLE [maestro].[Concesion] ADD [RowVersion] rowversion;

ALTER TABLE [balanza].[LoteBalanza] ADD [RowVersion] rowversion;
ALTER TABLE [chancado].[LoteChancado] ADD [RowVersion] rowversion;
ALTER TABLE [muestreo].[LoteCodigoMuestreo] ADD [RowVersion] rowversion;
ALTER TABLE [muestreo].[LoteMuestreo] ADD [RowVersion] rowversion;

ALTER TABLE [acopio].[LoteCodigo] ADD [RowVersion] rowversion;