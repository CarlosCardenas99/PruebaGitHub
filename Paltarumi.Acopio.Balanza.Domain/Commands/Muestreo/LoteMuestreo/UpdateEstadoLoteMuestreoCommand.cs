// TO DO : PRUEBA
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class UpdateEstadoLoteMuestreoCommand : CommandBase<GetLoteMuestreoDto>
    {
        public UpdateEstadoLoteMuestreoCommand(UpdateEstadoLoteMuestreoDto updateDto) => UpdateDto = updateDto;
        public UpdateEstadoLoteMuestreoDto UpdateDto { get; set; }
    }
}
