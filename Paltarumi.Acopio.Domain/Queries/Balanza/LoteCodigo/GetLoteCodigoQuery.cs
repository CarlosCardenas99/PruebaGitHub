using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCodigo
{
    public class GetLoteCodigoQuery : QueryBase<GetLoteCodigoDto>
    {
        public GetLoteCodigoQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
