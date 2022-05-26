using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Application.Abstractions.Balanza
{
    public interface ILoteApplication
    {
        Task<ResponseDto<GetLoteDto>> Create(CreateLoteDto createDto);
        Task<ResponseDto<GetLoteDto>> Update(UpdateLoteDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetLoteDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListLoteDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchLoteDto>>> Search(SearchParamsDto<LoteFilterDto> searchParams);
    }
}
