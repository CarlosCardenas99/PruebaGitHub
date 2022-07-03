using Paltarumi.Acopio.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Concesion;

namespace Paltarumi.Acopio.Client.Maestro
{
    public class ConcesionService : BaseService
    {
        protected override string ApiController => "api/concesion";

        public Response get(int id)
        {
            var response = EntityGet<ResponseDto<GetConcesionDto>>($"/{id}");
            return ResponseNoData(response);
        }

        public Response search(SearchParamsDto<SearchConcesionFilterDto> filter)
        {
            var response = EntityPost<SearchParamsDto<SearchConcesionFilterDto>, ResponseDto<SearchResultDto<SearchConcesionDto>>>("/search", filter);
            return ResponseSearchResult(response);
        }

        public Response insert(CreateConcesionDto createDto)
        {
            var response = EntityPost<CreateConcesionDto, ResponseDto<GetConcesionDto>>(string.Empty, createDto);
            return ResponseData(response);
        }

        public Response update(UpdateConcesionDto updateDto)
        {
            var response = EntityPost<UpdateConcesionDto, ResponseDto<GetConcesionDto>>(string.Empty, updateDto);
            return ResponseData(response);
        }

        public Response delete(int id)
        {
            var response = EntityDelete<ResponseDto>($"/{id}");
            return ResponseNoData(response);
        }

        public Response select(SearchParamsDto<SearchConcesionFilterDto> filter)
        {
            var response = EntityPost<SearchParamsDto<SearchConcesionFilterDto>, ResponseDto<SearchResultDto<SearchConcesionDto>>>("/select", filter);
            return ResponseSearchResult(response);
        }
    }
}
