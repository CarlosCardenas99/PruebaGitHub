using Paltarumi.Acopio.Balanza.Entity.Audit;

namespace Paltarumi.Acopio.Balanza.Entity
{
    [Auditable]
    public partial class Ticket
    {
        public int IdTicket { get; set; }
        public int IdLoteBalanza { get; set; }
        public string Numero { get; set; } = null!;
        public DateTimeOffset FechaIngreso { get; set; }
        public DateTimeOffset? FechaSalida { get; set; }
        public int IdEstadoTmh { get; set; }
        public float PesoBruto100 { get; set; }
        public float PesoBrutoBase { get; set; }
        public float PesoBruto { get; set; }
        public bool PesoBrutoEdit { get; set; }
        public int? IdUsuarioAprobadorPesoBruto { get; set; }
        public float Tara { get; set; }
        public float PesoNeto100 { get; set; }
        public float PesoNetoBase { get; set; }
        public float PesoNeto { get; set; }
        public int IdEstadoTmhCarreta { get; set; }
        public float PesoBrutoCarreta100 { get; set; }
        public float PesoBrutoCarretaBase { get; set; }
        public float PesoBrutoCarreta { get; set; }
        public bool PesoBrutoCarretaEdit { get; set; }
        public int? IdUsuarioAprobadorPesoBrutoCarreta { get; set; }
        public float TaraCarreta { get; set; }
        public float PesoNetoCarreta100 { get; set; }
        public float PesoNetoCarretaBase { get; set; }
        public float PesoNetoCarreta { get; set; }
        public float PesoNetoTotal { get; set; }
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
        public virtual Maestro IdEstadoTmhCarretaNavigation { get; set; } = null!;
        public virtual Maestro IdEstadoTmhNavigation { get; set; } = null!;
        public virtual LoteBalanza IdLoteBalanzaNavigation { get; set; } = null!;
        public virtual Transporte? IdTransporteNavigation { get; set; }
        public virtual Maestro IdUnidadMedidaNavigation { get; set; } = null!;
        public virtual Maestro? IdUsuarioAprobadorPesoBrutoCarretaNavigation { get; set; }
        public virtual Maestro? IdUsuarioAprobadorPesoBrutoNavigation { get; set; }
        public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
    }
}
