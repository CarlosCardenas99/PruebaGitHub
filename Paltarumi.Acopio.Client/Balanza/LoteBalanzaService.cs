using Paltarumi.Acopio.Client.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Client.Balanza
{
    public class LoteBalanzaService : BaseService
    {
        protected override string ApiController => "api/lotebalanza";

        public LoteBalanzaService(ServiceOptions options) : base(options)
        {

        }

        public Response get(int id)
        {
            var response = EntityGet<ResponseDto<GetLoteBalanzaDto>>($"/{id}");
            return ResponseData(response);
        }

        public Response insert(CreateLoteBalanzaDto entity)
        {
            var response = EntityPost<CreateLoteBalanzaDto, ResponseDto<GetLoteBalanzaDto>>(string.Empty, entity);
            return ResponseData(response);
        }

        public Response update(UpdateLoteBalanzaDto entity)
        {
            var response = EntityPut<UpdateLoteBalanzaDto, ResponseDto<GetLoteBalanzaDto>>(string.Empty, entity);
            return ResponseData(response);
        }

        public Response seleccionarLote(SearchParamsDto<SearchLoteBalanzaFilterDto> filter)
        {
            var response = EntityPost<SearchParamsDto<SearchLoteBalanzaFilterDto>, ResponseDto<SearchResultDto<SearchLoteBalanzaDto>>>("/search", filter);
            return ResponseSearchResult(response);
        }
    }
}
