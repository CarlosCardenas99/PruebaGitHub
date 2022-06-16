﻿using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Domain.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;

namespace Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza
{
    public class GetLoteBalanzaCodigoDto : LoteBalanzaDto
    {
        public int IdLoteBalanza { get; set; }
        public GetConcesionDto? Concesion { get; set; }
        public GetMaestroDto? EstadoTipoMaterial { get; set; }
        public GetProveedorDto? Proveedor { get; set; }
        public GetMaestroDto? Estado { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<ListTicketDto>? TicketDetails { get; set; }
    }
}
