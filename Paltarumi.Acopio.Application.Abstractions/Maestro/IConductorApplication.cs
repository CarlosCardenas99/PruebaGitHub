using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;

namespace Paltarumi.Acopio.Application.Abstractions.Maestro
{
    public interface IConductorApplication
    {
        Task<ResponseDto<GetConductorDto>> Create(CreateConductorDto createDto);
        Task<ResponseDto<GetConductorDto>> Update(UpdateConductorDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetConductorDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListConductorDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchConductorDto>>> Search(SearchParamsDto<ConductorFilterDto> searchParams);
    }
}
