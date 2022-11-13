using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza
{
    public interface ILoteCodigoApplication
    {
        Task<ResponseDto<GetLoteCodigoDto>> Create(CreateLoteCodigoDto createDto);
        Task<ResponseDto<GetLoteCodigoDto>> Update(UpdateLoteCodigoDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetLoteCodigoDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListLoteCodigoDto>>> List(string loteCodigo);
        Task<ResponseDto<SearchResultDto<SearchLoteCodigoDto>>> Search(SearchParamsDto<SearchLoteCodigoFilterDto> searchParams);
    }
}
