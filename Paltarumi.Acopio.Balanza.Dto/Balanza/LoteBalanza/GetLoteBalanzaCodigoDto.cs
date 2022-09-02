﻿using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteEstado;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Maestro.Dto.Concesion;
using Paltarumi.Acopio.Maestro.Dto.Maestro;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Dto.LoteBalanza
{
    public class GetLoteBalanzaCodigoDto : LoteBalanzaDto
    {
        public int IdLoteBalanza { get; set; }
        public GetConcesionDto? Concesion { get; set; }
        public GetMaestroDto? EstadoTipoMaterial { get; set; }
        public GetProveedorDto? Proveedor { get; set; }
        public GetLoteEstadoDto? Estado { get; set; }
        public bool Activo { get; set; }
        public IEnumerable<ListTicketDto>? TicketDetails { get; set; }
    }
}
