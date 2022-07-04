using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.TipoDocumento;

namespace Paltarumi.Acopio.Balanza.Client.Maestro
{
    public class TipoDocumentoService : BaseService
    {
        protected override string ApiController => "api/tipodocumento";

        public TipoDocumentoService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<IEnumerable<ListTipoDocumentoDto>>> ListarCombo()
            => await Get<IEnumerable<ListTipoDocumentoDto>>("/list")!;
    }
}
