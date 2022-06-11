using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales;

namespace Paltarumi.Acopio.Application.Abstractions.Balanza
{
    public interface ILeyesReferencialesApplication
    {
        Task<ResponseDto<GetLeyesReferencialesDto>> Create(CreateLeyesReferencialesDto createDto);
        Task<ResponseDto<GetLeyesReferencialesDto>> Update(UpdateLeyesReferencialesDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetLeyesReferencialesDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListLeyesReferencialesDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchLeyesReferencialesDto>>> Search(SearchParamsDto<LeyesReferencialesFilterDto> searchParams);
    }
}
