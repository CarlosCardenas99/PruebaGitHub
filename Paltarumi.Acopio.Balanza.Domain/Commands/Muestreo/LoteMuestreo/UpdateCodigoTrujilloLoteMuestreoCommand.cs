// TO DO : PRUEBA
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class UpdateCodigoTrujilloLoteMuestreoCommand : CommandBase<GetLoteMuestreoDto>
    {
        public UpdateCodigoTrujilloLoteMuestreoCommand(UpdateCodigoTrujilloLoteMuestreoDto updateDto) => UpdateDto = updateDto;
        public UpdateCodigoTrujilloLoteMuestreoDto UpdateDto { get; set; }
    }
}
