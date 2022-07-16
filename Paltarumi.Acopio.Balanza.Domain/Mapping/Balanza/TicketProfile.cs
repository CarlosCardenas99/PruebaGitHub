using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Balanza
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Entity.Ticket, TicketDto>()
                .ReverseMap();

            CreateMap<Entity.Ticket, CreateTicketDto>()
                .ReverseMap();

            CreateMap<Entity.Ticket, UpdateTicketDto>()
                .ReverseMap();

            CreateMap<Entity.Ticket, GetTicketDto>()
                .ReverseMap();

            CreateMap<Entity.Ticket, ListTicketDto>()
                .ReverseMap();

            CreateMap<Entity.Ticket, SearchTicketDto>()
                .ReverseMap();
        }
    }
}
