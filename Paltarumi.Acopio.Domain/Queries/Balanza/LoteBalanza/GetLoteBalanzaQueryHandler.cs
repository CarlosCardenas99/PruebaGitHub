﻿using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.LoteBalanza
{
    public class GetLoteBalanzaQueryHandler : QueryHandlerBase<GetLoteBalanzaQuery, GetLoteBalanzaDto>
    {
        private readonly IRepositoryBase<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepositoryBase<Entity.Ticket> _ticketRepository;
        public GetLoteBalanzaQueryHandler(
            IMapper mapper,
            GetLoteBalanzaQueryValidator validator,
            IRepositoryBase<Entity.LoteBalanza> loteBalanzaRepository,
            IRepositoryBase<Entity.Ticket> ticketRepository
        ) : base(mapper, validator)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
            _ticketRepository = ticketRepository;   
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
            var loteDto = _mapper?.Map<GetLoteBalanzaDto>(loteBalanza);

            if (loteBalanza != null && loteDto != null)
            {
                loteDto.Estado = loteBalanza.IdEstadoNavigation == null ? null: _mapper?.Map<GetMaestroDto>(loteBalanza.IdEstadoNavigation);
                loteDto.Concesion = loteBalanza.IdConcesionNavigation == null ? null :  _mapper?.Map<GetConcesionDto>(loteBalanza.IdConcesionNavigation);
                loteDto.Proveedor = loteBalanza.IdProveedorNavigation == null ? null :  _mapper?.Map<GetProveedorDto>(loteBalanza.IdProveedorNavigation);
                loteDto.EstadoTipoMaterial = loteBalanza.IdEstadoTipoMaterialNavigation == null ? null :  _mapper?.Map<GetMaestroDto>(loteBalanza.IdEstadoTipoMaterialNavigation);

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
