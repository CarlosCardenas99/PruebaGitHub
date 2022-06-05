using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class GetConductorQueryDni : QueryBase<GetConductorDto>
    {
        public GetConductorQueryDni(string dni) => Dni = dni;
        public string Dni { get; set; }
    }
}
