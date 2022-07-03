using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Transporte;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Transporte
{
    public class GetTransporteQuery : QueryBase<GetTransporteDto>
    {
        public GetTransporteQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
