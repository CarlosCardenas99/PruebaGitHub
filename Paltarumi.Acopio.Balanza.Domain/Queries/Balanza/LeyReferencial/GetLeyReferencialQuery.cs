using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LeyReferencial;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LeyReferencial
{
    public class GetLeyReferencialQuery : QueryBase<GetLeyReferencialDto>
    {
        public GetLeyReferencialQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
