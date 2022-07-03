using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Concesion
{
    public class GetConcesionQueryCodUnico : QueryBase<GetConcesionDto>
    {
        public GetConcesionQueryCodUnico(string codigoUnico) => CodigoUnico = codigoUnico;
        public string CodigoUnico { get; set; }
    }
}
