using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza
{
    public interface ILoteBalanzaRalationApplication
    {
        Task<ResponseDto<GetLoteBalanzaRalationDto>> Create(CreateLoteBalanzaRalationDto createDto);
        Task<ResponseDto<GetLoteBalanzaRalationDto>> Update(UpdateLoteBalanzaRalationDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetLoteBalanzaRalationDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListLoteBalanzaRalationDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchLoteBalanzaRalationDto>>> Search(SearchParamsDto<SearchLoteBalanzaRalationFilterDto> searchParams);
    }
}
