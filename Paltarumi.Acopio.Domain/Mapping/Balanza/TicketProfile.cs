using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Domain.Mapping.Balanza
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

            CreateMap<Entity.Ticket, SearchTicketDto>()
                .ForMember(x => x.Conductor, opt => opt.MapFrom(x => x.IdConductorNavigation != null ? x.IdConductorNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.Transportista, opt => opt.MapFrom(x => x.IdTransportistaNavigation != null ? x.IdTransportistaNavigation.Numero + " - " +x.IdTransportistaNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.UnidadMedida, opt => opt.MapFrom(x => x.IdUnidadMedidaNavigation != null ? x.IdUnidadMedidaNavigation.Descripcion : string.Empty))
                .ForMember(x => x.VehiculoMarca, opt => opt.MapFrom(x => x.IdVehiculoNavigation.IdVehiculoMarcaNavigation != null ? x.IdVehiculoNavigation.IdVehiculoMarcaNavigation.Descripcion : string.Empty))
                .ForMember(x => x.TipoVehiculo, opt => opt.MapFrom(x => x.IdVehiculoNavigation.IdTipoVehiculoNavigation != null ? x.IdVehiculoNavigation.IdTipoVehiculoNavigation.Descripcion : string.Empty))
                .ReverseMap();
        }
    }
}
