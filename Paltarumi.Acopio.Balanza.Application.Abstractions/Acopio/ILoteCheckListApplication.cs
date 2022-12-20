using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Acopio
{
    public interface ILoteCheckListApplication
    {
        Task<ResponseDto<GetLoteCheckListDto>> Create(CreateLoteCheckListDto createDto);
        Task<ResponseDto<GetLoteCheckListDto>> Update(UpdateLoteCheckListDto updateDto);
        Task<ResponseDto<GetLoteCheckListDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListLoteCheckListDto>>> List(int idLoteBalanza, string modulo);
    }
}
