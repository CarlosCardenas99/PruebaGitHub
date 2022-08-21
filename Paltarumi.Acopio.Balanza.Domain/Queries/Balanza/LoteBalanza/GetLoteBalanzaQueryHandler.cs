using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Dto.Config.Empresa;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;
using Paltarumi.Acopio.Maestro.Dto.Maestro;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza
{
    public class GetLoteBalanzaQueryHandler : QueryHandlerBase<GetLoteBalanzaQuery, GetLoteBalanzaDto>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;
        private readonly IRepository<Entity.Maestro> _maestroRepository;
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entity.LoteMuestreo> _loteMuestreoRepository;
        private readonly IRepository<Entity.Lote> _loteRepository;

        public GetLoteBalanzaQueryHandler(
            IMapper mapper,
            GetLoteBalanzaQueryValidator validator,
            IRepository<Entity.Ticket> ticketRepository,
            IRepository<Entity.Maestro> maestroRepository,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IRepository<Entity.LoteMuestreo> loteMuestreoRepository,
            IRepository<Entity.Lote> loteRepository
        ) : base(mapper, validator)
        {
            _ticketRepository = ticketRepository;
            _maestroRepository = maestroRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _loteMuestreoRepository = loteMuestreoRepository;
            _loteRepository = loteRepository;
        }

        protected override async Task<ResponseDto<GetLoteBalanzaDto>> HandleQuery(GetLoteBalanzaQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaDto>();

            var loteBalanza = await _loteBalanzaRepository.GetByAsync(
                x => x.IdLoteBalanza == request.Id,
                x => x.Tickets,
                x => x.IdEstadoNavigation,
                x => x.IdConcesionNavigation,
                x => x.IdProveedorNavigation,
                x => x.IdEstadoTipoMaterialNavigation
                );

            var loteMuestreo = loteBalanza != null ? await _loteMuestreoRepository
                .GetByAsNoTrackingAsync(
                    x => x.CodigoLote == loteBalanza.CodigoLote
                ) : null;

            var tipoMineral = loteMuestreo != null ?
                await _maestroRepository.GetByAsNoTrackingAsync(x => x.IdMaestro == loteMuestreo.IdTipoMineral) : null;

            var lote = await _loteRepository.GetByAsNoTrackingAsync(
                    x => x.CodigoLote == loteBalanza.CodigoLote,
                    x => x.IdEmpresaNavigation    
                );

            var loteDto = _mapper?.Map<GetLoteBalanzaDto>(loteBalanza);

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

                loteDto.IdTipoMineral = tipoMineral?.IdMaestro;
                loteDto.TipoMineral = tipoMineral != null ? _mapper!.Map<GetMaestroDto>(tipoMineral) : null;
                loteDto.Empresa = _mapper!.Map<GetEmpresaDto>(lote.IdEmpresaNavigation) ?? null;

                response.UpdateData(loteDto);
            }

            return await Task.FromResult(response);
        }
    }
}
