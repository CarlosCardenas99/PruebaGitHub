using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Lote
{
    public class GetLoteQueryHandler : QueryHandlerBase<GetLoteQuery, GetLoteDto>
    {
        private readonly IRepositoryBase<Entity.Lote> _loteRepository;
        private readonly IRepositoryBase<Entity.Ticket> _ticketRepository;
        public GetLoteQueryHandler(
            IMapper mapper,
            GetLoteQueryValidator validator,
            IRepositoryBase<Entity.Lote> loteRepository,
            IRepositoryBase<Entity.Ticket> ticketRepository
        ) : base(mapper, validator)
        {
            _loteRepository = loteRepository;
            _ticketRepository = ticketRepository;   
        }

        protected override async Task<ResponseDto<GetLoteDto>> HandleQuery(GetLoteQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteDto>();
            var lote = await _loteRepository.GetByAsync(
                x => x.IdLote == request.Id,
                x => x.Tickets,
                x => x.IdEstadoNavigation,
                x => x.IdConcesionNavigation,
                x => x.IdProveedorNavigation,
                x => x.IdEstadoTipoMaterialNavigation
                );
            var loteDto = _mapper?.Map<GetLoteDto>(lote);

            if (lote != null && loteDto != null)
            {
                loteDto.Estado = _mapper?.Map<GetMaestroDto>(lote.IdEstadoNavigation) ?? null;
                loteDto.Concesion = _mapper?.Map<GetConcesionDto>(lote.IdConcesionNavigation) ?? null;
                loteDto.Proveedor = _mapper?.Map<GetProveedorDto>(lote.IdProveedorNavigation) ?? null;
                loteDto.EstadoTipoMaterial = _mapper?.Map<GetMaestroDto>(lote.IdEstadoTipoMaterialNavigation);

                var idTickets = lote.Tickets.Select(x => x.IdTicket);
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
