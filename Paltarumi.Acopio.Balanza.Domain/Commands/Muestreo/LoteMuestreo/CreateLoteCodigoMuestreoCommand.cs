using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteCodigoMuestreo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class CreateLoteCodigoMuestreoCommand : CommandBase<CreateLoteCodigoMuestreoDto>
    {
        public CreateLoteCodigoMuestreoCommand(CreateLoteCodigoMuestreoDto createDto) => CreateDto = createDto;
        public CreateLoteCodigoMuestreoDto CreateDto { get; set; }
    }
}
