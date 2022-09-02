using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteEstado;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Acopio
{
    public interface ILoteEstadoApplication
    {
        Task<ResponseDto<IEnumerable<SelectComboLoteEstadoDto>>> SelectCombo();
    }
}
