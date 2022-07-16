using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class CreateLoteMuestreoCommand : CommandBase<GetLoteMuestreoDto>
    {
        public CreateLoteMuestreoCommand(CreateLoteMuestreoDto createDto) => CreateDto = createDto;
        public CreateLoteMuestreoDto CreateDto { get; set; }
    }
}
