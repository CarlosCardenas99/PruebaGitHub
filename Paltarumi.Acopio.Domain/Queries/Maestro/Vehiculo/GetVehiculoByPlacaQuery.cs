using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Maestro.Vehiculo;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Vehiculo
{
    public class GetVehiculoByPlacaQuery : QueryBase<GetVehiculoDto>
    {
        public GetVehiculoByPlacaQuery(string placa) => Placa = placa;
        public string Placa { get; set; }
    }
}
