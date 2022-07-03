using AutoMapper;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Dto.Maestro.Proveedor;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteBalanza
{
    public class GetLoteBalanzaByCodigoQueryHandler : QueryHandlerBase<GetLoteBalanzaByCodigoQuery, GetLoteBalanzaCodigoDto>
    {
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entity.Ticket> _ticketRepository;
        public GetLoteBalanzaByCodigoQueryHandler(
            IMapper mapper,
            GetLoteBalanzaByCodigoQueryValidator validator,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IRepository<Entity.Ticket> ticketRepository
        ) : base(mapper, validator)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
            _ticketRepository = ticketRepository;
        }
        protected override async Task<ResponseDto<GetLoteBalanzaCodigoDto>> HandleQuery(GetLoteBalanzaByCodigoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaCodigoDto>();
            var loteBalanza = await _loteBalanzaRepository.GetByAsync(
                x => x.Codigo == request.Codigo,
                x => x.Tickets,
                x => x.IdEstadoNavigation,
                x => x.IdConcesionNavigation,
                x => x.IdProveedorNavigation,
                x => x.IdEstadoTipoMaterialNavigation
                );
            var loteDto = _mapper?.Map<GetLoteBalanzaCodigoDto>(loteBalanza);

            if (loteBalanza != null && loteDto != null)
            {
                loteDto.Estado = loteBalanza.IdEstadoNavigation == null ? null : _mapper?.Map<GetMaestroDto>(loteBalanza.IdEstadoNavigation);
                loteDto.Concesion = loteBalanza.IdConcesionNavigation == null ? null : _mapper?.Map<GetConcesionDto>(loteBalanza.IdConcesionNavigation);
                loteDto.Proveedor = loteBalanza.IdProveedorNavigation == null ? null : _mapper?.Map<GetProveedorDto>(loteBalanza.IdProveedorNavigation);
                loteDto.EstadoTipoMaterial = loteBalanza.IdEstadoTipoMaterialNavigation == null ? null : _mapper?.Map<GetMaestroDto>(loteBalanza.IdEstadoTipoMaterialNavigation);

                var idTickets = loteBalanza.Tickets.Select(x => x.IdTicket);
                var tickets = await _ticketRepository.FindByAsNoTrackingAsync(
                    x => idTickets.Contains(x.IdTicket),
                    x => x.IdConductorNavigation,
                    x => x.IdTransporteNavigation,
                    x => x.IdEstadoTmhNavigation,
                    x => x.IdUnidadMedidaNavigation,
                    x => x.IdVehiculoNavigation
                    );
                loteDto.TicketDetails = _mapper?.Map<IEnumerable<ListTicketDto>>(tickets);

                response.UpdateData(loteDto);
            }

            return await Task.FromResult(response);
        }
    }
}
