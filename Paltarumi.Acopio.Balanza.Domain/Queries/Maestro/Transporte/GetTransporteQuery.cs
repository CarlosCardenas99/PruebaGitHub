using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Transporte;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Transporte
{
    public class GetTransporteQuery : QueryBase<GetTransporteDto>
    {
        public GetTransporteQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
