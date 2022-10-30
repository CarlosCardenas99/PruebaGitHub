﻿using System;
using System.Collections.Generic;

namespace Paltarumi.Acopio.Balanza.Entity
{
    public partial class Ticket
    {
        public int IdTicket { get; set; }
        public int IdLoteBalanza { get; set; }
        public string Numero { get; set; } = null!;
        public DateTimeOffset FechaIngreso { get; set; }
        public DateTimeOffset? FechaSalida { get; set; }
        public int IdEstadoTmh { get; set; }
        public decimal PesoBruto100 { get; set; }
        public decimal PesoBrutoBase { get; set; }
        public decimal PesoBruto { get; set; }
        public bool PesoBrutoEdit { get; set; }
        public int? IdUsuarioAprobadorPesoBruto { get; set; }
        public int? IdEstadoTmhTara { get; set; }
        public decimal Tara100 { get; set; }
        public decimal Tara { get; set; }
        public decimal PesoNeto100 { get; set; }
        public decimal PesoNetoBase { get; set; }
        public decimal PesoNeto { get; set; }
        public int? IdEstadoTmhCarreta { get; set; }
        public decimal PesoBrutoCarreta100 { get; set; }
        public decimal PesoBrutoCarretaBase { get; set; }
        public decimal PesoBrutoCarreta { get; set; }
        public bool PesoBrutoCarretaEdit { get; set; }
        public int? IdUsuarioAprobadorPesoBrutoCarreta { get; set; }
        public int? IdEstadoTmhTaraCarreta { get; set; }
        public decimal TaraCarreta100 { get; set; }
        public decimal TaraCarreta { get; set; }
        public decimal PesoNetoCarreta100 { get; set; }
        public decimal PesoNetoCarretaBase { get; set; }
        public decimal PesoNetoCarreta { get; set; }
        public decimal PesoNetoTotal { get; set; }
        public string Grr { get; set; } = null!;
        public string Grt { get; set; } = null!;
        public int? IdTransporte { get; set; }
        public int? IdConductor { get; set; }
        public int IdVehiculo { get; set; }
        public int IdUnidadMedida { get; set; }
        public int CantidadUnidadMedida { get; set; }
        public string Observacion { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual Conductor? IdConductorNavigation { get; set; }
        public virtual Maestro? IdEstadoTmhCarretaNavigation { get; set; }
        public virtual Maestro IdEstadoTmhNavigation { get; set; } = null!;
        public virtual Maestro? IdEstadoTmhTaraCarretaNavigation { get; set; }
        public virtual Maestro? IdEstadoTmhTaraNavigation { get; set; }
        public virtual LoteBalanza IdLoteBalanzaNavigation { get; set; } = null!;
        public virtual Transporte? IdTransporteNavigation { get; set; }
        public virtual Maestro IdUnidadMedidaNavigation { get; set; } = null!;
        public virtual Maestro? IdUsuarioAprobadorPesoBrutoCarretaNavigation { get; set; }
        public virtual Maestro? IdUsuarioAprobadorPesoBrutoNavigation { get; set; }
        public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
    }
}
