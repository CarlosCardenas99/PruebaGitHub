﻿namespace Paltarumi.Acopio.Domain.Dto.Balanza.Ticket
{
    public class SearchTicketDto
    {
        public int? IdTicket { get; set; }
        public string Numero { get; set; } = null!;
        public DateTime? FechaIngreso { get; set; }
        public string HoraIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string HoraSalida { get; set; }
        public string EstadoTmh { get; set; }
        public float? PesoBruto { get; set; }
        public float? Tara { get; set; }
        public float? PesoNeto { get; set; }
        public string Grr { get; set; }
        public string Grt { get; set; }
        public string Licencia { get; set; }
        public string Placa { get; set; }
        public string VehiculoMarca { get; set; }
        public string Conductor { get; set; }
        public string Transportista { get; set; }
        public string UnidadMedida { get; set; }
        public string CantidadUnidadMedida { get; set; }
        public string TipoVehiculo { get; set; }

    }
}
