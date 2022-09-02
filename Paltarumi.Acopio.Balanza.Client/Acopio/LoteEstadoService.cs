using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteEstado;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Client.Acopio
{
    public class LoteEstadoService : BaseService
    {
        protected override string ApiController => "api/LoteEstado";

        public LoteEstadoService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<IEnumerable<SelectComboLoteEstadoDto>>> SelectCombo()
            => await Get<IEnumerable<SelectComboLoteEstadoDto>>("/selectcombo")!;
    }
}
