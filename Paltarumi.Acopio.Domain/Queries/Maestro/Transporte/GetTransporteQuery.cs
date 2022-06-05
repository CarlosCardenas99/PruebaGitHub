using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Transporte
{
    public class GetTransporteQuery : QueryBase<GetTransporteDto>
    {
        public GetTransporteQuery(int id) => Id = id;
        public int Id { get; set; }
    }
}
