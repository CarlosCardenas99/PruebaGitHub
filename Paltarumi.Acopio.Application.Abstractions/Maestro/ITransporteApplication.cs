using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Transporte;

namespace Paltarumi.Acopio.Application.Abstractions.Maestro
{
    public interface ITransporteApplication
    {
        Task<ResponseDto<GetTransporteDto>> Create(CreateTransporteDto createDto);
        Task<ResponseDto<GetTransporteDto>> Update(UpdateTransporteDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetTransporteDto>> Get(int id);
        Task<ResponseDto<GetTransporteDto>> Get(string ruc);
        Task<ResponseDto<IEnumerable<ListTransporteDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchTransporteDto>>> Search(SearchParamsDto<SearchTransporteFilterDto> searchParams);
    }
}
