// TO DO : PRUEBA
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteCodigoMuestreo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteCodigoMuestreo
{
    public class UpdateLoteCodigoMuestreoCommand : CommandBase<GetLoteCodigoMuestreoDto>
    {
        public UpdateLoteCodigoMuestreoCommand(UpdateLoteCodigoMuestreoDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteCodigoMuestreoDto UpdateDto { get; set; }
    }
}
