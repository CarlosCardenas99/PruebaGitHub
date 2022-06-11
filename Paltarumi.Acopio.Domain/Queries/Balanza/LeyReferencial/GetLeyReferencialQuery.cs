using Paltarumi.Acopio.Domain.Dto.Balanza.LeyReferencial;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyReferencial
{
    public class GetLeyReferencialQuery : QueryBase<GetLeyReferencialDto>
    {
        public GetLeyReferencialQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
