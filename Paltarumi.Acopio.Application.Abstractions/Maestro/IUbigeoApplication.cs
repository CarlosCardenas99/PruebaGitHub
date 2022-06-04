using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Ubigeo;

namespace Paltarumi.Acopio.Application.Abstractions.Maestro
{
    public interface IUbigeoApplication
    {
        Task<ResponseDto<GetUbigeoDto>> Get(string id);
        //Task<ResponseDto<IEnumerable<ListUbigeoDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchUbigeoDto>>> Search(SearchParamsDto<UbigeoFilterDto> searchParams);
    }
}
