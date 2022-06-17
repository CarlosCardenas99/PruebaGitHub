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
            CreateMap<Entity.Ticket, ListTicketDto>()
                .ForMember(x => x.FechaHoraIngreso, opt => opt.MapFrom(x => x.FechaIngreso.ToString("yyyy-MM-dd") + " " + x.HoraIngreso))
                .ForMember(x => x.FechaHoraSalida, opt => opt.MapFrom(x => x.FechaSalida != null && x.HoraSalida != null ? Convert.ToDateTime(x.FechaSalida.ToString()).ToString("yyyy-MM-dd") + " " + x.HoraSalida : string.Empty))
                .ForMember(x => x.Conductor, opt => opt.MapFrom(x => x.IdConductorNavigation != null ? x.IdConductorNavigation.Nombres : string.Empty))
                .ForMember(x => x.Transporte, opt => opt.MapFrom(x => x.IdTransporteNavigation != null ? x.IdTransporteNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.UnidadMedida, opt => opt.MapFrom(x => x.IdUnidadMedidaNavigation != null ? x.IdUnidadMedidaNavigation.Descripcion : string.Empty))
                .ForMember(x => x.Placa, opt => opt.MapFrom(x => x.IdVehiculoNavigation != null ? x.IdVehiculoNavigation.Placa : string.Empty))
                .ForMember(x => x.EstadoTmh, opt => opt.MapFrom(x => x.IdEstadoTmhNavigation != null ? x.IdEstadoTmhNavigation.Descripcion : string.Empty))
                .ReverseMap();

            CreateMap<Entity.Ticket, SearchTicketDto>()
                .ForMember(x => x.Concesion, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation.IdConcesionNavigation != null ? x.IdLoteBalanzaNavigation.IdConcesionNavigation.Nombre : string.Empty))
                .ForMember(x => x.Proveedor, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation.IdProveedorNavigation != null ? x.IdLoteBalanzaNavigation.IdProveedorNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.Codigo, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation != null ? x.IdLoteBalanzaNavigation.Codigo : string.Empty))
                .ForMember(x => x.CantidadSacos, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation != null ? x.IdLoteBalanzaNavigation.CantidadSacos : string.Empty))
                .ForMember(x => x.PorcentajeHumedad, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation != null ? x.IdLoteBalanzaNavigation.Humedad.ToString() : string.Empty))
                .ForMember(x => x.VehiculoTara, opt => opt.MapFrom(x => x.IdVehiculoNavigation != null ? x.IdVehiculoNavigation.Tara.ToString() : string.Empty))

                .ForMember(x => x.Conductor, opt => opt.MapFrom(x => x.IdConductorNavigation != null ? x.IdConductorNavigation.Nombres : string.Empty))
                .ForMember(x => x.Licencia, opt => opt.MapFrom(x => x.IdConductorNavigation != null ? x.IdConductorNavigation.Licencia : string.Empty))
                .ForMember(x => x.Transportista, opt => opt.MapFrom(x => x.IdTransporteNavigation != null ? x.IdTransporteNavigation.Ruc + " - " + x.IdTransporteNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.UnidadMedida, opt => opt.MapFrom(x => x.IdUnidadMedidaNavigation != null ? x.IdUnidadMedidaNavigation.Descripcion : string.Empty))
                .ForMember(x => x.VehiculoMarca, opt => opt.MapFrom(x => x.IdVehiculoNavigation.IdVehiculoMarcaNavigation != null ? x.IdVehiculoNavigation.IdVehiculoMarcaNavigation.Descripcion : string.Empty))
                .ForMember(x => x.Placa, opt => opt.MapFrom(x => x.IdVehiculoNavigation != null ? x.IdVehiculoNavigation.Placa : string.Empty))
                .ForMember(x => x.TipoVehiculo, opt => opt.MapFrom(x => x.IdVehiculoNavigation.IdTipoVehiculoNavigation != null ? x.IdVehiculoNavigation.IdTipoVehiculoNavigation.Descripcion : string.Empty))
                //.ForMember(x => x.EstadoTmh, opt => opt.MapFrom(x => x.IdEstadoTmhNavigation != null ? x.IdEstadoTmhNavigation.Descripcion : string.Empty))
                .ReverseMap();
        }
    }
}
