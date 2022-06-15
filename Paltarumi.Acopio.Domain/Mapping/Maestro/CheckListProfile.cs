using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.CheckList;

namespace Paltarumi.Acopio.Domain.Mapping.Maestro
{
    public class CheckListProfile : Profile
    {
        public CheckListProfile()
        {
            CreateMap<Entity.CheckList, CheckListDto>()
                .ReverseMap();

            CreateMap<Entity.CheckList, CreateCheckListDto>()
                .ReverseMap();

            CreateMap<Entity.CheckList, UpdateCheckListDto>()
                .ReverseMap();

            CreateMap<Entity.CheckList, GetCheckListDto>()
                .ReverseMap();

            CreateMap<Entity.CheckList, ListCheckListDto>()
                .ReverseMap();

            CreateMap<Entity.CheckList, SearchCheckListDto>()
                .ForMember(x => x.FechaIngreso, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation.FechaIngreso.ToString("yyyy-MM-dd") )) //+ " " + x.HoraIngreso
                .ForMember(x => x.NombreProveedor, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation.IdProveedorNavigation != null ? x.IdLoteBalanzaNavigation.IdProveedorNavigation.RazonSocial : string.Empty))
                .ForMember(x => x.Ruc, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation.IdProveedorNavigation != null ? x.IdLoteBalanzaNavigation.IdProveedorNavigation.Ruc : string.Empty))
                .ForMember(x => x.EstadoPorcentual, opt => opt.MapFrom(x => x.IdLoteBalanzaNavigation.PorcentajeCheckList))
                .ReverseMap();
        }
    }
}
