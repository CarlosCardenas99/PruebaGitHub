using AutoMapper;
using Paltarumi.Acopio.Entity;
using Paltarumi.Acopio.Maestros.Dto.Acopio.Empresa;

namespace Paltarumi.Acopio.Balanza.Domain.Mapping.Config
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<Empresa, EmpresaDto>()
                .ReverseMap();

            CreateMap<Empresa, GetEmpresaDto>()
                .ReverseMap();
        }
    }
}
