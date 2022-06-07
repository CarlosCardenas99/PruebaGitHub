﻿using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Ticket
{
    public class ListTicketQueryHandler : QueryHandlerBase<ListTicketQuery, IEnumerable<ListTicketDto>>
    {
        private readonly IRepositoryBase<Entity.Ticket> _ticketRepository;

        public ListTicketQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Ticket> ticketRepository
        ) : base(mapper)
        {
            _ticketRepository = ticketRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListTicketDto>>> HandleQuery(ListTicketQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListTicketDto>>();
            var tickets = await _ticketRepository.FindByAsync(
                x => x.IdLote == request.IdLote,
                x => x.IdConductorNavigation,
                x => x.IdTransporteNavigation,
                x => x.IdEstadoTmhNavigation,
                x => x.IdUnidadMedidaNavigation,
                x => x.IdVehiculoNavigation
                );
            var ticketDto = _mapper?.Map<IEnumerable<ListTicketDto>>(tickets);

            if (tickets != null && ticketDto != null)
            {

                response.UpdateData(ticketDto);
            }

            return await Task.FromResult(response);
        }
    }
}
