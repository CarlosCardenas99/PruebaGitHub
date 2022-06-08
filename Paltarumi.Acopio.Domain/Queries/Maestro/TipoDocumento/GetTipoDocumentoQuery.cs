using Paltarumi.Acopio.Domain.Dto.Maestro.TipoDocumento;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.TipoDocumento
{
    public class GetTipoDocumentoQuery : QueryBase<GetTipoDocumentoDto>
    {
        public GetTipoDocumentoQuery(string id) => Id = id;
        public string Id { get; set; }
    }
}
