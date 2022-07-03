using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Conductor;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class GetConductorQueryDni : QueryBase<GetConductorDto>
    {
        public GetConductorQueryDni(string dni) => Dni = dni;
        public string Dni { get; set; }
    }
}
