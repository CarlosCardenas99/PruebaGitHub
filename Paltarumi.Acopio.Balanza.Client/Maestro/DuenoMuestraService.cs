using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Client.Maestro
{
    public class DuenoMuestraService : BaseService
    {
        protected override string ApiController => "api/duenomuestra";

        public DuenoMuestraService(ServiceOptions options) : base(options)
        {

        }

        public Response obtenerDuenoMuestraPorRuc(GetDuenoMuestraByDocumentFilterDto filter)
        {
            var response = EntityPost<GetDuenoMuestraByDocumentFilterDto, ResponseDto<GetDuenoMuestraDto>>("/findbydocument", filter);
            return ResponseData(response);
        }

        public Response get(int id)
        {
            var response = EntityGet<ResponseDto<GetDuenoMuestraDto>>($"/{id}");
            return ResponseNoData(response);
        }

        public Response search(SearchParamsDto<SearchDuenoMuestraFilterDto> filter)
        {
            var response = EntityPost<SearchParamsDto<SearchDuenoMuestraFilterDto>, ResponseDto<SearchResultDto<SearchDuenoMuestraFilterDto>>>("/search", filter);
            return ResponseSearchResult(response);
        }

        public Response insert(CreateDuenoMuestraDto createDto)
        {
            var response = EntityPost<CreateDuenoMuestraDto, ResponseDto<GetDuenoMuestraDto>>(string.Empty, createDto);
            return ResponseData(response);
        }

        public Response update(UpdateDuenoMuestraDto updateDto)
        {
            var response = EntityPost<UpdateDuenoMuestraDto, ResponseDto<GetDuenoMuestraDto>>(string.Empty, updateDto);
            return ResponseData(response);
        }

        public Response delete(int id)
        {
            var response = EntityDelete<ResponseDto>($"/{id}");
            return ResponseNoData(response);
        }
    }
}
