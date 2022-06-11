using Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyesReferenciales
{
    public class GetLeyesReferencialesQuery : QueryBase<GetLeyesReferencialesDto>
    {
        public GetLeyesReferencialesQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
