using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class CreateLoteMuestreoCommand : CommandBase<GetLoteMuestreoDto>
    {
        public CreateLoteMuestreoCommand(string codigoPlanta, string codigoPlantaRandom, CreateLoteMuestreoDto createDto)
        {
            CodigoPlanta = codigoPlanta;
            CodigoPlantaRandom = codigoPlantaRandom;
            CreateDto = createDto;
        }

        public string CodigoPlanta { get; set; }
        public string CodigoPlantaRandom { get; set; }
        public CreateLoteMuestreoDto CreateDto { get; set; }
    }
}
