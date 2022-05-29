using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;

namespace Paltarumi.Acopio.Application.Abstractions.Balanza
{
    public interface IMaestroApplication
    {
        Task<ResponseDto<GetMaestroDto>> Create(CreateMaestroDto createDto);
        Task<ResponseDto<GetMaestroDto>> Update(UpdateMaestroDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetMaestroDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListMaestroDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchMaestroDto>>> Search(SearchParamsDto<MaestroFilterDto> searchParams);
    }
}
