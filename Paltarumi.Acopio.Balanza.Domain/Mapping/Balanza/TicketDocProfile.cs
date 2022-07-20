using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Resources.Balanza;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Balanza
{
    public class TicketDocProfile : Profile
    {
        public TicketDocProfile()
        {
            CreateMap<Entity.TicketDoc, CreateTicketDto>()
                .ReverseMap();

            CreateMap<Entity.TicketDoc, TicketDocDto>()
                .ReverseMap();

            CreateMap<Entity.TicketDoc, CreateTicketDocDto>()
                .ReverseMap();

            CreateMap<Entity.TicketDoc, UpdateTicketDocDto>()
                .ReverseMap();

            CreateMap<Entity.TicketDoc, GetTicketDocDto>()
                .ReverseMap();

            CreateMap<Entity.TicketDoc, SearchTicketDocDto>()
                .ReverseMap();
        }
    }
}
