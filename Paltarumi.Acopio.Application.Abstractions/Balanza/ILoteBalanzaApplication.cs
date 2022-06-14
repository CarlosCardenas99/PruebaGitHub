using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Application.Abstractions.Balanza
{
    public interface ILoteBalanzaApplication
    {
        Task<ResponseDto<GetLoteBalanzaDto>> Create(CreateLoteBalanzaDto createDto);
        Task<ResponseDto<GetLoteBalanzaDto>> Update(UpdateLoteBalanzaDto updateDto);
        Task<ResponseDto<GetLoteBalanzaCheckListDto>> UpdateLoteBalanzaCheckList(UpdateLoteBalanzaCheckListDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetLoteBalanzaDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListLoteBalanzaDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchLoteBalanzaDto>>> Search(SearchParamsDto<SearchLoteBalanzaFilterDto> searchParams);

        Task<ResponseDto<SearchResultDto<SearchLoteBalanzaChecklistDto>>> SearchWithCheckList(SearchParamsDto<SearchLoteBalanzaChecklistFilterDto> searchParams);

        Task<ResponseDto<byte[]>> ExportReport(string reportPath, int id);
    }
}
