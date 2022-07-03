using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteCodigo;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCodigo
{
    public class GetLoteCodigoQuery : QueryBase<GetLoteCodigoDto>
    {
        public GetLoteCodigoQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
