using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class UpdateLoteMuestreoCommand : CommandBase<GetLoteMuestreoDto>
    {
        public UpdateLoteMuestreoCommand(UpdateLoteMuestreoDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteMuestreoDto UpdateDto { get; set; }
    }
}
