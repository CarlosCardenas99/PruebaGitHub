if exists(select name from sys.databases where name = 'AcopioQA')
begin
	print '**********************************************************************'
	print 'Ya existe la BD'
	print '**********************************************************************'	
	
	use master
	raiserror ('Ya existe la BD - Parar', 20, -1) with LOG
end
go

create database AcopioQA
go

USE AcopioQA
go

create schema config authorization dbo;
go
create schema maestro authorization dbo;
go
create schema balanza authorization dbo;
go
create schema chancado authorization dbo;
go
create schema muestreo authorization dbo;
go
create schema laboratorio authorization dbo;
go
create schema comercial authorization dbo;
go
create schema liquidaciones authorization dbo;
go
create schema fiscalizacion authorization dbo;
go
