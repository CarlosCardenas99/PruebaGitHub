using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Vehiculo;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.Ticket
{
    public class GetTicketByCodigoQueryHandler : QueryHandlerBase<GetTicketByCodigoQuery, GetTicketByCodigoDto>
    {

        private readonly IRepository<Entities.Ticket> _ticketRepository;
        public GetTicketByCodigoQueryHandler(
            IMapper mapper,
            GetTicketByCodigoQueryValidator validator,
            IRepository<Entities.Ticket> ticketRepository
        ) : base(mapper, validator)
        {
            _ticketRepository = ticketRepository;
        }

    }
}
