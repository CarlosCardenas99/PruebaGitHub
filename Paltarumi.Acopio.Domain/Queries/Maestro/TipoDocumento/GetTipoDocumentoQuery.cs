using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.TipoDocumento;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.TipoDocumento
{
    public class GetTipoDocumentoQuery : QueryBase<GetTipoDocumentoDto>
    {
        public GetTipoDocumentoQuery(string id) => Id = id;
        public string Id { get; set; }
    }
}
