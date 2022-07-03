using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.LeyReferencial;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyReferencial
{
    public class GetLeyReferencialQuery : QueryBase<GetLeyReferencialDto>
    {
        public GetLeyReferencialQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
