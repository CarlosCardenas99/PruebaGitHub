using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Vehiculo
{
    public class GetVehiculoByPlacaQuery : QueryBase<GetVehiculoDto>
    {
        public GetVehiculoByPlacaQuery(string placa) => Placa = placa;
        public string Placa { get; set; }
    }
}
