using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Repository.Data
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

        public virtual DbSet<CheckList> CheckLists { get; set; } = null!;
        public virtual DbSet<Concesion> Concesions { get; set; } = null!;
        public virtual DbSet<Conductor> Conductors { get; set; } = null!;
        public virtual DbSet<Correlativo> Correlativos { get; set; } = null!;
        public virtual DbSet<CorrelativoTipo> CorrelativoTipos { get; set; } = null!;
        public virtual DbSet<DuenoMuestra> DuenoMuestras { get; set; } = null!;
        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Humedad> Humedads { get; set; } = null!;
        public virtual DbSet<ItemCheck> ItemChecks { get; set; } = null!;
        public virtual DbSet<JapBlackList> JapBlackLists { get; set; } = null!;
        public virtual DbSet<LeyReferencial> LeyReferencials { get; set; } = null!;
        public virtual DbSet<LoteBalanza> LoteBalanzas { get; set; } = null!;
        public virtual DbSet<LoteCodigo> LoteCodigos { get; set; } = null!;
        public virtual DbSet<Maestro> Maestros { get; set; } = null!;
        public virtual DbSet<Modulo> Modulos { get; set; } = null!;
        public virtual DbSet<ModuloUsuario> ModuloUsuarios { get; set; } = null!;
        public virtual DbSet<Muestreo> Muestreos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<ProveedorConcesion> ProveedorConcesions { get; set; } = null!;
        public virtual DbSet<SystemDataType> SystemDataTypes { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; } = null!;
        public virtual DbSet<Transporte> Transportes { get; set; } = null!;
        public virtual DbSet<Ubigeo> Ubigeos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");

            modelBuilder.Entity<CheckList>(entity =>
            {
                entity.HasKey(e => e.IdCheckList)
                    .HasName("PK_maestro_CheckList_idCheckList");

                entity.ToTable("CheckList", "maestro");

                entity.Property(e => e.IdCheckList).HasColumnName("idCheckList");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Adjunto)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("adjunto");

                entity.Property(e => e.HabilitadoBalanza).HasColumnName("habilitadoBalanza");

                entity.Property(e => e.HabilitadoComercial).HasColumnName("habilitadoComercial");

                entity.Property(e => e.IdCheckListEstadoBalanza).HasColumnName("idCheckListEstadoBalanza");

                entity.Property(e => e.IdCheckListEstadoComercial).HasColumnName("idCheckListEstadoComercial");

                entity.Property(e => e.IdItemCheck).HasColumnName("idItemCheck");

                entity.Property(e => e.IdLoteBalanza).HasColumnName("idLoteBalanza");

                entity.Property(e => e.ObservacionBalanza)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("observacionBalanza");

                entity.Property(e => e.ObservacionComercial)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("observacionComercial");

                entity.HasOne(d => d.IdCheckListEstadoBalanzaNavigation)
                    .WithMany(p => p.CheckListIdCheckListEstadoBalanzaNavigations)
                    .HasForeignKey(d => d.IdCheckListEstadoBalanza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_maestro_CheckList_idCheckListEstadoBalanza");

                entity.HasOne(d => d.IdCheckListEstadoComercialNavigation)
                    .WithMany(p => p.CheckListIdCheckListEstadoComercialNavigations)
                    .HasForeignKey(d => d.IdCheckListEstadoComercial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_maestro_CheckList_idCheckListEstadoComercial");

                entity.HasOne(d => d.IdItemCheckNavigation)
                    .WithMany(p => p.CheckLists)
                    .HasForeignKey(d => d.IdItemCheck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_maestro_CheckList_idItemCheck");

                entity.HasOne(d => d.IdLoteBalanzaNavigation)
                    .WithMany(p => p.CheckLists)
                    .HasForeignKey(d => d.IdLoteBalanza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_maestro_CheckList_idLote");
            });

            modelBuilder.Entity<Concesion>(entity =>
            {
                entity.HasKey(e => e.IdConcesion)
                    .HasName("PK_maestro_Concesion_idConcesion");

                entity.ToTable("Concesion", "maestro");

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
            });

            modelBuilder.Entity<Correlativo>(entity =>
            {
                entity.HasKey(e => e.IdCorrelativo)
                    .HasName("PK_config_Correlativo_idCorrelativo");

                entity.ToTable("Correlativo", "config");

                entity.HasIndex(e => new { e.CodigoCorrelativoTipo, e.Serie }, "UC_config_Correlativo")
                    .IsUnique();

                entity.Property(e => e.IdCorrelativo).HasColumnName("idCorrelativo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoCorrelativoTipo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("codigoCorrelativoTipo")
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
                    .HasConstraintName("fk_config_Correlativo_codigoCorrelativoTipo");
            });

            modelBuilder.Entity<CorrelativoTipo>(entity =>
            {
                entity.HasKey(e => e.CodigoCorrelativoTipo)
                    .HasName("PK_config_CorrelativoTipo_codigoCorrelativoTipo");

                entity.ToTable("CorrelativoTipo", "config");

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

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

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

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.DuenoMuestras)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_maestro_DuenoMuestra_idProveedor");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK_config_Empresa_idEmpresa");

                entity.ToTable("Empresa", "config");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoTipoDocumento)
                    .HasMaxLength(2)
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
            });

            modelBuilder.Entity<Humedad>(entity =>
            {
                entity.HasKey(e => e.IdHumedad)
                    .HasName("PK_muestreo_idHumedad");

                entity.ToTable("Humedad", "muestreo");

                entity.Property(e => e.IdHumedad).HasColumnName("idHumedad");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoMuestreoTipoMineral).HasColumnName("codigoMuestreoTipoMineral");

                entity.Property(e => e.CodigoSupervisor).HasColumnName("codigoSupervisor");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Firmado).HasColumnName("firmado");

                entity.Property(e => e.Humedad1).HasColumnName("humedad");

                entity.Property(e => e.Humedad100).HasColumnName("humedad100");

                entity.Property(e => e.IdLote).HasColumnName("idLote");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.Property(e => e.ReportadoProveedor).HasColumnName("reportadoProveedor");

                entity.Property(e => e.Tmh).HasColumnName("tmh");

                entity.Property(e => e.Tms).HasColumnName("tms");
            });

            modelBuilder.Entity<ItemCheck>(entity =>
            {
                entity.HasKey(e => e.IdItemCheck)
                    .HasName("PK_maestro_ItemCheck_idItemCheck");

                entity.ToTable("ItemCheck", "maestro");

                entity.Property(e => e.IdItemCheck).HasColumnName("idItemCheck");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("concepto");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.Property(e => e.Mandatorio).HasColumnName("mandatorio");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.ItemChecks)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_maestro_ItemCheck_idModulo");
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

            modelBuilder.Entity<LeyReferencial>(entity =>
            {
                entity.HasKey(e => e.IdLeyReferencial)
                    .HasName("PK_balanza_LeyReferencial_idLeyReferencial");

                entity.ToTable("LeyReferencial", "balanza");

                entity.Property(e => e.IdLeyReferencial).HasColumnName("idLeyReferencial");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoHash).HasColumnName("codigoHash");

                entity.Property(e => e.CodigoMuestraProveedor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("codigoMuestraProveedor");

                entity.Property(e => e.CodigoPlanta)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigoPlanta");

                entity.Property(e => e.EnsayoConsumo).HasColumnName("ensayoConsumo");

                entity.Property(e => e.EnsayoLeyAg).HasColumnName("ensayoLeyAg");

                entity.Property(e => e.EnsayoLeyAu).HasColumnName("ensayoLeyAu");

                entity.Property(e => e.EnsayoPorcentajeRecuperacion).HasColumnName("ensayoPorcentajeRecuperacion");

                entity.Property(e => e.FechaRecepcion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRecepcion");

                entity.Property(e => e.IdDuenoMuestra).HasColumnName("idDuenoMuestra");

                entity.Property(e => e.IdTipoMineral).HasColumnName("idTipoMineral");

                entity.HasOne(d => d.IdDuenoMuestraNavigation)
                    .WithMany(p => p.LeyReferencials)
                    .HasForeignKey(d => d.IdDuenoMuestra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_balanza_LeyReferencial_idDuenoMuestra");

                entity.HasOne(d => d.IdTipoMineralNavigation)
                    .WithMany(p => p.LeyReferencials)
                    .HasForeignKey(d => d.IdTipoMineral)
                    .HasConstraintName("FK_balanza_LeyReferencial_idTipoMineral");
            });

            modelBuilder.Entity<LoteBalanza>(entity =>
            {
                entity.HasKey(e => e.IdLoteBalanza)
                    .HasName("PK_balanza_LoteBalanza_idLoteBalanza");

                entity.ToTable("LoteBalanza", "balanza");

                entity.HasIndex(e => e.Codigo, "UC_balanza_LoteBalanza_codigo")
                    .IsUnique();

                entity.Property(e => e.IdLoteBalanza).HasColumnName("idLoteBalanza");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CantidadSacos)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cantidadSacos");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Conductores)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("conductores");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.FechaAcopio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaAcopio");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaIngreso");

                entity.Property(e => e.HoraAcopio)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("horaAcopio");

                entity.Property(e => e.HoraIngreso)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("horaIngreso");

                entity.Property(e => e.Humedad).HasColumnName("humedad");

                entity.Property(e => e.Humedad100).HasColumnName("humedad100");

                entity.Property(e => e.HumedadBase).HasColumnName("humedadBase");

                entity.Property(e => e.IdConcesion).HasColumnName("idConcesion");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdEstadoTipoMaterial).HasColumnName("idEstadoTipoMaterial");

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.IdUsuarioCreate).HasColumnName("idUsuarioCreate");

                entity.Property(e => e.IdUsuarioUpdate).HasColumnName("idUsuarioUpdate");

                entity.Property(e => e.NumeroTickets)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("numeroTickets");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.Property(e => e.PorcentajeCheckList).HasColumnName("porcentajeCheckList");

                entity.Property(e => e.Tmh).HasColumnName("tmh");

                entity.Property(e => e.Tmh100).HasColumnName("tmh100");

                entity.Property(e => e.TmhBase).HasColumnName("tmhBase");

                entity.Property(e => e.Tms).HasColumnName("tms");

                entity.Property(e => e.Tms100).HasColumnName("tms100");

                entity.Property(e => e.TmsBase).HasColumnName("tmsBase");

                entity.Property(e => e.Transportistas)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("transportistas");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDate");

                entity.Property(e => e.Vehiculos)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("vehiculos");

                entity.HasOne(d => d.IdConcesionNavigation)
                    .WithMany(p => p.LoteBalanzas)
                    .HasForeignKey(d => d.IdConcesion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_LoteBalanza_idConcesion");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.LoteBalanzaIdEstadoNavigations)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_LoteBalanza_idEstado");

                entity.HasOne(d => d.IdEstadoTipoMaterialNavigation)
                    .WithMany(p => p.LoteBalanzaIdEstadoTipoMaterialNavigations)
                    .HasForeignKey(d => d.IdEstadoTipoMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_LoteBalanza_idEstadoTipoMaterial");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.LoteBalanzas)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_LoteBalanza_idProveedor");
            });

            modelBuilder.Entity<LoteCodigo>(entity =>
            {
                entity.HasKey(e => e.IdLoteCodigo)
                    .HasName("PK_balanza_LoteCodigo_idLoteCodigo");

                entity.ToTable("LoteCodigo", "balanza");

                entity.Property(e => e.IdLoteCodigo).HasColumnName("idLoteCodigo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.CodigoHash)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigoHash");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.FechaRecepcion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRecepcion");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdLoteBalanza).HasColumnName("idLoteBalanza");

                entity.Property(e => e.IdUsuarioCreate).HasColumnName("idUsuarioCreate");

                entity.HasOne(d => d.IdLoteBalanzaNavigation)
                    .WithMany(p => p.LoteCodigos)
                    .HasForeignKey(d => d.IdLoteBalanza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_LoteCodigo_idLoteBalanza");
            });

            modelBuilder.Entity<Maestro>(entity =>
            {
                entity.HasKey(e => e.IdMaestro)
                    .HasName("PK_maestro_Maestro_idMaestro");

                entity.ToTable("Maestro", "maestro");

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

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo)
                    .HasName("PK_config_Modulo_id");

                entity.ToTable("Modulo", "config");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nivel).HasColumnName("nivel");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<ModuloUsuario>(entity =>
            {
                entity.HasKey(e => e.IdModuloUsuario)
                    .HasName("PK_config_ModuloUsuario_id");

                entity.ToTable("ModuloUsuario", "config");

                entity.Property(e => e.IdModuloUsuario).HasColumnName("idModuloUsuario");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdModulo).HasColumnName("idModulo");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            });

            modelBuilder.Entity<Muestreo>(entity =>
            {
                entity.HasKey(e => e.IdMuestreo)
                    .HasName("PK_muestreo_Muestreo_idMuestreo");

                entity.ToTable("Muestreo", "muestreo");

                entity.Property(e => e.IdMuestreo).HasColumnName("idMuestreo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoAum)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigoAum");

                entity.Property(e => e.CodigoCancha).HasColumnName("codigoCancha");

                entity.Property(e => e.CodigoCondicion).HasColumnName("codigoCondicion");

                entity.Property(e => e.CodigoEstado).HasColumnName("codigoEstado");

                entity.Property(e => e.CodigoResponsable).HasColumnName("codigoResponsable");

                entity.Property(e => e.CodigoTrujillo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigoTrujillo");

                entity.Property(e => e.CodigoTurno).HasColumnName("codigoTurno");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdEncargado).HasColumnName("idEncargado");

                entity.Property(e => e.IdLote).HasColumnName("idLote");

                entity.Property(e => e.LlevaGrueso).HasColumnName("llevaGrueso");
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
                    .HasConstraintName("fk_maestro_ProveedorConcesionr_idProveedor");
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

                entity.HasIndex(e => e.Numero, "UC_balanza_Ticket_numero")
                    .IsUnique();

                entity.Property(e => e.IdTicket).HasColumnName("idTicket");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CantidadUnidadMedida).HasColumnName("cantidadUnidadMedida");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaIngreso");

                entity.Property(e => e.FechaSalida)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaSalida");

                entity.Property(e => e.Grr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grr");

                entity.Property(e => e.Grt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grt");

                entity.Property(e => e.HoraIngreso)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("horaIngreso");

                entity.Property(e => e.HoraSalida)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("horaSalida");

                entity.Property(e => e.IdConductor).HasColumnName("idConductor");

                entity.Property(e => e.IdEstadoTmh).HasColumnName("idEstadoTmh");

                entity.Property(e => e.IdLoteBalanza).HasColumnName("idLoteBalanza");

                entity.Property(e => e.IdTipoMineral).HasColumnName("idTipoMineral");

                entity.Property(e => e.IdTransporte).HasColumnName("idTransporte");

                entity.Property(e => e.IdUnidadMedida).HasColumnName("idUnidadMedida");

                entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("observacion");

                entity.Property(e => e.PesoBruto).HasColumnName("pesoBruto");

                entity.Property(e => e.PesoBruto100).HasColumnName("pesoBruto100");

                entity.Property(e => e.PesoBrutoBase).HasColumnName("pesoBrutoBase");

                entity.Property(e => e.PesoNeto).HasColumnName("pesoNeto");

                entity.Property(e => e.PesoNeto100).HasColumnName("pesoNeto100");

                entity.Property(e => e.PesoNetoBase).HasColumnName("pesoNetoBase");

                entity.Property(e => e.Tara).HasColumnName("tara");

                entity.HasOne(d => d.IdConductorNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdConductor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_Ticket_idConductor");

                entity.HasOne(d => d.IdEstadoTmhNavigation)
                    .WithMany(p => p.TicketIdEstadoTmhNavigations)
                    .HasForeignKey(d => d.IdEstadoTmh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_Ticket_idEstadoTmh");

                entity.HasOne(d => d.IdLoteBalanzaNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdLoteBalanza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_Ticket_idLoteBalanza");

                entity.HasOne(d => d.IdTipoMineralNavigation)
                    .WithMany(p => p.TicketIdTipoMineralNavigations)
                    .HasForeignKey(d => d.IdTipoMineral)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_Ticket_idTipoMineral");

                entity.HasOne(d => d.IdTransporteNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdTransporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_Ticket_idTransporte");

                entity.HasOne(d => d.IdUnidadMedidaNavigation)
                    .WithMany(p => p.TicketIdUnidadMedidaNavigations)
                    .HasForeignKey(d => d.IdUnidadMedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_Ticket_idUnidadMedida");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.IdVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_balanza_Ticket_idVehiculo");
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

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK_config_Usuario_id");

                entity.ToTable("Usuario", "config");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");

                entity.Property(e => e.Nick)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nick");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.NroDocumento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nroDocumento");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo)
                    .HasName("PK_maestro_Vehiculo_idVehiculo");

                entity.ToTable("Vehiculo", "maestro");

                entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.IdTipoVehiculo).HasColumnName("idTipoVehiculo");

                entity.Property(e => e.IdVehiculoMarca).HasColumnName("idVehiculoMarca");

                entity.Property(e => e.Placa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("placa");

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
