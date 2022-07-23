using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Config.Empresa;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Config
{
    public interface IEmpresaApplication
    {
        Task<ResponseDto<IEnumerable<SelectComboEmpresaDto>>> SelectCombo();
    }
}
