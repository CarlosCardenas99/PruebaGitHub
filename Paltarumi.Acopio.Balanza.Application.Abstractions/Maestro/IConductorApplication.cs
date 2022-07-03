using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Maestro
{
    public interface IConductorApplication
    {
        Task<ResponseDto<GetConductorDto>> Create(CreateConductorDto createDto);
        Task<ResponseDto<GetConductorDto>> Update(UpdateConductorDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetConductorDto>> Get(int id);
        Task<ResponseDto<GetConductorDto>> Get(string dni);
        Task<ResponseDto<IEnumerable<ListConductorDto>>> List();
        Task<ResponseDto<GetConductorDto>> GetByDocument(GetConductorByDocumentFilterDto filter);
        Task<ResponseDto<SearchResultDto<SearchConductorDto>>> Search(SearchParamsDto<SearchConductorFilterDto> searchParams);
    }
}
