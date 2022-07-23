using AutoMapper;
using Paltarumi.Acopio.Balanza.Dto.Config.Empresa;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Config
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<Entity.Empresa, EmpresaDto>()
                .ReverseMap();

            CreateMap<Entity.Empresa, GetEmpresaDto>()
                .ReverseMap();

            CreateMap<Entity.Empresa, SelectComboEmpresaDto>()
                .ReverseMap();
        }
    }
}
