using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Concesion;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Concesion
{
    public class GetConcesionQueryCodUnico : QueryBase<GetConcesionDto>
    {
        public GetConcesionQueryCodUnico(string codigoUnico) => CodigoUnico = codigoUnico;
        public string CodigoUnico { get; set; }
    }
}
