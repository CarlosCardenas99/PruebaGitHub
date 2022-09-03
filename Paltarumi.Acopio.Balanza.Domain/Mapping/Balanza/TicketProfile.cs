using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Entity;

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

            CreateMap<Entity.Ticket, TicketBackup>()
                .ReverseMap();

            CreateMap<Entity.Ticket, GetTicketDto>()
                //.ForMember(x =>x.Vehiculo, opt => opt.MapFrom(x =>x.IdVehiculoNavigation))
                .ReverseMap();

            CreateMap<Entity.Ticket, ListTicketDto>()
                .ForMember(x => x.Conductor, opt => opt.MapFrom(x => x.IdConductorNavigation != null ? x.IdConductorNavigation.Nombres : string.Empty))
                .ForMember(x => x.ConductorLicencia, opt => opt.MapFrom(x => x.IdConductorNavigation != null ? x.IdConductorNavigation.Licencia : string.Empty))
                .ForMember(x => x.ConductorDni, opt => opt.MapFrom(x => x.IdConductorNavigation != null ? x.IdConductorNavigation.Numero : string.Empty))
                .ForMember(x => x.ConductorTipoLicencia, opt => opt.MapFrom(x => x.IdConductorNavigation.IdTipoLicenciaNavigation != null ? x.IdConductorNavigation.IdTipoLicenciaNavigation.Descripcion : string.Empty))

                .ForMember(x => x.Transporte, opt => opt.MapFrom(x => x.IdTransporteNavigation != null ? x.IdTransporteNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.TransporteRuc, opt => opt.MapFrom(x => x.IdTransporteNavigation != null ? x.IdTransporteNavigation.Ruc : string.Empty))
                .ForMember(x => x.UnidadMedida, opt => opt.MapFrom(x => x.IdUnidadMedidaNavigation != null ? x.IdUnidadMedidaNavigation.Descripcion : string.Empty))
                .ForMember(x => x.PlacaCarreta, opt => opt.MapFrom(x => x.IdVehiculoNavigation != null ? x.IdVehiculoNavigation.PlacaCarreta : string.Empty))
                .ForMember(x => x.Placa, opt => opt.MapFrom(x => x.IdVehiculoNavigation != null ? x.IdVehiculoNavigation.Placa : string.Empty))
                .ForMember(x => x.VehiculoMarca, opt => opt.MapFrom(x => x.IdVehiculoNavigation.IdVehiculoMarcaNavigation != null ? x.IdVehiculoNavigation.IdVehiculoMarcaNavigation.Descripcion : string.Empty))
                .ForMember(x => x.VehiculoTipo, opt => opt.MapFrom(x => x.IdVehiculoNavigation.IdTipoVehiculoNavigation != null ? x.IdVehiculoNavigation.IdTipoVehiculoNavigation.Descripcion : string.Empty))
                .ForMember(x => x.EstadoTmh, opt => opt.MapFrom(x => x.IdEstadoTmhNavigation != null ? x.IdEstadoTmhNavigation.Descripcion : string.Empty))
                .ForMember(x => x.EstadoTmhCarreta, opt => opt.MapFrom(x => x.IdEstadoTmhCarretaNavigation != null ? x.IdEstadoTmhCarretaNavigation.Descripcion : string.Empty))

                .ReverseMap();

            CreateMap<Entity.Ticket, SearchTicketDto>()

                .ForMember(x => x.Conductor, opt => opt.MapFrom(x => x.IdConductorNavigation != null ? x.IdConductorNavigation.Nombres : string.Empty))
                .ForMember(x => x.Licencia, opt => opt.MapFrom(x => x.IdConductorNavigation != null ? x.IdConductorNavigation.Licencia : string.Empty))
                .ForMember(x => x.Transportista, opt => opt.MapFrom(x => x.IdTransporteNavigation != null ? x.IdTransporteNavigation.Ruc + " - " + x.IdTransporteNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.UnidadMedida, opt => opt.MapFrom(x => x.IdUnidadMedidaNavigation != null ? x.IdUnidadMedidaNavigation.Descripcion : string.Empty))
                .ForMember(x => x.VehiculoMarca, opt => opt.MapFrom(x => x.IdVehiculoNavigation.IdVehiculoMarcaNavigation != null ? x.IdVehiculoNavigation.IdVehiculoMarcaNavigation.Descripcion : string.Empty))
                .ForMember(x => x.Placa, opt => opt.MapFrom(x => x.IdVehiculoNavigation != null ? x.IdVehiculoNavigation.Placa : string.Empty))
                .ForMember(x => x.TipoVehiculo, opt => opt.MapFrom(x => x.IdVehiculoNavigation.IdTipoVehiculoNavigation != null ? x.IdVehiculoNavigation.IdTipoVehiculoNavigation.Descripcion : string.Empty))
                .ForMember(x => x.EstadoTmh, opt => opt.MapFrom(x => x.IdEstadoTmhNavigation != null ? x.IdEstadoTmhNavigation.Descripcion : string.Empty))
                .ReverseMap();

            CreateMap<Entity.Ticket, SearchConsultaTicketDto>()
                .ForMember(x => x.Concesion, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation.IdConcesionNavigation != null ? x.IdLoteBalanzaNavigation.IdConcesionNavigation.Nombre : string.Empty))
                .ForMember(x => x.Proveedor, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation.IdProveedorNavigation != null ? x.IdLoteBalanzaNavigation.IdProveedorNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.IdLoteEstado, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation.IdLoteEstadoNavigation != null ? x.IdLoteBalanzaNavigation.IdLoteEstadoNavigation.IdLoteEstado : string.Empty))
                .ForMember(x => x.CodigoLote, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation != null ? x.IdLoteBalanzaNavigation.CodigoLote : string.Empty))
                .ForMember(x => x.CantidadSacos, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation != null ? x.IdLoteBalanzaNavigation.CantidadSacos : 0))
                .ForMember(x => x.VehiculoTara, opt => opt.MapFrom(x => x.IdVehiculoNavigation != null ? x.IdVehiculoNavigation.Tara.ToString() : string.Empty))
                .ForMember(x => x.Conductor, opt => opt.MapFrom(x => x.IdConductorNavigation != null ? x.IdConductorNavigation.Nombres : string.Empty))
                .ForMember(x => x.Licencia, opt => opt.MapFrom(x => x.IdConductorNavigation != null ? x.IdConductorNavigation.Licencia : string.Empty))
                .ForMember(x => x.Transportista, opt => opt.MapFrom(x => x.IdTransporteNavigation != null ? x.IdTransporteNavigation.Ruc + " - " + x.IdTransporteNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.UnidadMedida, opt => opt.MapFrom(x => x.IdUnidadMedidaNavigation != null ? x.IdUnidadMedidaNavigation.Descripcion : string.Empty))
                .ForMember(x => x.VehiculoMarca, opt => opt.MapFrom(x => x.IdVehiculoNavigation.IdVehiculoMarcaNavigation != null ? x.IdVehiculoNavigation.IdVehiculoMarcaNavigation.Descripcion : string.Empty))
                .ForMember(x => x.Placa, opt => opt.MapFrom(x => x.IdVehiculoNavigation != null ? x.IdVehiculoNavigation.Placa + " - " + x.IdVehiculoNavigation.PlacaCarreta : string.Empty))
                .ForMember(x => x.TipoVehiculo, opt => opt.MapFrom(x => x.IdVehiculoNavigation.IdTipoVehiculoNavigation != null ? x.IdVehiculoNavigation.IdTipoVehiculoNavigation.Descripcion : string.Empty))
                .ForMember(x => x.EstadoTmh, opt => opt.MapFrom(x => x.IdEstadoTmhNavigation != null ? x.IdEstadoTmhNavigation.Descripcion : string.Empty))
                .ForMember(x => x.EstadoTmhCarreta, opt => opt.MapFrom(x => x.IdEstadoTmhCarretaNavigation != null ? x.IdEstadoTmhCarretaNavigation.Descripcion : string.Empty))
                .ForMember(x => x.ConductorTipoLicencia, opt => opt.MapFrom(x => x.IdConductorNavigation.IdTipoLicenciaNavigation != null ? x.IdConductorNavigation.IdTipoLicenciaNavigation.Descripcion : string.Empty))
                .ReverseMap();
        }
    }
}
