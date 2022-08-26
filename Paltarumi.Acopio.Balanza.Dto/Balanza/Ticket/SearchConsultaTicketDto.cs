namespace Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket
{
    public class SearchConsultaTicketDto
    {
        public int IdLoteBalanza { get; set; }
        public int? IdTicket { get; set; }
        public string CodigoLote { get; set; } = null!;//lote
        public string CodigoEstado { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public DateTimeOffset? FechaIngreso { get; set; }
        public DateTimeOffset? FechaSalida { get; set; }
        public string Concesion { get; set; } = null!;//concesion
        public string Proveedor { get; set; } = null!;//proveedor
        public string Grr { get; set; } = null!;
        public string Grt { get; set; } = null!;
        public string EstadoTmh { get; set; } = null!;
        public float? PesoBruto { get; set; }
        public float? Tara { get; set; }
        public float? PesoNeto { get; set; }
        public string EstadoTmhCarreta { get; set; } = null!;
        public float PesoBrutoCarreta { get; set; }
        public float TaraCarreta { get; set; }
        public float PesoNetoCarreta { get; set; }
        public float PesoNetoTotal { get; set; }
        public string Transportista { get; set; } = null!;//transporte
        public string Placa { get; set; } = null!;
        public string VehiculoMarca { get; set; } = null!;
        public string TipoVehiculo { get; set; } = null!;
        public float? VehiculoTara { get; set; }
        public string Conductor { get; set; } = null!;//conductor
        public string ConductorTipoLicencia { get; set; } = null!;
        public string Licencia { get; set; } = null!;
        public string UnidadMedida { get; set; } = null!;
        public int CantidadSacos { get; set; }
        public float? PorcentajeHumedad { get; set; }
        public string CantidadUnidadMedida { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
