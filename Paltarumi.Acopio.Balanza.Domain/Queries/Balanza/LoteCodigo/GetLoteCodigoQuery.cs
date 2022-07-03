using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteCodigo
{
    public class GetLoteCodigoQuery : QueryBase<GetLoteCodigoDto>
    {
        public GetLoteCodigoQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
