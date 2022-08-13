using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCodigoTipo;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Acopio
{
    public interface ILoteCodigoTipoApplication
    {
        Task<ResponseDto<IEnumerable<SelectComboLoteCodigoTipoDto>>> SelectCombo();
    }
}
