using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCodigoTipo;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Client.Acopio
{
    public class LoteCodigoTipoService : BaseService
    {
        protected override string ApiController => "api/LoteCodigoTipo";

        public LoteCodigoTipoService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<IEnumerable<SelectComboLoteCodigoTipoDto>>> SelectCombo()
            => await Get<IEnumerable<SelectComboLoteCodigoTipoDto>>("/selectcombo")!;
    }
}
