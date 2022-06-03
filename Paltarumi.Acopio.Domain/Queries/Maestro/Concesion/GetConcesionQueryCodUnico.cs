using Paltarumi.Acopio.Domain.Dto.Maestro.Concesion;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
{
    public class GetConcesionQueryCodUnico : QueryBase<GetConcesionDto>
    {
        public GetConcesionQueryCodUnico(string codigoUnico) => CodigoUnico = codigoUnico;
        public string CodigoUnico { get; set; }
    }
}
