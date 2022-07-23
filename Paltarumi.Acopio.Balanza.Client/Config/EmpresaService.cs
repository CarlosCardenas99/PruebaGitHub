using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Balanza.Dto.Config.Empresa;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Client.Config
{
    public class EmpresaService : BaseService
    {
        protected override string ApiController => "api/Empresa";

        public EmpresaService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<IEnumerable<SelectComboEmpresaDto>>> SelectCombo()
            => await Get<IEnumerable<SelectComboEmpresaDto>>($"/selectcombo")!;
    }
}
