
namespace Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket
{
    public class ListTicketDto : TicketDto
    {
        public int IdTicket { get; set; }
        public string? Numero { get; set; }
        public bool Activo { get; set; }
        public string Conductor { get; set; } = null!;
        public string ConductorTipoLicencia { get; set; } = null!;
        public string ConductorLicencia { get; set; } = null!;
        public string ConductorDni { get; set; } = null!;
        public string Transporte { get; set; } = null!;
        public string TransporteRuc { get; set; } = null!;
        public string UnidadMedida { get; set; } = null!;
        public string VehiculoMarca { get; set; } = null!;
        public string VehiculoTipo { get; set; } = null!;
        public string Placa { get; set; } = null!;
        public string PlacaCarreta { get; set; } = null!;
        public string EstadoTmh { get; set; } = null!;
        public string EstadoTmhCarreta { get; set; } = null!;
    }
}
