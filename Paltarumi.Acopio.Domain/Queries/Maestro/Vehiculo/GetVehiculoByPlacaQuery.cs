using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;
using Paltarumi.Acopio.Domain.Queries.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Vehiculo
{
    public class GetVehiculoByPlacaQuery : QueryBase<GetVehiculoDto>
    {
        public GetVehiculoByPlacaQuery(string placa) => Placa = placa;
        public string Placa { get; set; }
    }
}
