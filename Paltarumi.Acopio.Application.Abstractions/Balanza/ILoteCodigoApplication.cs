using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo;

namespace Paltarumi.Acopio.Application.Abstractions.Balanza
{
    public interface ILoteCodigoApplication
    {
        Task<ResponseDto<GetLoteCodigoDto>> Create(CreateLoteCodigoDto createDto);
        Task<ResponseDto<GetLoteCodigoDto>> Update(UpdateLoteCodigoDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetLoteCodigoDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListLoteCodigoDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchLoteCodigoDto>>> Search(SearchParamsDto<LoteCodigoFilterDto> searchParams);
    }
}
