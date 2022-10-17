using AutoMapper;
using Paltarumi.Acopio.Maestros.Dto.Acopio.Empresa;

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
        }
    }
}
