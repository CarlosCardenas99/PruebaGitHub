@echo off
	::start
	set SERVIDOR=192.168.0.2
	set USER=sa
	set PWD=@SistemaAcopio1

	set RUTA=C:\Users\usuario\source\repos\Paltarumi.Acopio\Paltarumi.Database.Scripts\

	
	sqlcmd -S %SERVIDOR% -U %USER% -P %PWD% -i %RUTA%0.Init.sql
	sqlcmd -S %SERVIDOR% -U %USER% -P %PWD% -i %RUTA%1.Tablas_Configuraciones.sql
	sqlcmd -S %SERVIDOR% -U %USER% -P %PWD% -i %RUTA%2.Tablas_Maestro.sql
	sqlcmd -S %SERVIDOR% -U %USER% -P %PWD% -i %RUTA%3.Tablas_Balanza.sql
	sqlcmd -S %SERVIDOR% -U %USER% -P %PWD% -i %RUTA%4.Tablas_Muestreo.sql
	
	sqlcmd -S %SERVIDOR% -U %USER% -P %PWD% -i %RUTA%50.Foreign_Key.sql
	sqlcmd -S %SERVIDOR% -U %USER% -P %PWD% -i %RUTA%51.Unique_Key.sql

	sqlcmd -S %SERVIDOR% -U %USER% -P %PWD% -i %RUTA%79.Data_Maestro_Ubigeo.sql
	sqlcmd -S %SERVIDOR% -U %USER% -P %PWD% -i %RUTA%80.Data_Configuraciones.sql
	sqlcmd -S %SERVIDOR% -U %USER% -P %PWD% -i %RUTA%81.Data_Balanza_Maestro.sql
	sqlcmd -S %SERVIDOR% -U %USER% -P %PWD% -i %RUTA%82.Data_Maestro.sql
	sqlcmd -S %SERVIDOR% -U %USER% -P %PWD% -i %RUTA%83.Data_Balanza.sql
	
	sqlcmd -S %SERVIDOR% -U %USER% -P %PWD% -i %RUTA%99.SystemDataType.sql

	pause
exit