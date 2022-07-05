﻿namespace Paltarumi.Acopio.Balanza.Dto.Ticket
{
    public class UpdateTicketDto //: TicketDto
    {
        public int IdTicket { get; set; }

        public int IdLoteBalanza { get; set; }
        public DateTimeOffset FechaIngreso { get; set; }
        public DateTimeOffset? FechaSalida { get; set; }
        public string? HoraSalida { get; set; }
        public int IdEstadoTmh { get; set; }
        public float PesoBruto100 { get; set; }
        public float PesoBrutoBase { get; set; }
        public float PesoBruto { get; set; }
        public float Tara { get; set; }
        public float PesoNeto100 { get; set; }
        public float PesoNetoBase { get; set; }
        public float PesoNeto { get; set; }
        public string Grr { get; set; } = null!;
        public string Grt { get; set; } = null!;
        public int IdTransporte { get; set; }
        public int IdConductor { get; set; }
        public int IdVehiculo { get; set; }
        public int IdTipoMineral { get; set; }
        public int IdUnidadMedida { get; set; }
        public int CantidadUnidadMedida { get; set; }
        public string Observacion { get; set; } = null!;

        public bool Activo { get; set; }
    }
}
