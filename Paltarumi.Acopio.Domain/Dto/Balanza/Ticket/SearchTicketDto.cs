using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.Ticket
{
    public class SearchTicketDto
    {
        public int? IdTicket { get; set; }
        public int? IdLote { get; set; }
        public string? Numero { get; set; } = null!;
        public DateTime? FechaIngreso { get; set; }
        public string? HoraIngreso { get; set; } = null!;
        public DateTime? FechaSalida { get; set; }
        public string? HoraSalida { get; set; }
        public float? PesoBruto { get; set; }
        public float? Tara { get; set; }
        public float? PesoNeto { get; set; }
        public string? Grr { get; set; } = null!;
        public string? Grt { get; set; } = null!;
        public int? IdTransportista { get; set; }
        public int? IdConductor { get; set; }
        public int? IdVehiculo { get; set; }
        public int? IdUnidadMedida { get; set; }
        public int? CantidadUnidadMedida { get; set; }
        public string? Observacion { get; set; } = null!;
        public bool? Activo { get; set; }
        public string? Conductor { get; set; }
        public string? Transportista { get; set; }
        public string? UnidadMedida { get; set; }
        public string? VehiculoMarca { get; set; }
        public string? TipoVehiculo { get; set; }
    }
}
