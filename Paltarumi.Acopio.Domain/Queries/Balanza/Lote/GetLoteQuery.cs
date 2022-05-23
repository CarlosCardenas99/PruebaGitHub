using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Lote
{
    public class GetLoteQuery : QueryBase<GetLoteDto>
    {
        public GetLoteQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
