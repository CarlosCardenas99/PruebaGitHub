using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.TipoDocumento;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.TipoDocumento
{
    public class GetTipoDocumentoQuery : QueryBase<GetTipoDocumentoDto>
    {
        public GetTipoDocumentoQuery(string id) => Id = id;
        public string Id { get; set; }
    }
}
