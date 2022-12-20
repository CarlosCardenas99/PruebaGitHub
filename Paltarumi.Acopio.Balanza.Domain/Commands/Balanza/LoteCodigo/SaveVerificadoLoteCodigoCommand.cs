using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class SaveVerificadoLoteCodigoCommand : CommandBase<GetLoteCodigoDto>
    {
        public SaveVerificadoLoteCodigoCommand(SaveVerificadoLoteCodigoDto saveVerificadoDto) => SaveVerificado = saveVerificadoDto;
        public SaveVerificadoLoteCodigoDto SaveVerificado { get; set; }
    }
}
