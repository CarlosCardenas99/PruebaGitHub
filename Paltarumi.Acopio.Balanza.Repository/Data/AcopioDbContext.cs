using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Paltarumi.Acopio.Balanza.Entity;

namespace Paltarumi.Acopio.Balanza.Repository.Data
{
    public partial class AcopioDbContext : DbContext
    {
        public AcopioDbContext()
        {
        }

        public AcopioDbContext(DbContextOptions<AcopioDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Archivo> Archivos { get; set; } = null!;
        public virtual DbSet<Asignacion> Asignacions { get; set; } = null!;
        public virtual DbSet<Cancha> Canchas { get; set; } = null!;
        public virtual DbSet<CheckList> CheckLists { get; set; } = null!;
        public virtual DbSet<ComisionEstado> ComisionEstados { get; set; } = null!;
        public virtual DbSet<Comisionistum> Comisionista { get; set; } = null!;
        public virtual DbSet<Comprobante> Comprobantes { get; set; } = null!;
        public virtual DbSet<ComprobanteConcepto> ComprobanteConceptos { get; set; } = null!;
        public virtual DbSet<ComprobanteDetalle> ComprobanteDetalles { get; set; } = null!;
        public virtual DbSet<ComprobanteDetalleEstado> ComprobanteDetalleEstados { get; set; } = null!;
        public virtual DbSet<ComprobanteEstado> ComprobanteEstados { get; set; } = null!;
        public virtual DbSet<ComprobanteGrupo> ComprobanteGrupos { get; set; } = null!;
        public virtual DbSet<ComprobanteGrupoDetalle> ComprobanteGrupoDetalles { get; set; } = null!;
        public virtual DbSet<ComprobantePago> ComprobantePagos { get; set; } = null!;
        public virtual DbSet<Concesion> Concesions { get; set; } = null!;
        public virtual DbSet<Conductor> Conductors { get; set; } = null!;
        public virtual DbSet<Correlativo> Correlativos { get; set; } = null!;
        public virtual DbSet<CorrelativoTipo> CorrelativoTipos { get; set; } = null!;
        public virtual DbSet<Divisa> Divisas { get; set; } = null!;
        public virtual DbSet<DuenoMuestra> DuenoMuestras { get; set; } = null!;
        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Insumo> Insumos { get; set; } = null!;
        public virtual DbSet<ItemCheck> ItemChecks { get; set; } = null!;
        public virtual DbSet<JapBlackList> JapBlackLists { get; set; } = null!;
        public virtual DbSet<Lote> Lotes { get; set; } = null!;
        public virtual DbSet<LoteBalanza> LoteBalanzas { get; set; } = null!;
        public virtual DbSet<LoteChancado> LoteChancados { get; set; } = null!;
        public virtual DbSet<LoteChancadoEstado> LoteChancadoEstados { get; set; } = null!;
        public virtual DbSet<LoteChancadoGrupo> LoteChancadoGrupos { get; set; } = null!;
        public virtual DbSet<LoteCheckList> LoteCheckLists { get; set; } = null!;
        public virtual DbSet<LoteCodigo> LoteCodigos { get; set; } = null!;
        public virtual DbSet<LoteCodigoControl> LoteCodigoControls { get; set; } = null!;
        public virtual DbSet<LoteCodigoEnsayo> LoteCodigoEnsayos { get; set; } = null!;
        public virtual DbSet<LoteCodigoEnsayoDetalle> LoteCodigoEnsayoDetalles { get; set; } = null!;
        public virtual DbSet<LoteCodigoEnsayoOrigen> LoteCodigoEnsayoOrigens { get; set; } = null!;
        public virtual DbSet<LoteCodigoEstado> LoteCodigoEstados { get; set; } = null!;
        public virtual DbSet<LoteCodigoLiquidacion> LoteCodigoLiquidacions { get; set; } = null!;
        public virtual DbSet<LoteCodigoMuestreo> LoteCodigoMuestreos { get; set; } = null!;
        public virtual DbSet<LoteCodigoNomenclatura> LoteCodigoNomenclaturas { get; set; } = null!;
        public virtual DbSet<LoteCodigoPm> LoteCodigoPms { get; set; } = null!;
        public virtual DbSet<LoteCodigoTipo> LoteCodigoTipos { get; set; } = null!;
        public virtual DbSet<LoteEstado> LoteEstados { get; set; } = null!;
        public virtual DbSet<LoteLiquidacion> LoteLiquidacions { get; set; } = null!;
        public virtual DbSet<LoteLiquidacionAdelanto> LoteLiquidacionAdelantos { get; set; } = null!;
        public virtual DbSet<LoteLiquidacionAsignacion> LoteLiquidacionAsignacions { get; set; } = null!;
        public virtual DbSet<LoteLiquidacionComision> LoteLiquidacionComisions { get; set; } = null!;
        public virtual DbSet<LoteLiquidacionComisionAsignacion> LoteLiquidacionComisionAsignacions { get; set; } = null!;
        public virtual DbSet<LoteLiquidacionConsumo> LoteLiquidacionConsumos { get; set; } = null!;
        public virtual DbSet<LoteLiquidacionEstado> LoteLiquidacionEstados { get; set; } = null!;
        public virtual DbSet<LoteLiquidacionGasto> LoteLiquidacionGastos { get; set; } = null!;
        public virtual DbSet<LoteLiquidacionTipoMetal> LoteLiquidacionTipoMetals { get; set; } = null!;
        public virtual DbSet<LoteMuestreo> LoteMuestreos { get; set; } = null!;
        public virtual DbSet<LoteOperacion> LoteOperacions { get; set; } = null!;
        public virtual DbSet<Maestro> Maestros { get; set; } = null!;
        public virtual DbSet<Mapa> Mapas { get; set; } = null!;
        public virtual DbSet<MineralCondicion> MineralCondicions { get; set; } = null!;
        public virtual DbSet<Modulo> Modulos { get; set; } = null!;
        public virtual DbSet<MuestraCondicion> MuestraCondicions { get; set; } = null!;
        public virtual DbSet<Operacion> Operacions { get; set; } = null!;
        public virtual DbSet<PropiedadCalculo> PropiedadCalculos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<ProveedorConcesion> ProveedorConcesions { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;
        public virtual DbSet<SystemDataType> SystemDataTypes { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<TicketBackup> TicketBackups { get; set; } = null!;
        public virtual DbSet<TipoComprobante> TipoComprobantes { get; set; } = null!;
        public virtual DbSet<TipoCosto> TipoCostos { get; set; } = null!;
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; } = null!;
        public virtual DbSet<TipoLiquidacion> TipoLiquidacions { get; set; } = null!;
        public virtual DbSet<TipoMedioPago> TipoMedioPagos { get; set; } = null!;
        public virtual DbSet<TipoMetal> TipoMetals { get; set; } = null!;
        public virtual DbSet<TipoMineral> TipoMinerals { get; set; } = null!;
        public virtual DbSet<TipoProporcion> TipoProporcions { get; set; } = null!;
        public virtual DbSet<Transporte> Transportes { get; set; } = null!;
        public virtual DbSet<TransporteVehiculo> TransporteVehiculos { get; set; } = null!;
        public virtual DbSet<Ubigeo> Ubigeos { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archivo>(entity =>
            {
                entity.HasKey(e => e.IdArchivo)
                    .HasName("PK_Archivo_idArchivo");

                entity.ToTable("Archivo", "acopio");

                entity.Property(e => e.IdArchivo).HasColumnName("idArchivo");

                entity.Property(e => e.CloudSync).HasColumnName("cloudSync");

                entity.Property(e => e.CloudSyncResult).HasColumnName("cloudSyncResult");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.DirectoryPath)
                    .HasMaxLength(256)
                    .HasColumnName("directoryPath");

                entity.Property(e => e.DirectorySync).HasColumnName("directorySync");

                entity.Property(e => e.DirectorySyncResult).HasColumnName("directorySyncResult");

                entity.Property(e => e.Entidad)
                    .HasMaxLength(256)
                    .HasColumnName("entidad");

                entity.Property(e => e.FileContentType)
                    .HasMaxLength(1024)
                    .HasColumnName("fileContentType");

                entity.Property(e => e.FileName)
                    .HasMaxLength(256)
                    .HasColumnName("fileName");

                entity.Property(e => e.FtpSync).HasColumnName("ftpSync");

                entity.Property(e => e.FtpSyncResult).HasColumnName("ftpSyncResult");

                entity.Property(e => e.Identificador).HasColumnName("identificador");

                entity.Property(e => e.UserNameCreate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameCreate");
            });

            modelBuilder.Entity<Asignacion>(entity =>
            {
                entity.HasKey(e => e.IdAsignacion)
                    .HasName("PK_liquidaciones_Asignacion_idAsignacion");

                entity.ToTable("Asignacion", "liquidaciones");

                entity.Property(e => e.IdAsignacion).HasColumnName("idAsignacion");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.IdDivisa)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("idDivisa")
                    .IsFixedLength();

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subTotal");

                entity.Property(e => e.SubTotalEmpresa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subTotalEmpresa");

                entity.Property(e => e.SubTotalProveedor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subTotalProveedor");

                entity.Property(e => e.TipoCambio)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tipoCambio");

                entity.HasOne(d => d.IdDivisaNavigation)
                    .WithMany(p => p.Asignacions)
                    .HasForeignKey(d => d.IdDivisa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_liquidaciones_Asignacion_idDivisa");
            });

            modelBuilder.Entity<Cancha>(entity =>
            {
                entity.HasKey(e => e.IdCancha)
                    .HasName("PK_chancado_Cancha_idCancha");

                entity.ToTable("Cancha", "chancado");

                entity.Property(e => e.IdCancha)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idCancha")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<CheckList>(entity =>
            {
                entity.HasKey(e => e.IdCheckList)
                    .HasName("PK_acopio_CheckList_idCheckList");

                entity.ToTable("CheckList", "acopio");

                entity.Property(e => e.IdCheckList).HasColumnName("idCheckList");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.IdItemCheck).HasColumnName("idItemCheck");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.Property(e => e.Mandatorio).HasColumnName("mandatorio");

                entity.HasOne(d => d.IdItemCheckNavigation)
                    .WithMany(p => p.CheckLists)
                    .HasForeignKey(d => d.IdItemCheck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_acopio_CheckList_idItemCheck");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.CheckLists)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_acopio_CheckList_idModulo");
            });

            modelBuilder.Entity<ComisionEstado>(entity =>
            {
                entity.HasKey(e => e.IdComisionEstado)
                    .HasName("PK_liquidaciones_ComisionEstado_idComisionEstado");

                entity.ToTable("ComisionEstado", "liquidaciones");

                entity.Property(e => e.IdComisionEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idComisionEstado")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<Comisionistum>(entity =>
            {
                entity.HasKey(e => e.IdComisionistum)
                    .HasName("PK_maestro_Comisionistum_idComisionistum");

                entity.ToTable("Comisionistum", "maestro");

                entity.Property(e => e.IdComisionistum).HasColumnName("idComisionistum");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoTipoDocumento)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("codigoTipoDocumento")
                    .IsFixedLength();

                entity.Property(e => e.CodigoUbigeo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("codigoUbigeo")
                    .IsFixedLength();

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("domicilio");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.Numero)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.CodigoTipoDocumentoNavigation)
                    .WithMany(p => p.Comisionista)
                    .HasForeignKey(d => d.CodigoTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestro_Comisionistum_codigoTipoDocumento");
            });

            modelBuilder.Entity<Comprobante>(entity =>
            {
                entity.HasKey(e => e.IdComprobante)
                    .HasName("PK_pagos_Comprobante_idComprobante");

                entity.ToTable("Comprobante", "pagos");

                entity.Property(e => e.IdComprobante).HasColumnName("idComprobante");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.Detraccion)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("detraccion");

                entity.Property(e => e.FechaEmision).HasColumnName("fechaEmision");

                entity.Property(e => e.FechaVencimiento).HasColumnName("fechaVencimiento");

                entity.Property(e => e.Glosa)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("glosa");

                entity.Property(e => e.IdComprobanteEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idComprobanteEstado")
                    .IsFixedLength();

                entity.Property(e => e.IdComprobanteGrupo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idComprobanteGrupo")
                    .IsFixedLength();

                entity.Property(e => e.IdDivisa)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("idDivisa")
                    .IsFixedLength();

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.IdSucursal)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idSucursal")
                    .IsFixedLength();

                entity.Property(e => e.IdTipoComprobante)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoComprobante")
                    .IsFixedLength();

                entity.Property(e => e.Igv)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("igv");

                entity.Property(e => e.Lotes)
                    .IsUnicode(false)
                    .HasColumnName("lotes");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.PorcentajeDetraccion).HasColumnName("porcentajeDetraccion");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("rowVersion");

                entity.Property(e => e.Serie)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("serie");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subTotal");

                entity.Property(e => e.SubTotalNotaCredito)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subTotalNotaCredito");

                entity.Property(e => e.SubTotalNotaDebito)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subTotalNotaDebito");

                entity.Property(e => e.TipoCambio)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("tipoCambio");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total");

                entity.Property(e => e.TotalNeto)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("totalNeto");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");

                entity.Property(e => e.UserNameCreate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameCreate");

                entity.Property(e => e.UserNameUpdate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameUpdate");

                entity.HasOne(d => d.IdComprobanteEstadoNavigation)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdComprobanteEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pagos_Comprobante_idComprobanteEstado");

                entity.HasOne(d => d.IdComprobanteGrupoNavigation)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdComprobanteGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pagos_Comprobante_idComprobanteGrupo");

                entity.HasOne(d => d.IdDivisaNavigation)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdDivisa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pagos_Comprobante_idDivisa");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pagos_Comprobante_idProveedor");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pagos_Comprobante_idSucursal");

                entity.HasOne(d => d.IdTipoComprobanteNavigation)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdTipoComprobante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pagos_Comprobante_idTipoComprobante");
            });

            modelBuilder.Entity<ComprobanteConcepto>(entity =>
            {
                entity.HasKey(e => e.IdComprobanteConcepto)
                    .HasName("PK_pagos_ComprobanteConcepto_idComprobanteConcepto");

                entity.ToTable("ComprobanteConcepto", "pagos");

                entity.Property(e => e.IdComprobanteConcepto).HasColumnName("idComprobanteConcepto");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.IdComprobanteGrupo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idComprobanteGrupo")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ComprobanteDetalle>(entity =>
            {
                entity.HasKey(e => e.IdComprobanteDetalle)
                    .HasName("PK_pagos_ComprobanteDetalle_idComprobanteDetalle");

                entity.ToTable("ComprobanteDetalle", "pagos");

                entity.Property(e => e.IdComprobanteDetalle).HasColumnName("idComprobanteDetalle");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cantidad");

                entity.Property(e => e.IdComprobante).HasColumnName("idComprobante");

                entity.Property(e => e.IdComprobanteConcepto).HasColumnName("idComprobanteConcepto");

                entity.Property(e => e.IdComprobanteDetalleEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idComprobanteDetalleEstado")
                    .IsFixedLength();

                entity.Property(e => e.IdComprobanteDetalleReferencia).HasColumnName("idComprobanteDetalleReferencia");

                entity.Property(e => e.IdPropiedadCalculo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idPropiedadCalculo")
                    .IsFixedLength();

                entity.Property(e => e.Igv)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("igv");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("rowVersion");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subTotal");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total");

                entity.Property(e => e.ValorUnitario)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorUnitario");

                entity.HasOne(d => d.IdComprobanteNavigation)
                    .WithMany(p => p.ComprobanteDetalles)
                    .HasForeignKey(d => d.IdComprobante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pagos_ComprobanteDetalle_idComprobante");

                entity.HasOne(d => d.IdComprobanteConceptoNavigation)
                    .WithMany(p => p.ComprobanteDetalles)
                    .HasForeignKey(d => d.IdComprobanteConcepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pagos_ComprobanteDetalle_idComprobanteConcepto");

                entity.HasOne(d => d.IdComprobanteDetalleEstadoNavigation)
                    .WithMany(p => p.ComprobanteDetalles)
                    .HasForeignKey(d => d.IdComprobanteDetalleEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pagos_ComprobanteDetalle_idComprobanteDetalleEstado");

                entity.HasOne(d => d.IdPropiedadCalculoNavigation)
                    .WithMany(p => p.ComprobanteDetalles)
                    .HasForeignKey(d => d.IdPropiedadCalculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pagos_ComprobanteDetalle_idPropiedadCalculo");
            });

            modelBuilder.Entity<ComprobanteDetalleEstado>(entity =>
            {
                entity.HasKey(e => e.IdComprobanteDetalleEstado)
                    .HasName("PK_pagos_ComprobanteDetalleEstado_idComprobanteDetalleEstado");

                entity.ToTable("ComprobanteDetalleEstado", "pagos");

                entity.Property(e => e.IdComprobanteDetalleEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idComprobanteDetalleEstado")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<ComprobanteEstado>(entity =>
            {
                entity.HasKey(e => e.IdComprobanteEstado)
                    .HasName("PK_pagos_ComprobanteEstado_idComprobanteEstado");

                entity.ToTable("ComprobanteEstado", "pagos");

                entity.Property(e => e.IdComprobanteEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idComprobanteEstado")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<ComprobanteGrupo>(entity =>
            {
                entity.HasKey(e => e.IdComprobanteGrupo)
                    .HasName("PK_pagos_ComprobanteGrupo_idComprobanteGrupo");

                entity.ToTable("ComprobanteGrupo", "pagos");

                entity.Property(e => e.IdComprobanteGrupo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idComprobanteGrupo")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ComprobanteGrupoDetalle>(entity =>
            {
                entity.HasKey(e => e.IdComprobanteGrupoDetalle)
                    .HasName("PK_pagos_ComprobanteGrupoDetalle_idComprobanteGrupoDetalle");

                entity.ToTable("ComprobanteGrupoDetalle", "pagos");

                entity.Property(e => e.IdComprobanteGrupoDetalle).HasColumnName("idComprobanteGrupoDetalle");

                entity.Property(e => e.IdComprobanteGrupo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idComprobanteGrupo")
                    .IsFixedLength();

                entity.Property(e => e.IdTipoComprobante)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoComprobante")
                    .IsFixedLength();

                entity.HasOne(d => d.IdComprobanteGrupoNavigation)
                    .WithMany(p => p.ComprobanteGrupoDetalles)
                    .HasForeignKey(d => d.IdComprobanteGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pagos_ComprobanteGrupoDetalle_idComprobanteGrupo");

                entity.HasOne(d => d.IdTipoComprobanteNavigation)
                    .WithMany(p => p.ComprobanteGrupoDetalles)
                    .HasForeignKey(d => d.IdTipoComprobante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pagos_ComprobanteGrupoDetalle_idTipoComprobante");
            });

            modelBuilder.Entity<ComprobantePago>(entity =>
            {
                entity.HasKey(e => e.IdComprobantePago)
                    .HasName("PK_pagos_ComprobantePago_idComprobantePago");

                entity.ToTable("ComprobantePago", "pagos");

                entity.Property(e => e.IdComprobantePago).HasColumnName("idComprobantePago");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaPago).HasColumnName("fechaPago");

                entity.Property(e => e.IdComprobante).HasColumnName("idComprobante");

                entity.Property(e => e.IdDivisa)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("idDivisa")
                    .IsFixedLength();

                entity.Property(e => e.IdDivisaCalculo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("idDivisaCalculo")
                    .IsFixedLength();

                entity.Property(e => e.IdTipoMedioPago)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("idTipoMedioPago")
                    .IsFixedLength();

                entity.Property(e => e.NumeroBancario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numeroBancario");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.Property(e => e.SubTotalDolares)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subTotalDolares");

                entity.Property(e => e.SubTotalSoles)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subTotalSoles");

                entity.Property(e => e.TipoCambio)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tipoCambio");
            });

            modelBuilder.Entity<Concesion>(entity =>
            {
                entity.HasKey(e => e.IdConcesion)
                    .HasName("PK_maestro_Concesion_idConcesion");

                entity.ToTable("Concesion", "maestro");

                entity.HasIndex(e => e.CodigoUnico, "UC_maestro_Concesion_codigoUnico")
                    .IsUnique();

                entity.Property(e => e.IdConcesion).HasColumnName("idConcesion");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoUbigeo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("codigoUbigeo")
                    .IsFixedLength();

                entity.Property(e => e.CodigoUnico)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("codigoUnico");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.HasKey(e => e.IdConductor)
                    .HasName("PK_maestro_Conductor_idConductor");

                entity.ToTable("Conductor", "maestro");

                entity.Property(e => e.IdConductor).HasColumnName("idConductor");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoTipoDocumento)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("codigoTipoDocumento")
                    .IsFixedLength();

                entity.Property(e => e.CodigoUbigeo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("codigoUbigeo")
                    .IsFixedLength();

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("domicilio");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoLicencia).HasColumnName("idTipoLicencia");

                entity.Property(e => e.Licencia)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("licencia");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.Numero)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.CodigoTipoDocumentoNavigation)
                    .WithMany(p => p.Conductors)
                    .HasForeignKey(d => d.CodigoTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestro_Conductor_codigoTipoDocumento");

                entity.HasOne(d => d.CodigoUbigeoNavigation)
                    .WithMany(p => p.Conductors)
                    .HasForeignKey(d => d.CodigoUbigeo)
                    .HasConstraintName("fk_maestro_Conductor_codigoUbigeo");

                entity.HasOne(d => d.IdTipoLicenciaNavigation)
                    .WithMany(p => p.Conductors)
                    .HasForeignKey(d => d.IdTipoLicencia)
                    .HasConstraintName("fk_maestro_Conductor_idTipoLicencia");
            });

            modelBuilder.Entity<Correlativo>(entity =>
            {
                entity.HasKey(e => e.IdCorrelativo)
                    .HasName("PK_maestro_Correlativo_idCorrelativo");

                entity.ToTable("Correlativo", "maestro");

                entity.HasIndex(e => new { e.IdEmpresa, e.CodigoCorrelativoTipo, e.Serie, e.IdSucursal }, "UC_maestro_Correlativo")
                    .IsUnique();

                entity.Property(e => e.IdCorrelativo).HasColumnName("idCorrelativo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoCorrelativoTipo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("codigoCorrelativoTipo")
                    .IsFixedLength();

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdSucursal)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idSucursal")
                    .IsFixedLength();

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Serie)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("serie");

                entity.HasOne(d => d.CodigoCorrelativoTipoNavigation)
                    .WithMany(p => p.Correlativos)
                    .HasForeignKey(d => d.CodigoCorrelativoTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestro_Correlativo_codigoCorrelativoTipo");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Correlativos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestro_Correlativo_idEmpresa");
            });

            modelBuilder.Entity<CorrelativoTipo>(entity =>
            {
                entity.HasKey(e => e.CodigoCorrelativoTipo)
                    .HasName("PK_maestro_CorrelativoTipo_codigoCorrelativoTipo");

                entity.ToTable("CorrelativoTipo", "maestro");

                entity.Property(e => e.CodigoCorrelativoTipo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("codigoCorrelativoTipo")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Divisa>(entity =>
            {
                entity.HasKey(e => e.IdDivisa)
                    .HasName("PK_maestro_Divisa");

                entity.ToTable("Divisa", "maestro");

                entity.Property(e => e.IdDivisa)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("idDivisa")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<DuenoMuestra>(entity =>
            {
                entity.HasKey(e => e.IdDuenoMuestra)
                    .HasName("PK_maestro_DuenoMuestra_idDuenoMuestra");

                entity.ToTable("DuenoMuestra", "maestro");

                entity.Property(e => e.IdDuenoMuestra).HasColumnName("idDuenoMuestra");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoTipoDocumento)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("codigoTipoDocumento")
                    .IsFixedLength();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.Numero)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.CodigoTipoDocumentoNavigation)
                    .WithMany(p => p.DuenoMuestras)
                    .HasForeignKey(d => d.CodigoTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestro_DuenoMuestra_codigoTipoDocumento");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK_maestro_Empresa_idEmpresa");

                entity.ToTable("Empresa", "maestro");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoTipoDocumento)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("codigoTipoDocumento")
                    .IsFixedLength();

                entity.Property(e => e.CodigoUbigeo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("codigoUbigeo")
                    .IsFixedLength();

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("domicilio");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Numero)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.Prefijo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("prefijo");

                entity.Property(e => e.Propietario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("propietario");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("razonSocial");

                entity.Property(e => e.RutaSunat)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("rutaSunat");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.CodigoTipoDocumentoNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.CodigoTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestro_Empresa_codigoTipoDocumento");
            });

            modelBuilder.Entity<Insumo>(entity =>
            {
                entity.HasKey(e => e.IdInsumo)
                    .HasName("PK_maestro_Insumo_idInsumo");

                entity.ToTable("Insumo", "maestro");

                entity.Property(e => e.IdInsumo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idInsumo")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Simbolo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("simbolo");
            });

            modelBuilder.Entity<ItemCheck>(entity =>
            {
                entity.HasKey(e => e.IdItemCheck)
                    .HasName("PK_maestro_ItemCheck_idItemCheck");

                entity.ToTable("ItemCheck", "acopio");

                entity.Property(e => e.IdItemCheck).HasColumnName("idItemCheck");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("concepto");
            });

            modelBuilder.Entity<JapBlackList>(entity =>
            {
                entity.ToTable("JapBlackList");

                entity.Property(e => e.JapBlackListId)
                    .ValueGeneratedNever()
                    .HasColumnName("japBlackListId");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.ObjectName)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("objectName");

                entity.Property(e => e.ObjectSchema)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("objectSchema");

                entity.Property(e => e.ObjectType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("objectType");
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasKey(e => e.IdLote)
                    .HasName("PK_acopio_idLote");

                entity.ToTable("Lote", "acopio");

                entity.HasIndex(e => e.CodigoLote, "UC_acopio_Lote_codigoLote")
                    .IsUnique();

                entity.Property(e => e.IdLote).HasColumnName("idLote");

                entity.Property(e => e.CodigoLote)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigoLote");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");

                entity.Property(e => e.UserNameCreate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameCreate");

                entity.Property(e => e.UserNameUpdate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameUpdate");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Lotes)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_acopio_Lote_idEmpresa");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Lotes)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_acopio_Lote_idEstado");
            });

            modelBuilder.Entity<LoteBalanza>(entity =>
            {
                entity.HasKey(e => e.IdLoteBalanza)
                    .HasName("PK_balanza_LoteBalanza_idLoteBalanza");

                entity.ToTable("LoteBalanza", "balanza");

                entity.HasIndex(e => e.CodigoLote, "UC_balanza_LoteBalanza_codigoLote")
                    .IsUnique();

                entity.Property(e => e.IdLoteBalanza).HasColumnName("idLoteBalanza");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CantidadSacos).HasColumnName("cantidadSacos");

                entity.Property(e => e.CodigoAum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigoAum");

                entity.Property(e => e.CodigoLote)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigoLote");

                entity.Property(e => e.CodigoTrujillo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigoTrujillo");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.FechaAcopio).HasColumnName("fechaAcopio");

                entity.Property(e => e.FechaIngreso).HasColumnName("fechaIngreso");

                entity.Property(e => e.Humedad)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("humedad");

                entity.Property(e => e.IdConcesion).HasColumnName("idConcesion");

                entity.Property(e => e.IdCorrelativo).HasColumnName("idCorrelativo");

                entity.Property(e => e.IdEstadoTipoMaterial).HasColumnName("idEstadoTipoMaterial");

                entity.Property(e => e.IdLoteEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteEstado")
                    .HasDefaultValueSql("('01')")
                    .IsFixedLength();

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.Property(e => e.PorcentajeCheckList).HasColumnName("porcentajeCheckList");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("rowVersion");

                entity.Property(e => e.Tmh)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tmh");

                entity.Property(e => e.Tmh100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tmh100");

                entity.Property(e => e.TmhBase)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tmhBase");

                entity.Property(e => e.Tms)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tms");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");

                entity.Property(e => e.UserNameCreate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameCreate");

                entity.Property(e => e.UserNameUpdate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameUpdate");

                entity.HasOne(d => d.IdConcesionNavigation)
                    .WithMany(p => p.LoteBalanzas)
                    .HasForeignKey(d => d.IdConcesion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_LoteBalanza_idConcesion");

                entity.HasOne(d => d.IdCorrelativoNavigation)
                    .WithMany(p => p.LoteBalanzas)
                    .HasForeignKey(d => d.IdCorrelativo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_LoteBalanza_idCorrelativo");

                entity.HasOne(d => d.IdEstadoTipoMaterialNavigation)
                    .WithMany(p => p.LoteBalanzas)
                    .HasForeignKey(d => d.IdEstadoTipoMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_LoteBalanza_idEstadoTipoMaterial");

                entity.HasOne(d => d.IdLoteEstadoNavigation)
                    .WithMany(p => p.LoteBalanzas)
                    .HasForeignKey(d => d.IdLoteEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_LoteBalanza_idLoteEstado");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.LoteBalanzas)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_LoteBalanza_idProveedor");
            });

            modelBuilder.Entity<LoteChancado>(entity =>
            {
                entity.HasKey(e => e.IdLoteChancado)
                    .HasName("PK_chancado_LoteChancado_idLoteChacado");

                entity.ToTable("LoteChancado", "chancado");

                entity.HasIndex(e => e.CodigoLote, "UC_chancado_LoteChancado_codigoLote")
                    .IsUnique();

                entity.Property(e => e.IdLoteChancado).HasColumnName("idLoteChancado");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoLote)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigoLote");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.FechaRecepcion).HasColumnName("fechaRecepcion");

                entity.Property(e => e.IdLoteChancadoEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteChancadoEstado")
                    .IsFixedLength();

                entity.Property(e => e.IdLoteEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteEstado")
                    .HasDefaultValueSql("('01')")
                    .IsFixedLength();

                entity.Property(e => e.IdMineralCondicion)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idMineralCondicion")
                    .IsFixedLength();

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.ObservacionBalanza)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observacionBalanza")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Placa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("placa");

                entity.Property(e => e.PlacaCarreta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("placaCarreta");

                entity.Property(e => e.PlacasCarretaTicket)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("placasCarretaTicket");

                entity.Property(e => e.PlacasTicket)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("placasTicket");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("rowVersion");

                entity.Property(e => e.Tmh)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tmh");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");

                entity.Property(e => e.UserNameCreate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameCreate");

                entity.Property(e => e.UserNameUpdate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameUpdate");

                entity.HasOne(d => d.IdLoteChancadoEstadoNavigation)
                    .WithMany(p => p.LoteChancados)
                    .HasForeignKey(d => d.IdLoteChancadoEstado)
                    .HasConstraintName("fk_chancado_LoteChancado_idLoteChancadoEstado");

                entity.HasOne(d => d.IdLoteEstadoNavigation)
                    .WithMany(p => p.LoteChancados)
                    .HasForeignKey(d => d.IdLoteEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chancado_LoteChancado_idLoteEstado");

                entity.HasOne(d => d.IdMineralCondicionNavigation)
                    .WithMany(p => p.LoteChancados)
                    .HasForeignKey(d => d.IdMineralCondicion)
                    .HasConstraintName("fk_chancado_LoteChancado_idMineralCondicion");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.LoteChancados)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chancado_LoteChancado_idProveedor");
            });

            modelBuilder.Entity<LoteChancadoEstado>(entity =>
            {
                entity.HasKey(e => e.IdLoteChancadoEstado)
                    .HasName("PK_chancado_LoteChancadoEstado_idLoteChancadoEstado");

                entity.ToTable("LoteChancadoEstado", "chancado");

                entity.Property(e => e.IdLoteChancadoEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteChancadoEstado")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<LoteChancadoGrupo>(entity =>
            {
                entity.HasKey(e => e.IdLoteChancadoGrupo)
                    .HasName("PK_chancado_LoteChancadoGrupo_idLoteChancadoGrupo");

                entity.ToTable("LoteChancadoGrupo", "chancado");

                entity.Property(e => e.IdLoteChancadoGrupo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteChancadoGrupo")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<LoteCheckList>(entity =>
            {
                entity.HasKey(e => e.IdLoteCheckList)
                    .HasName("PK_acopio_idLoteCheckList");

                entity.ToTable("LoteCheckList", "acopio");

                entity.Property(e => e.IdLoteCheckList).HasColumnName("idLoteCheckList");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Adjunto)
                    .HasColumnType("text")
                    .HasColumnName("adjunto");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.IdCheckListEstado).HasColumnName("idCheckListEstado");

                entity.Property(e => e.IdLote).HasColumnName("idLote");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.Property(e => e.UserNameCreate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameCreate");
            });

            modelBuilder.Entity<LoteCodigo>(entity =>
            {
                entity.HasKey(e => e.IdLoteCodigo)
                    .HasName("PK_acopio_LoteCodigo_idLoteCodigo");

                entity.ToTable("LoteCodigo", "acopio");

                entity.Property(e => e.IdLoteCodigo).HasColumnName("idLoteCodigo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoMuestraProveedor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigoMuestraProveedor");

                entity.Property(e => e.CodigoPlanta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigoPlanta");

                entity.Property(e => e.CodigoPlantaRandom)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("codigoPlantaRandom");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.EnsayoConsumo).HasColumnName("ensayoConsumo");

                entity.Property(e => e.EnsayoLeyAg).HasColumnName("ensayoLeyAg");

                entity.Property(e => e.EnsayoLeyAu).HasColumnName("ensayoLeyAu");

                entity.Property(e => e.EnsayoPorcentajeRecuperacion).HasColumnName("ensayoPorcentajeRecuperacion");

                entity.Property(e => e.FechaRecepcion).HasColumnName("fechaRecepcion");

                entity.Property(e => e.IdCorrelativo).HasColumnName("idCorrelativo");

                entity.Property(e => e.IdDuenoMuestra).HasColumnName("idDuenoMuestra");

                entity.Property(e => e.IdLote).HasColumnName("idLote");

                entity.Property(e => e.IdLoteCodigoEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteCodigoEstado")
                    .IsFixedLength();

                entity.Property(e => e.IdLoteCodigoTipo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteCodigoTipo")
                    .IsFixedLength();

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");

                entity.Property(e => e.UserNameCreate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameCreate");

                entity.Property(e => e.UserNameUpdate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameUpdate");

                entity.HasOne(d => d.IdCorrelativoNavigation)
                    .WithMany(p => p.LoteCodigos)
                    .HasForeignKey(d => d.IdCorrelativo)
                    .HasConstraintName("fk_acopio_LoteCodigo_idCorrelativo");

                entity.HasOne(d => d.IdDuenoMuestraNavigation)
                    .WithMany(p => p.LoteCodigos)
                    .HasForeignKey(d => d.IdDuenoMuestra)
                    .HasConstraintName("FK_acopio_LoteCodigo_idDuenoMuestra");

                entity.HasOne(d => d.IdLoteNavigation)
                    .WithMany(p => p.LoteCodigos)
                    .HasForeignKey(d => d.IdLote)
                    .HasConstraintName("fk_acopio_LoteCodigo_idLoteBalanza");

                entity.HasOne(d => d.IdLoteCodigoEstadoNavigation)
                    .WithMany(p => p.LoteCodigos)
                    .HasForeignKey(d => d.IdLoteCodigoEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_acopio_LoteCodigo_idLoteCodigoEstado");

                entity.HasOne(d => d.IdLoteCodigoTipoNavigation)
                    .WithMany(p => p.LoteCodigos)
                    .HasForeignKey(d => d.IdLoteCodigoTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_acopio_LoteCodigo_idLoteCodigoTipo");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.LoteCodigos)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_acopio_LoteCodigo_idProveedor");
            });

            modelBuilder.Entity<LoteCodigoControl>(entity =>
            {
                entity.HasKey(e => e.IdLoteCodigoControl)
                    .HasName("PK_acopio_LoteCodigoControl_idLoteCodigoControl");

                entity.ToTable("LoteCodigoControl", "acopio");

                entity.Property(e => e.IdLoteCodigoControl).HasColumnName("idLoteCodigoControl");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.BloqueCodigo)
                    .HasColumnType("text")
                    .HasColumnName("bloqueCodigo");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.UserNameCreate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameCreate");
            });

            modelBuilder.Entity<LoteCodigoEnsayo>(entity =>
            {
                entity.HasKey(e => e.IdLoteCodigoEnsayo)
                    .HasName("PK_laboratorio_idLoteCodigoEnsayo");

                entity.ToTable("LoteCodigoEnsayo", "laboratorio");

                entity.Property(e => e.IdLoteCodigoEnsayo).HasColumnName("idLoteCodigoEnsayo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoPlantaRandom)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("codigoPlantaRandom");

                entity.Property(e => e.CodigoPlantaRandomValor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigoPlantaRandomValor");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.Diferencia).HasColumnName("diferencia");

                entity.Property(e => e.Dilucion).HasColumnName("dilucion");

                entity.Property(e => e.FechaRecepcion).HasColumnName("fechaRecepcion");

                entity.Property(e => e.LeyAuGt).HasColumnName("leyAuGt");

                entity.Property(e => e.LeyAuGt100).HasColumnName("leyAuGt100");

                entity.Property(e => e.LeyAuGt100Reportado).HasColumnName("leyAuGt100Reportado");

                entity.Property(e => e.LeyAuGtReportado).HasColumnName("leyAuGtReportado");

                entity.Property(e => e.LeyAuOzTc).HasColumnName("leyAuOzTc");

                entity.Property(e => e.LeyAuOzTc100).HasColumnName("leyAuOzTc100");

                entity.Property(e => e.LeyAuOzTc100Reportado).HasColumnName("leyAuOzTc100Reportado");

                entity.Property(e => e.LeyAuOzTcReportado).HasColumnName("leyAuOzTcReportado");

                entity.Property(e => e.Tms).HasColumnName("tms");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");

                entity.Property(e => e.UserNameCreate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameCreate");

                entity.Property(e => e.UserNameUpdate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameUpdate");
            });

            modelBuilder.Entity<LoteCodigoEnsayoDetalle>(entity =>
            {
                entity.HasKey(e => e.IdLoteCodigoEnsayoDetalle)
                    .HasName("PK_laboratorio_LoteCodigoEnsayoDetalle_idLoteCodigoEnsayoDetalle");

                entity.ToTable("LoteCodigoEnsayoDetalle", "laboratorio");

                entity.Property(e => e.IdLoteCodigoEnsayoDetalle).HasColumnName("idLoteCodigoEnsayoDetalle");

                entity.Property(e => e.AuFinoEnsayo).HasColumnName("auFinoEnsayo");

                entity.Property(e => e.AuGruesoEnsayo).HasColumnName("auGruesoEnsayo");

                entity.Property(e => e.IdLoteCodigoEnsayo).HasColumnName("idLoteCodigoEnsayo");

                entity.Property(e => e.IdLoteCodigoEnsayoOrigen)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteCodigoEnsayoOrigen")
                    .IsFixedLength();

                entity.Property(e => e.LeyAgGt).HasColumnName("leyAgGt");

                entity.Property(e => e.LeyAgOzTc).HasColumnName("leyAgOzTc");

                entity.Property(e => e.LeyAuGt).HasColumnName("leyAuGt");

                entity.Property(e => e.LeyAuOzTc).HasColumnName("leyAuOzTc");

                entity.Property(e => e.LeyGt).HasColumnName("leyGt");

                entity.Property(e => e.LeyOzTc).HasColumnName("leyOzTc");

                entity.Property(e => e.PesoFino).HasColumnName("pesoFino");

                entity.Property(e => e.PesoFinoEnsayo).HasColumnName("pesoFinoEnsayo");

                entity.Property(e => e.PesoGrueso).HasColumnName("pesoGrueso");

                entity.Property(e => e.PesoTotal).HasColumnName("pesoTotal");

                entity.Property(e => e.PorcentajeFino).HasColumnName("porcentajeFino");

                entity.Property(e => e.PorcentajeGrueso).HasColumnName("porcentajeGrueso");

                entity.Property(e => e.WAg).HasColumnName("wAg");

                entity.Property(e => e.WAu).HasColumnName("wAu");

                entity.Property(e => e.WDore).HasColumnName("wDore");

                entity.Property(e => e.WMuestra).HasColumnName("wMuestra");

                entity.HasOne(d => d.IdLoteCodigoEnsayoOrigenNavigation)
                    .WithMany(p => p.LoteCodigoEnsayoDetalles)
                    .HasForeignKey(d => d.IdLoteCodigoEnsayoOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_laboratorio_LoteCodigoEnsayoDetalle_idLoteCodigoEnsayoOrigen");
            });

            modelBuilder.Entity<LoteCodigoEnsayoOrigen>(entity =>
            {
                entity.HasKey(e => e.IdLoteCodigoEnsayoOrigen)
                    .HasName("PK_laboratorio_LoteCodigoEnsayoOrigen_idLoteCodigoEnsayoOrigen");

                entity.ToTable("LoteCodigoEnsayoOrigen", "laboratorio");

                entity.Property(e => e.IdLoteCodigoEnsayoOrigen)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteCodigoEnsayoOrigen")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<LoteCodigoEstado>(entity =>
            {
                entity.HasKey(e => e.IdLoteCodigoEstado)
                    .HasName("PK_acopio_LoteCodigoEstado_idLoteCodigoEstado");

                entity.ToTable("LoteCodigoEstado", "acopio");

                entity.Property(e => e.IdLoteCodigoEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteCodigoEstado")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<LoteCodigoLiquidacion>(entity =>
            {
                entity.HasKey(e => e.IdLoteCodigoLiquidacion)
                    .HasName("PK_liquidaciones_LoteCodigoLiquidacion_idLoteCodigoLiquidacion");

                entity.ToTable("LoteCodigoLiquidacion", "liquidaciones");

                entity.Property(e => e.IdLoteCodigoLiquidacion).HasColumnName("idLoteCodigoLiquidacion");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Adjunto)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("adjunto");

                entity.Property(e => e.CodigoMuestraProveedor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigoMuestraProveedor");

                entity.Property(e => e.CodigoPlanta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigoPlanta");

                entity.Property(e => e.FechaRecepcion).HasColumnName("fechaRecepcion");

                entity.Property(e => e.IdLoteCodigoTipo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteCodigoTipo")
                    .IsFixedLength();

                entity.Property(e => e.IdLoteLiquidacion).HasColumnName("idLoteLiquidacion");

                entity.Property(e => e.IdTipoMetal)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoMetal")
                    .IsFixedLength();

                entity.Property(e => e.IdTipoProporcion)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoProporcion")
                    .IsFixedLength();

                entity.Property(e => e.LeyAuOzTcFinoNewmont).HasColumnName("leyAuOzTcFinoNewmont");

                entity.Property(e => e.LeyAuOzTcGruesoNewmont).HasColumnName("leyAuOzTcGruesoNewmont");

                entity.Property(e => e.LeyOzTc100Newmont)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("leyOzTc100Newmont");

                entity.Property(e => e.LeyOzTcBaseNewmont)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("leyOzTcBaseNewmont");

                entity.Property(e => e.LeyOzTcNewmont)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("leyOzTcNewmont");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.Property(e => e.PorcentajeDilucion)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("porcentajeDilucion");

                entity.HasOne(d => d.IdLoteCodigoTipoNavigation)
                    .WithMany(p => p.LoteCodigoLiquidacions)
                    .HasForeignKey(d => d.IdLoteCodigoTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_liquidaciones_LoteCodigoLiquidacion_idLoteCodigoTipo");

                entity.HasOne(d => d.IdLoteLiquidacionNavigation)
                    .WithMany(p => p.LoteCodigoLiquidacions)
                    .HasForeignKey(d => d.IdLoteLiquidacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_liquidaciones_LoteCodigoLiquidacion_idLoteLiquidacion");

                entity.HasOne(d => d.IdTipoMetalNavigation)
                    .WithMany(p => p.LoteCodigoLiquidacions)
                    .HasForeignKey(d => d.IdTipoMetal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_liquidaciones_LoteCodigoLiquidacion_idTipoMetal");

                entity.HasOne(d => d.IdTipoProporcionNavigation)
                    .WithMany(p => p.LoteCodigoLiquidacions)
                    .HasForeignKey(d => d.IdTipoProporcion)
                    .HasConstraintName("fk_liquidaciones_LoteCodigoLiquidacion_idTipoProporcion");
            });

            modelBuilder.Entity<LoteCodigoMuestreo>(entity =>
            {
                entity.HasKey(e => e.IdLoteCodigoMuestreo)
                    .HasName("PK_muestreo_LoteCodigoMuestreo_idLoteCodigoMuestreo");

                entity.ToTable("LoteCodigoMuestreo", "muestreo");

                entity.Property(e => e.IdLoteCodigoMuestreo).HasColumnName("idLoteCodigoMuestreo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoPlanta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigoPlanta");

                entity.Property(e => e.CodigoPlantaRandom)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("codigoPlantaRandom");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.FechaMuestreo).HasColumnName("fechaMuestreo");

                entity.Property(e => e.IdDuenoMuestra).HasColumnName("idDuenoMuestra");

                entity.Property(e => e.IdLoteMuestreo).HasColumnName("idLoteMuestreo");

                entity.Property(e => e.IdMuestraCondicion)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idMuestraCondicion")
                    .IsFixedLength();

                entity.Property(e => e.IdTurno).HasColumnName("idTurno");

                entity.Property(e => e.LlevaGrueso).HasColumnName("llevaGrueso");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");

                entity.Property(e => e.UserNameCreate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameCreate");

                entity.Property(e => e.UserNameUpdate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameUpdate");

                entity.HasOne(d => d.IdDuenoMuestraNavigation)
                    .WithMany(p => p.LoteCodigoMuestreos)
                    .HasForeignKey(d => d.IdDuenoMuestra)
                    .HasConstraintName("fk_muestreo_LoteCodigoMuestreo_idDuenoMuestra");

                entity.HasOne(d => d.IdLoteMuestreoNavigation)
                    .WithMany(p => p.LoteCodigoMuestreos)
                    .HasForeignKey(d => d.IdLoteMuestreo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_muestreo_LoteCodigoMuestreo_idLoteMuestreo");

                entity.HasOne(d => d.IdMuestraCondicionNavigation)
                    .WithMany(p => p.LoteCodigoMuestreos)
                    .HasForeignKey(d => d.IdMuestraCondicion)
                    .HasConstraintName("fk_muestreo_LoteCodigoMuestreo_idMuestraCondicion");

                entity.HasOne(d => d.IdTurnoNavigation)
                    .WithMany(p => p.LoteCodigoMuestreos)
                    .HasForeignKey(d => d.IdTurno)
                    .HasConstraintName("fk_muestreo_LoteCodigoMuestreo_idTurno");
            });

            modelBuilder.Entity<LoteCodigoNomenclatura>(entity =>
            {
                entity.HasKey(e => e.IdLoteCodigoNomenclatura)
                    .HasName("PK_acopio_Nomenclatura_idLoteCodigoNomenclatura");

                entity.ToTable("LoteCodigoNomenclatura", "acopio");

                entity.Property(e => e.IdLoteCodigoNomenclatura).HasColumnName("idLoteCodigoNomenclatura");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.EmpresaNomenclatura)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("empresaNomenclatura");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdLoteCodigoTipo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteCodigoTipo")
                    .IsFixedLength();

                entity.Property(e => e.TipoLoteCodigoNomenclatura)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("tipoLoteCodigoNomenclatura");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.LoteCodigoNomenclaturas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("fk_acopio_LoteCodigoNomenclatura_idEmpresa");

                entity.HasOne(d => d.IdLoteCodigoTipoNavigation)
                    .WithMany(p => p.LoteCodigoNomenclaturas)
                    .HasForeignKey(d => d.IdLoteCodigoTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_acopio_LoteCodigoNomenclatura_idLoteCodigoTipo");
            });

            modelBuilder.Entity<LoteCodigoPm>(entity =>
            {
                entity.HasKey(e => e.IdLoteCodigoPm)
                    .HasName("PK_laboratorio_LoteCodigoPm_idLoteCodigoPm");

                entity.ToTable("LoteCodigoPm", "laboratorio");

                entity.Property(e => e.IdLoteCodigoPm).HasColumnName("idLoteCodigoPm");

                entity.Property(e => e.AuFinoEnsayo).HasColumnName("auFinoEnsayo");

                entity.Property(e => e.AuGruesoEnsayo).HasColumnName("auGruesoEnsayo");

                entity.Property(e => e.CodigoPlantaRandom)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("codigoPlantaRandom");

                entity.Property(e => e.CodigoPlantaRandomValor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigoPlantaRandomValor");

                entity.Property(e => e.IdLoteCodigoEnsayo).HasColumnName("idLoteCodigoEnsayo");

                entity.Property(e => e.LeyAgGt).HasColumnName("leyAgGt");

                entity.Property(e => e.LeyAgOzTc).HasColumnName("leyAgOzTc");

                entity.Property(e => e.LeyAuGt).HasColumnName("leyAuGt");

                entity.Property(e => e.LeyAuOzTc).HasColumnName("leyAuOzTc");

                entity.Property(e => e.LeyGt).HasColumnName("leyGt");

                entity.Property(e => e.LeyOzTc).HasColumnName("leyOzTc");

                entity.Property(e => e.PesoFino).HasColumnName("pesoFino");

                entity.Property(e => e.PesoFinoEnsayo).HasColumnName("pesoFinoEnsayo");

                entity.Property(e => e.PesoGrueso).HasColumnName("pesoGrueso");

                entity.Property(e => e.PesoTotal).HasColumnName("pesoTotal");

                entity.Property(e => e.PorcentajeFino).HasColumnName("porcentajeFino");

                entity.Property(e => e.PorcentajeGrueso).HasColumnName("porcentajeGrueso");

                entity.Property(e => e.WAg).HasColumnName("wAg");

                entity.Property(e => e.WAu).HasColumnName("wAu");

                entity.Property(e => e.WDore).HasColumnName("wDore");

                entity.Property(e => e.WMuestra).HasColumnName("wMuestra");
            });

            modelBuilder.Entity<LoteCodigoTipo>(entity =>
            {
                entity.HasKey(e => e.IdLoteCodigoTipo)
                    .HasName("PK_acopio_LoteCodigoTipo_idLoteCodigoTipo");

                entity.ToTable("LoteCodigoTipo", "acopio");

                entity.Property(e => e.IdLoteCodigoTipo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteCodigoTipo")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<LoteEstado>(entity =>
            {
                entity.HasKey(e => e.IdLoteEstado)
                    .HasName("PK_acopio_LoteEstado_idLoteEstado");

                entity.ToTable("LoteEstado", "acopio");

                entity.Property(e => e.IdLoteEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteEstado")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<LoteLiquidacion>(entity =>
            {
                entity.HasKey(e => e.IdLoteLiquidacion)
                    .HasName("PK_liquidaciones_LoteLiquidacion_idLoteLiquidacion");

                entity.ToTable("LoteLiquidacion", "liquidaciones");

                entity.Property(e => e.IdLoteLiquidacion).HasColumnName("idLoteLiquidacion");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.AjusteOculto)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("ajusteOculto");

                entity.Property(e => e.CodigoLote)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigoLote");

                entity.Property(e => e.ConsumoCianuro)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("consumoCianuro");

                entity.Property(e => e.ConsumoCianuro100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("consumoCianuro100");

                entity.Property(e => e.ConsumoSoda)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("consumoSoda");

                entity.Property(e => e.ConsumoSoda100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("consumoSoda100");

                entity.Property(e => e.FactorConversion)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("factorConversion");

                entity.Property(e => e.FactorConversion100)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("factorConversion100");

                entity.Property(e => e.FechaIngreso).HasColumnName("fechaIngreso");

                entity.Property(e => e.FechaLiquidacion).HasColumnName("fechaLiquidacion");

                entity.Property(e => e.Humedad)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("humedad");

                entity.Property(e => e.Humedad100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("humedad100");

                entity.Property(e => e.HumedadMerma)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("humedadMerma");

                entity.Property(e => e.IdLoteLiquidacionEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteLiquidacionEstado")
                    .IsFixedLength();

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.IdTipoLiquidacion)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoLiquidacion")
                    .IsFixedLength();

                entity.Property(e => e.IdTipoMineral)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoMineral")
                    .IsFixedLength();

                entity.Property(e => e.InterDolarGr)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("interDolarGr");

                entity.Property(e => e.InterDolarOz)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("interDolarOz");

                entity.Property(e => e.Maquila)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("maquila");

                entity.Property(e => e.Maquila100)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("maquila100");

                entity.Property(e => e.PipDolarGr)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pipDolarGr");

                entity.Property(e => e.PipDolarOz)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pipDolarOz");

                entity.Property(e => e.PorcentajeUtilidad)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("porcentajeUtilidad");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("rowVersion");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("subTotal");

                entity.Property(e => e.SubTotalAdelantos)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("subTotalAdelantos");

                entity.Property(e => e.SubTotalConPenalidad)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("subTotalConPenalidad");

                entity.Property(e => e.SubTotalSinPenalidad)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("subTotalSinPenalidad");

                entity.Property(e => e.SubTotalUtilidad)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("subTotalUtilidad");

                entity.Property(e => e.Tmh)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tmh");

                entity.Property(e => e.Tmh100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tmh100");

                entity.Property(e => e.TmhMerma)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tmhMerma");

                entity.Property(e => e.Tms)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tms");

                entity.Property(e => e.Tms100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tms100");

                entity.Property(e => e.TmsMerma)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tmsMerma");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("total");

                entity.Property(e => e.ValorUnitarioConPenalidadTm)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("valorUnitarioConPenalidadTm");

                entity.Property(e => e.ValorUnitarioSinPenalidadTm)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("valorUnitarioSinPenalidadTm");

                entity.Property(e => e.ValorUnitarioTm)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("valorUnitarioTm");

                entity.Property(e => e.ValorUnitarioUtilidadTm)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("valorUnitarioUtilidadTm");

                entity.HasOne(d => d.IdLoteLiquidacionEstadoNavigation)
                    .WithMany(p => p.LoteLiquidacions)
                    .HasForeignKey(d => d.IdLoteLiquidacionEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_liquidaciones_LoteLiquidacion_idLoteLiquidacionEstado");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.LoteLiquidacions)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_liquidaciones_LoteLiquidacion_idProveedor");

                entity.HasOne(d => d.IdTipoLiquidacionNavigation)
                    .WithMany(p => p.LoteLiquidacions)
                    .HasForeignKey(d => d.IdTipoLiquidacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_liquidaciones_LoteLiquidacion_idTipoLiquidacion");

                entity.HasOne(d => d.IdTipoMineralNavigation)
                    .WithMany(p => p.LoteLiquidacions)
                    .HasForeignKey(d => d.IdTipoMineral)
                    .HasConstraintName("fk_liquidaciones_LoteLiquidacion_idTipoMineral");
            });

            modelBuilder.Entity<LoteLiquidacionAdelanto>(entity =>
            {
                entity.HasKey(e => e.IdLoteLiquidacionAdelanto)
                    .HasName("PK_liquidaciones_LoteLiquidacionAdelanto_idLoteLiquidacionAdelanto");

                entity.ToTable("LoteLiquidacionAdelanto", "liquidaciones");

                entity.Property(e => e.IdLoteLiquidacionAdelanto).HasColumnName("idLoteLiquidacionAdelanto");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.IdAdelanto).HasColumnName("idAdelanto");

                entity.Property(e => e.IdLoteLiquidacion).HasColumnName("idLoteLiquidacion");

                entity.Property(e => e.ValorAplicado)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorAplicado");
            });

            modelBuilder.Entity<LoteLiquidacionAsignacion>(entity =>
            {
                entity.HasKey(e => e.IdLoteLiquidacionAsignacion)
                    .HasName("PK_liquidaciones_LoteLiquidacionAsignacion_idLoteLiquidacionAsignacion");

                entity.ToTable("LoteLiquidacionAsignacion", "liquidaciones");

                entity.Property(e => e.IdLoteLiquidacionAsignacion).HasColumnName("idLoteLiquidacionAsignacion");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.IdAsignacion).HasColumnName("idAsignacion");

                entity.Property(e => e.IdComprobanteDetalle).HasColumnName("idComprobanteDetalle");

                entity.Property(e => e.IdLoteLiquidacion).HasColumnName("idLoteLiquidacion");

                entity.HasOne(d => d.IdAsignacionNavigation)
                    .WithMany(p => p.LoteLiquidacionAsignacions)
                    .HasForeignKey(d => d.IdAsignacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_liquidaciones_LoteLiquidacionAsignacion_Asignacion");

                entity.HasOne(d => d.IdComprobanteDetalleNavigation)
                    .WithMany(p => p.LoteLiquidacionAsignacions)
                    .HasForeignKey(d => d.IdComprobanteDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_liquidaciones_LoteLiquidacionAsignacion_idComprobanteDetalle");

                entity.HasOne(d => d.IdLoteLiquidacionNavigation)
                    .WithMany(p => p.LoteLiquidacionAsignacions)
                    .HasForeignKey(d => d.IdLoteLiquidacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_liquidaciones_LoteLiquidacionAsignacion_idLoteLiquidacion");
            });

            modelBuilder.Entity<LoteLiquidacionComision>(entity =>
            {
                entity.HasKey(e => e.IdLoteLiquidacionComision)
                    .HasName("PK_liquidaciones_LoteLiquidacionComision_idLoteLiquidacionComision");

                entity.ToTable("LoteLiquidacionComision", "liquidaciones");

                entity.Property(e => e.IdLoteLiquidacionComision).HasColumnName("idLoteLiquidacionComision");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.IdComisionEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idComisionEstado")
                    .IsFixedLength();

                entity.Property(e => e.IdComisionistum).HasColumnName("idComisionistum");

                entity.Property(e => e.IdDivisa)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("idDivisa")
                    .IsFixedLength();

                entity.Property(e => e.IdLoteLiquidacion).HasColumnName("idLoteLiquidacion");

                entity.Property(e => e.PorcentajeComision)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("porcentajeComision");

                entity.Property(e => e.ValorComision)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorComision");

                entity.Property(e => e.ValorComision100)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorComision100");

                entity.HasOne(d => d.IdComisionEstadoNavigation)
                    .WithMany(p => p.LoteLiquidacionComisions)
                    .HasForeignKey(d => d.IdComisionEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_liquidaciones_LoteLiquidacionComision_idComisionEstado");

                entity.HasOne(d => d.IdComisionistumNavigation)
                    .WithMany(p => p.LoteLiquidacionComisions)
                    .HasForeignKey(d => d.IdComisionistum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_liquidaciones_LoteLiquidacionComision_idComisionistum");

                entity.HasOne(d => d.IdDivisaNavigation)
                    .WithMany(p => p.LoteLiquidacionComisions)
                    .HasForeignKey(d => d.IdDivisa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_liquidaciones_LoteLiquidacionComision_idDivisa");

                entity.HasOne(d => d.IdLoteLiquidacionNavigation)
                    .WithMany(p => p.LoteLiquidacionComisions)
                    .HasForeignKey(d => d.IdLoteLiquidacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_liquidaciones_LoteLiquidacionComision_idLoteLiquidacion");
            });

            modelBuilder.Entity<LoteLiquidacionComisionAsignacion>(entity =>
            {
                entity.HasKey(e => e.IdLoteLiquidacionComisionAsignacion)
                    .HasName("PK_liquidaciones_LoteLiquidacionComisionAsignacion_idLoteLiquidacionComisionAsignacion");

                entity.ToTable("LoteLiquidacionComisionAsignacion", "liquidaciones");

                entity.Property(e => e.IdLoteLiquidacionComisionAsignacion).HasColumnName("idLoteLiquidacionComisionAsignacion");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.IdAsignacion).HasColumnName("idAsignacion");

                entity.Property(e => e.IdComprobanteDetalle).HasColumnName("idComprobanteDetalle");

                entity.Property(e => e.IdLoteLiquidacionComision).HasColumnName("idLoteLiquidacionComision");

                entity.HasOne(d => d.IdAsignacionNavigation)
                    .WithMany(p => p.LoteLiquidacionComisionAsignacions)
                    .HasForeignKey(d => d.IdAsignacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_liquidaciones_LoteLiquidacionComisionAsignacion_Asignacion");

                entity.HasOne(d => d.IdComprobanteDetalleNavigation)
                    .WithMany(p => p.LoteLiquidacionComisionAsignacions)
                    .HasForeignKey(d => d.IdComprobanteDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_liquidaciones_LoteLiquidacionComisionAsignacion_idComprobanteDetalle");

                entity.HasOne(d => d.IdLoteLiquidacionComisionNavigation)
                    .WithMany(p => p.LoteLiquidacionComisionAsignacions)
                    .HasForeignKey(d => d.IdLoteLiquidacionComision)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_liquidaciones_LoteLiquidacionComisionAsignacion_idLoteLiquidacionComision");
            });

            modelBuilder.Entity<LoteLiquidacionConsumo>(entity =>
            {
                entity.HasKey(e => e.IdLoteLiquidacionConsumo)
                    .HasName("PK_liquidaciones_LoteLiquidacionConsumo_idLoteLiquidacionConsumo");

                entity.ToTable("LoteLiquidacionConsumo", "liquidaciones");

                entity.Property(e => e.IdLoteLiquidacionConsumo).HasColumnName("idLoteLiquidacionConsumo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.ConsumoKgTm)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("consumoKgTm");

                entity.Property(e => e.ConsumoKgTm100)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("consumoKgTm100");

                entity.Property(e => e.IdInsumo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idInsumo")
                    .IsFixedLength();

                entity.Property(e => e.IdLoteLiquidacion).HasColumnName("idLoteLiquidacion");

                entity.Property(e => e.IdPropiedadCalculo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idPropiedadCalculo")
                    .IsFixedLength();

                entity.Property(e => e.SubTotalTm)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subTotalTm");

                entity.Property(e => e.SubTotalTm100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("subTotalTm100");

                entity.Property(e => e.ValorUnitarioKg)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorUnitarioKg");

                entity.Property(e => e.ValorUnitarioKg100)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valorUnitarioKg100");

                entity.HasOne(d => d.IdInsumoNavigation)
                    .WithMany(p => p.LoteLiquidacionConsumos)
                    .HasForeignKey(d => d.IdInsumo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_liquidaciones_LoteLiquidacionConsumo_idInsumo");

                entity.HasOne(d => d.IdLoteLiquidacionNavigation)
                    .WithMany(p => p.LoteLiquidacionConsumos)
                    .HasForeignKey(d => d.IdLoteLiquidacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_liquidaciones_LoteLiquidacionConsumo_idLoteLiquidacion");

                entity.HasOne(d => d.IdPropiedadCalculoNavigation)
                    .WithMany(p => p.LoteLiquidacionConsumos)
                    .HasForeignKey(d => d.IdPropiedadCalculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_liquidaciones_LoteLiquidacionConsumo_idPropiedadCalculo");
            });

            modelBuilder.Entity<LoteLiquidacionEstado>(entity =>
            {
                entity.HasKey(e => e.IdLoteLiquidacionEstado)
                    .HasName("PK_liquidaciones_LoteLiquidacionEstado_idLoteLiquidacionEstado");

                entity.ToTable("LoteLiquidacionEstado", "liquidaciones");

                entity.Property(e => e.IdLoteLiquidacionEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteLiquidacionEstado")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<LoteLiquidacionGasto>(entity =>
            {
                entity.HasKey(e => e.IdLoteLiquidacionGasto)
                    .HasName("PK_liquidaciones_LoteLiquidacionGasto_idLoteLiquidacionGasto");

                entity.ToTable("LoteLiquidacionGasto", "liquidaciones");

                entity.Property(e => e.IdLoteLiquidacionGasto).HasColumnName("idLoteLiquidacionGasto");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.IdComprobanteDetalle).HasColumnName("idComprobanteDetalle");

                entity.Property(e => e.SubTotalAsignado)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subTotalAsignado");

                entity.Property(e => e.ValorUnitarioTmh).HasColumnName("valorUnitarioTmh");

                entity.HasOne(d => d.IdComprobanteDetalleNavigation)
                    .WithMany(p => p.LoteLiquidacionGastos)
                    .HasForeignKey(d => d.IdComprobanteDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_liquidaciones_LoteLiquidacionGasto_idComprobanteDetalle");
            });

            modelBuilder.Entity<LoteLiquidacionTipoMetal>(entity =>
            {
                entity.HasKey(e => e.IdLoteLiquidacionTipoMetal)
                    .HasName("PK_liquidaciones_LoteLiquidacionTipoMetal_idLoteLiquidacionTipoMetal");

                entity.ToTable("LoteLiquidacionTipoMetal", "liquidaciones");

                entity.Property(e => e.IdLoteLiquidacionTipoMetal).HasColumnName("idLoteLiquidacionTipoMetal");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.DiferenciaTotalRecuperacionGr)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("diferenciaTotalRecuperacionGr");

                entity.Property(e => e.IdLoteLiquidacion).HasColumnName("idLoteLiquidacion");

                entity.Property(e => e.IdTipoMetal)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoMetal")
                    .IsFixedLength();

                entity.Property(e => e.LeyGt100Newmont)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("leyGt100Newmont");

                entity.Property(e => e.LeyGtNewmont)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("leyGtNewmont");

                entity.Property(e => e.LeyOzTc100Newmont)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("leyOzTc100Newmont");

                entity.Property(e => e.LeyOzTcNewmont)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("leyOzTcNewmont");

                entity.Property(e => e.PorcentajeRecuperacion)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("porcentajeRecuperacion");

                entity.Property(e => e.PorcentajeRecuperacion100)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("porcentajeRecuperacion100");

                entity.Property(e => e.Recuperacion100GrTm)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("recuperacion100GrTm");

                entity.Property(e => e.RecuperacionGrTm)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("recuperacionGrTm");

                entity.Property(e => e.RiesgoComercial)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("riesgoComercial");

                entity.Property(e => e.SubTotalSinPenalidad)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("subTotalSinPenalidad");

                entity.Property(e => e.TotalRecuperacion100Gr)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("totalRecuperacion100Gr");

                entity.Property(e => e.TotalRecuperacionGr)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("totalRecuperacionGr");

                entity.Property(e => e.ValorUnitarioSinPenalidadTm)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("valorUnitarioSinPenalidadTm");

                entity.HasOne(d => d.IdLoteLiquidacionNavigation)
                    .WithMany(p => p.LoteLiquidacionTipoMetals)
                    .HasForeignKey(d => d.IdLoteLiquidacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_liquidaciones_LoteLiquidacionTipoMetal_idLoteLiquidacion");

                entity.HasOne(d => d.IdTipoMetalNavigation)
                    .WithMany(p => p.LoteLiquidacionTipoMetals)
                    .HasForeignKey(d => d.IdTipoMetal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_liquidaciones_LoteLiquidacionTipoMetal_idTipoMetal");
            });

            modelBuilder.Entity<LoteMuestreo>(entity =>
            {
                entity.HasKey(e => e.IdLoteMuestreo)
                    .HasName("PK_LoteMuestreo_idLoteMuestreo");

                entity.ToTable("LoteMuestreo", "muestreo");

                entity.HasIndex(e => e.CodigoLote, "UC_muestreo_LoteMuestreo_codigoLote")
                    .IsUnique();

                entity.Property(e => e.IdLoteMuestreo).HasColumnName("idLoteMuestreo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoAum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigoAum");

                entity.Property(e => e.CodigoLote)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigoLote");

                entity.Property(e => e.CodigoTrujillo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigoTrujillo");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.FechaAcopio).HasColumnName("fechaAcopio");

                entity.Property(e => e.Firmado).HasColumnName("firmado");

                entity.Property(e => e.Humedad)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("humedad");

                entity.Property(e => e.Humedad100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("humedad100");

                entity.Property(e => e.HumedadBase)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("humedadBase");

                entity.Property(e => e.IdCancha)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idCancha")
                    .IsFixedLength();

                entity.Property(e => e.IdDuenoMuestra).HasColumnName("idDuenoMuestra");

                entity.Property(e => e.IdLoteEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteEstado")
                    .HasDefaultValueSql("('01')")
                    .IsFixedLength();

                entity.Property(e => e.IdMineralCondicion)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idMineralCondicion")
                    .IsFixedLength();

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.IdTipoMineral)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoMineral")
                    .IsFixedLength();

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.Property(e => e.ObservacionBalanza)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observacionBalanza")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PesoHumedo)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoHumedo");

                entity.Property(e => e.PesoSeco)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoSeco");

                entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");

                entity.Property(e => e.ReportadoProveedor).HasColumnName("reportadoProveedor");

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("rowVersion");

                entity.Property(e => e.Tmh)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tmh");

                entity.Property(e => e.Tms)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tms");

                entity.Property(e => e.Tms100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tms100");

                entity.Property(e => e.TmsBase)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tmsBase");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");

                entity.Property(e => e.UserNameCreate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameCreate");

                entity.Property(e => e.UserNameUpdate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameUpdate");

                entity.HasOne(d => d.IdCanchaNavigation)
                    .WithMany(p => p.LoteMuestreos)
                    .HasForeignKey(d => d.IdCancha)
                    .HasConstraintName("fk_muestreo_LoteMuestreo_idCancha");

                entity.HasOne(d => d.IdDuenoMuestraNavigation)
                    .WithMany(p => p.LoteMuestreos)
                    .HasForeignKey(d => d.IdDuenoMuestra)
                    .HasConstraintName("fk_muestreo_LoteMuestreo_idDuenoMuestra");

                entity.HasOne(d => d.IdLoteEstadoNavigation)
                    .WithMany(p => p.LoteMuestreos)
                    .HasForeignKey(d => d.IdLoteEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_muestreo_LoteMuestreo_idLoteEstado");

                entity.HasOne(d => d.IdMineralCondicionNavigation)
                    .WithMany(p => p.LoteMuestreos)
                    .HasForeignKey(d => d.IdMineralCondicion)
                    .HasConstraintName("fk_muestreo_LoteMuestreo_idMineralCondicion");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.LoteMuestreos)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_muestreo_LoteMuestreo_idProveedor");

                entity.HasOne(d => d.IdTipoMineralNavigation)
                    .WithMany(p => p.LoteMuestreos)
                    .HasForeignKey(d => d.IdTipoMineral)
                    .HasConstraintName("fk_muestreo_LoteMuestreo_idTipoMineral");
            });

            modelBuilder.Entity<LoteOperacion>(entity =>
            {
                entity.HasKey(e => e.IdLoteOperacion)
                    .HasName("PK_acopio_idLoteOperacion");

                entity.ToTable("LoteOperacion", "acopio");

                entity.Property(e => e.IdLoteOperacion).HasColumnName("idLoteOperacion");

                entity.Property(e => e.Attempts).HasColumnName("attempts");

                entity.Property(e => e.Body)
                    .HasColumnType("text")
                    .HasColumnName("body");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.IdLote).HasColumnName("idLote");

                entity.Property(e => e.IdOperacion).HasColumnName("idOperacion");

                entity.Property(e => e.Message)
                    .HasColumnType("text")
                    .HasColumnName("message");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength();

                entity.Property(e => e.UserNameCreate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameCreate");

                entity.HasOne(d => d.IdLoteNavigation)
                    .WithMany(p => p.LoteOperacions)
                    .HasForeignKey(d => d.IdLote)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_acopio_LoteOperacion_idLote");

                entity.HasOne(d => d.IdOperacionNavigation)
                    .WithMany(p => p.LoteOperacions)
                    .HasForeignKey(d => d.IdOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_acopio_LoteOperacion_idOperacion");
            });

            modelBuilder.Entity<Maestro>(entity =>
            {
                entity.HasKey(e => e.IdMaestro)
                    .HasName("PK_maestro_Maestro_idMaestro");

                entity.ToTable("Maestro", "maestro");

                entity.HasIndex(e => new { e.CodigoTabla, e.CodigoItem }, "UC_maestro_Maestro_codigo")
                    .IsUnique();

                entity.Property(e => e.IdMaestro).HasColumnName("idMaestro");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoItem)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("codigoItem")
                    .IsFixedLength();

                entity.Property(e => e.CodigoTabla)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("codigoTabla")
                    .IsFixedLength();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Mapa>(entity =>
            {
                entity.HasKey(e => e.IdMapa)
                    .HasName("PK_chancado_Mapa_idMapa");

                entity.ToTable("Mapa", "chancado");

                entity.Property(e => e.IdMapa).HasColumnName("idMapa");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CreateDate).HasColumnName("createDate");

                entity.Property(e => e.IdCancha)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idCancha")
                    .IsFixedLength();

                entity.Property(e => e.IdLoteChancado).HasColumnName("idLoteChancado");

                entity.Property(e => e.IdLoteChancadoGrupo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idLoteChancadoGrupo")
                    .HasDefaultValueSql("('01')")
                    .IsFixedLength();

                entity.Property(e => e.IdMapaPadre).HasColumnName("idMapaPadre");

                entity.Property(e => e.Numero)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.Tmh)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tmh");

                entity.Property(e => e.UbicacionX).HasColumnName("ubicacionX");

                entity.Property(e => e.UbicacionY).HasColumnName("ubicacionY");

                entity.Property(e => e.UpdateDate).HasColumnName("updateDate");

                entity.Property(e => e.UserNameCreate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameCreate");

                entity.Property(e => e.UserNameUpdate)
                    .HasMaxLength(256)
                    .HasColumnName("userNameUpdate");

                entity.HasOne(d => d.IdCanchaNavigation)
                    .WithMany(p => p.Mapas)
                    .HasForeignKey(d => d.IdCancha)
                    .HasConstraintName("fk_chancado_Mapa_idCancha");

                entity.HasOne(d => d.IdLoteChancadoNavigation)
                    .WithMany(p => p.Mapas)
                    .HasForeignKey(d => d.IdLoteChancado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_chancado_Mapa_idLoteChancado");

                entity.HasOne(d => d.IdLoteChancadoGrupoNavigation)
                    .WithMany(p => p.Mapas)
                    .HasForeignKey(d => d.IdLoteChancadoGrupo)
                    .HasConstraintName("fk_chancado_Mapa_idLoteChancadoGrupo");
            });

            modelBuilder.Entity<MineralCondicion>(entity =>
            {
                entity.HasKey(e => e.IdMineralCondicion)
                    .HasName("PK_chancado_MineralCondicion_idMineralCondicion");

                entity.ToTable("MineralCondicion", "chancado");

                entity.Property(e => e.IdMineralCondicion)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idMineralCondicion")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo)
                    .HasName("PK_maestro_Modulo_idModulo");

                entity.ToTable("Modulo", "acopio");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nivel).HasColumnName("nivel");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<MuestraCondicion>(entity =>
            {
                entity.HasKey(e => e.IdMuestraCondicion)
                    .HasName("PK_muestreo_MuestraCondicion_idMuestraCondicion");

                entity.ToTable("MuestraCondicion", "muestreo");

                entity.Property(e => e.IdMuestraCondicion)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idMuestraCondicion")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.HasKey(e => e.IdOperacion)
                    .HasName("PK_acopio_idOperacion");

                entity.ToTable("Operacion", "acopio");

                entity.Property(e => e.IdOperacion).HasColumnName("idOperacion");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.Property(e => e.NotificationEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("notificationEmail");

                entity.Property(e => e.PushUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pushUrl");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Operacions)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_acopio_Operacion_idModulo");
            });

            modelBuilder.Entity<PropiedadCalculo>(entity =>
            {
                entity.HasKey(e => e.IdPropiedadCalculo)
                    .HasName("PK_maestro_PropiedadCalculo_idPropiedadCalculo");

                entity.ToTable("PropiedadCalculo", "maestro");

                entity.Property(e => e.IdPropiedadCalculo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idPropiedadCalculo")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK_maestro_Proveedor_idProveedor");

                entity.ToTable("Proveedor", "maestro");

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoUbigeo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("codigoUbigeo")
                    .IsFixedLength();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("razonSocial");

                entity.Property(e => e.Ruc)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ruc");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.CodigoUbigeoNavigation)
                    .WithMany(p => p.Proveedors)
                    .HasForeignKey(d => d.CodigoUbigeo)
                    .HasConstraintName("fk_maestro_Proveedor_codigoUbigeo");
            });

            modelBuilder.Entity<ProveedorConcesion>(entity =>
            {
                entity.HasKey(e => e.IdProveedorConcesion)
                    .HasName("PK_maestro_ProveedorConcesion_idProveedorConcesion");

                entity.ToTable("ProveedorConcesion", "maestro");

                entity.HasIndex(e => new { e.IdProveedor, e.IdConcesion }, "UC_maestro_ProveedorConcesion_idProveedor_idConcesion")
                    .IsUnique();

                entity.Property(e => e.IdProveedorConcesion).HasColumnName("idProveedorConcesion");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.IdConcesion).HasColumnName("idConcesion");

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.HasOne(d => d.IdConcesionNavigation)
                    .WithMany(p => p.ProveedorConcesions)
                    .HasForeignKey(d => d.IdConcesion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestro_ProveedorConcesion_idConcesion");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.ProveedorConcesions)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestro_ProveedorConcesion_idProveedor");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.IdSucursal)
                    .HasName("PK_maestro_Sucursal");

                entity.ToTable("Sucursal", "maestro");

                entity.Property(e => e.IdSucursal)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idSucursal")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<SystemDataType>(entity =>
            {
                entity.ToTable("SystemDataType");

                entity.Property(e => e.SystemDataTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("systemDataTypeId");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.DataBaseEngineCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("dataBaseEngineCode")
                    .IsFixedLength();

                entity.Property(e => e.DataTypeCsharp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dataTypeCSharp");

                entity.Property(e => e.DataTypeJava)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dataTypeJava");

                entity.Property(e => e.DbTypeCsharp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("dbTypeCSharp");

                entity.Property(e => e.MySqlDbTypeCsharp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MySqlDbTypeCSharp");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.OriginalStorage).HasColumnName("originalStorage");

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.Ranking).HasColumnName("ranking");

                entity.Property(e => e.Scale).HasColumnName("scale");

                entity.Property(e => e.Storage).HasColumnName("storage");

                entity.Property(e => e.TypeValueCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("typeValueCode")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.IdTicket)
                    .HasName("PK_balanza_Ticket_idTicket");

                entity.ToTable("Ticket", "balanza");

                entity.Property(e => e.IdTicket).HasColumnName("idTicket");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CantidadUnidadMedida).HasColumnName("cantidadUnidadMedida");

                entity.Property(e => e.FechaIngreso).HasColumnName("fechaIngreso");

                entity.Property(e => e.FechaSalida).HasColumnName("fechaSalida");

                entity.Property(e => e.Grr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grr");

                entity.Property(e => e.Grt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grt");

                entity.Property(e => e.IdConductor).HasColumnName("idConductor");

                entity.Property(e => e.IdEstadoTmh).HasColumnName("idEstadoTmh");

                entity.Property(e => e.IdEstadoTmhCarreta).HasColumnName("idEstadoTmhCarreta");

                entity.Property(e => e.IdLoteBalanza).HasColumnName("idLoteBalanza");

                entity.Property(e => e.IdTransporte).HasColumnName("idTransporte");

                entity.Property(e => e.IdUnidadMedida).HasColumnName("idUnidadMedida");

                entity.Property(e => e.IdUsuarioAprobadorPesoBruto).HasColumnName("idUsuarioAprobadorPesoBruto");

                entity.Property(e => e.IdUsuarioAprobadorPesoBrutoCarreta).HasColumnName("idUsuarioAprobadorPesoBrutoCarreta");

                entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.Property(e => e.PesoBruto)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoBruto");

                entity.Property(e => e.PesoBruto100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoBruto100");

                entity.Property(e => e.PesoBrutoBase)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoBrutoBase");

                entity.Property(e => e.PesoBrutoCarreta)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoBrutoCarreta");

                entity.Property(e => e.PesoBrutoCarreta100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoBrutoCarreta100");

                entity.Property(e => e.PesoBrutoCarretaBase)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoBrutoCarretaBase");

                entity.Property(e => e.PesoBrutoCarretaEdit).HasColumnName("pesoBrutoCarretaEdit");

                entity.Property(e => e.PesoBrutoEdit).HasColumnName("pesoBrutoEdit");

                entity.Property(e => e.PesoNeto)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNeto");

                entity.Property(e => e.PesoNeto100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNeto100");

                entity.Property(e => e.PesoNetoBase)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNetoBase");

                entity.Property(e => e.PesoNetoCarreta)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNetoCarreta");

                entity.Property(e => e.PesoNetoCarreta100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNetoCarreta100");

                entity.Property(e => e.PesoNetoCarretaBase)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNetoCarretaBase");

                entity.Property(e => e.PesoNetoTotal)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNetoTotal");

                entity.Property(e => e.Tara)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tara");

                entity.Property(e => e.TaraCarreta)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("taraCarreta");

                entity.HasOne(d => d.IdConductorNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdConductor)
                    .HasConstraintName("fk_balanza_Ticket_idConductor");

                entity.HasOne(d => d.IdEstadoTmhNavigation)
                    .WithMany(p => p.TicketIdEstadoTmhNavigations)
                    .HasForeignKey(d => d.IdEstadoTmh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_Ticket_idEstadoTmh");

                entity.HasOne(d => d.IdEstadoTmhCarretaNavigation)
                    .WithMany(p => p.TicketIdEstadoTmhCarretaNavigations)
                    .HasForeignKey(d => d.IdEstadoTmhCarreta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_Ticket_idEstadoTmhCarreta");

                entity.HasOne(d => d.IdLoteBalanzaNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdLoteBalanza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_Ticket_idLoteBalanza");

                entity.HasOne(d => d.IdTransporteNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdTransporte)
                    .HasConstraintName("fk_balanza_Ticket_idTransporte");

                entity.HasOne(d => d.IdUnidadMedidaNavigation)
                    .WithMany(p => p.TicketIdUnidadMedidaNavigations)
                    .HasForeignKey(d => d.IdUnidadMedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_Ticket_idUnidadMedida");

                entity.HasOne(d => d.IdUsuarioAprobadorPesoBrutoNavigation)
                    .WithMany(p => p.TicketIdUsuarioAprobadorPesoBrutoNavigations)
                    .HasForeignKey(d => d.IdUsuarioAprobadorPesoBruto)
                    .HasConstraintName("fk_balanza_Ticket_idUsuarioAprobadorPesoBruto");

                entity.HasOne(d => d.IdUsuarioAprobadorPesoBrutoCarretaNavigation)
                    .WithMany(p => p.TicketIdUsuarioAprobadorPesoBrutoCarretaNavigations)
                    .HasForeignKey(d => d.IdUsuarioAprobadorPesoBrutoCarreta)
                    .HasConstraintName("fk_balanza_Ticket_idUsuarioAprobadorPesoBrutoCarreta");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_Ticket_idVehiculo");
            });

            modelBuilder.Entity<TicketBackup>(entity =>
            {
                entity.HasKey(e => e.IdTicket)
                    .HasName("PK_balanza_TicketBackup_idTicket");

                entity.ToTable("TicketBackup", "balanza");

                entity.Property(e => e.IdTicket)
                    .ValueGeneratedNever()
                    .HasColumnName("idTicket");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CantidadUnidadMedida).HasColumnName("cantidadUnidadMedida");

                entity.Property(e => e.FechaIngreso).HasColumnName("fechaIngreso");

                entity.Property(e => e.FechaSalida).HasColumnName("fechaSalida");

                entity.Property(e => e.Grr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grr");

                entity.Property(e => e.Grt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grt");

                entity.Property(e => e.IdConductor).HasColumnName("idConductor");

                entity.Property(e => e.IdEstadoTmh).HasColumnName("idEstadoTmh");

                entity.Property(e => e.IdEstadoTmhCarreta).HasColumnName("idEstadoTmhCarreta");

                entity.Property(e => e.IdLoteBalanza).HasColumnName("idLoteBalanza");

                entity.Property(e => e.IdTransporte).HasColumnName("idTransporte");

                entity.Property(e => e.IdUnidadMedida).HasColumnName("idUnidadMedida");

                entity.Property(e => e.IdUsuarioAprobadorPesoBruto).HasColumnName("idUsuarioAprobadorPesoBruto");

                entity.Property(e => e.IdUsuarioAprobadorPesoBrutoCarreta).HasColumnName("idUsuarioAprobadorPesoBrutoCarreta");

                entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.Property(e => e.PesoBruto)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoBruto");

                entity.Property(e => e.PesoBruto100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoBruto100");

                entity.Property(e => e.PesoBrutoBase)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoBrutoBase");

                entity.Property(e => e.PesoBrutoCarreta)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoBrutoCarreta");

                entity.Property(e => e.PesoBrutoCarreta100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoBrutoCarreta100");

                entity.Property(e => e.PesoBrutoCarretaBase)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoBrutoCarretaBase");

                entity.Property(e => e.PesoBrutoCarretaEdit).HasColumnName("pesoBrutoCarretaEdit");

                entity.Property(e => e.PesoBrutoEdit).HasColumnName("pesoBrutoEdit");

                entity.Property(e => e.PesoNeto)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNeto");

                entity.Property(e => e.PesoNeto100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNeto100");

                entity.Property(e => e.PesoNetoBase)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNetoBase");

                entity.Property(e => e.PesoNetoCarreta)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNetoCarreta");

                entity.Property(e => e.PesoNetoCarreta100)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNetoCarreta100");

                entity.Property(e => e.PesoNetoCarretaBase)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNetoCarretaBase");

                entity.Property(e => e.PesoNetoTotal)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("pesoNetoTotal");

                entity.Property(e => e.Tara)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("tara");

                entity.Property(e => e.TaraCarreta)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("taraCarreta");
            });

            modelBuilder.Entity<TipoComprobante>(entity =>
            {
                entity.HasKey(e => e.IdTipoComprobante)
                    .HasName("PK_maestro_TipoComprobante_idTipoComprobante");

                entity.ToTable("TipoComprobante", "maestro");

                entity.Property(e => e.IdTipoComprobante)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoComprobante")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NombreCorto)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("nombreCorto");
            });

            modelBuilder.Entity<TipoCosto>(entity =>
            {
                entity.HasKey(e => e.IdTipoCosto)
                    .HasName("PK_maestro_TipoCosto_idTipoCosto");

                entity.ToTable("TipoCosto", "maestro");

                entity.Property(e => e.IdTipoCosto)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoCosto")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("concepto");

                entity.Property(e => e.Costo)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("costo");

                entity.Property(e => e.IdDivisa)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("idDivisa")
                    .IsFixedLength();

                entity.HasOne(d => d.IdDivisaNavigation)
                    .WithMany(p => p.TipoCostos)
                    .HasForeignKey(d => d.IdDivisa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestro_TipoCosto_idDivisa");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.CodigoTipoDocumento)
                    .HasName("PK_maestro_TipoDocumento");

                entity.ToTable("TipoDocumento", "maestro");

                entity.Property(e => e.CodigoTipoDocumento)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("codigoTipoDocumento")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NombreCorto)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("nombreCorto");
            });

            modelBuilder.Entity<TipoLiquidacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoLiquidacion)
                    .HasName("PK_liquidaciones_TipoLiquidacion_idTipoLiquidacion");

                entity.ToTable("TipoLiquidacion", "liquidaciones");

                entity.Property(e => e.IdTipoLiquidacion)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoLiquidacion")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<TipoMedioPago>(entity =>
            {
                entity.HasKey(e => e.IdTipoMedioPago)
                    .HasName("PK_maestro_TipoMedioPago_idTipoMedioPago");

                entity.ToTable("TipoMedioPago", "maestro");

                entity.Property(e => e.IdTipoMedioPago)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("idTipoMedioPago")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoMetal>(entity =>
            {
                entity.HasKey(e => e.IdTipoMetal)
                    .HasName("PK_maestro_TipoMetal_idTipoMetal");

                entity.ToTable("TipoMetal", "maestro");

                entity.Property(e => e.IdTipoMetal)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoMetal")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");

                entity.Property(e => e.Simbolo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("simbolo");
            });

            modelBuilder.Entity<TipoMineral>(entity =>
            {
                entity.HasKey(e => e.IdTipoMineral)
                    .HasName("PK_maestro_TipoMineral_idTipoMineral");

                entity.ToTable("TipoMineral", "maestro");

                entity.Property(e => e.IdTipoMineral)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoMineral")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<TipoProporcion>(entity =>
            {
                entity.HasKey(e => e.IdTipoProporcion)
                    .HasName("PK_maestro_TipoProporcion_idTipoProporcion");

                entity.ToTable("TipoProporcion", "maestro");

                entity.Property(e => e.IdTipoProporcion)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("idTipoProporcion")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Proporcion1).HasColumnName("proporcion1");

                entity.Property(e => e.Proporcion2).HasColumnName("proporcion2");
            });

            modelBuilder.Entity<Transporte>(entity =>
            {
                entity.HasKey(e => e.IdTransporte)
                    .HasName("PK_maestro_Transporte_idTransporte");

                entity.ToTable("Transporte", "maestro");

                entity.Property(e => e.IdTransporte).HasColumnName("idTransporte");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoUbigeo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("codigoUbigeo")
                    .IsFixedLength();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("razonSocial");

                entity.Property(e => e.Ruc)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ruc");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.CodigoUbigeoNavigation)
                    .WithMany(p => p.Transportes)
                    .HasForeignKey(d => d.CodigoUbigeo)
                    .HasConstraintName("fk_maestro_Transporte_codigoUbigeo");
            });

            modelBuilder.Entity<TransporteVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdTransporteVehiculo)
                    .HasName("PK_maestro_TransporteVehiculo_idTransporteVehiculo");

                entity.ToTable("TransporteVehiculo", "maestro");

                entity.Property(e => e.IdTransporteVehiculo).HasColumnName("idTransporteVehiculo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.IdTransporte).HasColumnName("idTransporte");

                entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");

                entity.HasOne(d => d.IdTransporteNavigation)
                    .WithMany(p => p.TransporteVehiculos)
                    .HasForeignKey(d => d.IdTransporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestro_TransporteVehiculo_idTransporte");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.TransporteVehiculos)
                    .HasForeignKey(d => d.IdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestro_TransporteVehiculo_idVehiculo");
            });

            modelBuilder.Entity<Ubigeo>(entity =>
            {
                entity.HasKey(e => e.CodigoUbigeo)
                    .HasName("PK_maestro_Ubigeo_codigoUbigeo");

                entity.ToTable("Ubigeo", "maestro");

                entity.Property(e => e.CodigoUbigeo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("codigoUbigeo")
                    .IsFixedLength();

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("departamento");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("distrito");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("provincia");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PK_maestro_Vehiculo_idVehiculo");

                entity.ToTable("Vehiculo", "maestro");

                entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CargaUtil)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cargaUtil");

                entity.Property(e => e.IdTipoVehiculo).HasColumnName("idTipoVehiculo");

                entity.Property(e => e.IdVehiculoMarca).HasColumnName("idVehiculoMarca");

                entity.Property(e => e.Placa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("placa");

                entity.Property(e => e.PlacaCarreta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("placaCarreta");

                entity.Property(e => e.Tara)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tara");

                entity.HasOne(d => d.IdTipoVehiculoNavigation)
                    .WithMany(p => p.VehiculoIdTipoVehiculoNavigations)
                    .HasForeignKey(d => d.IdTipoVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestro_Vehiculo_idTipoVehiculo");

                entity.HasOne(d => d.IdVehiculoMarcaNavigation)
                    .WithMany(p => p.VehiculoIdVehiculoMarcaNavigations)
                    .HasForeignKey(d => d.IdVehiculoMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_maestro_Vehiculo_idVehiculoMarca");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
