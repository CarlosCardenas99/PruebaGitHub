using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Client.Balanza
{
    public class LoteCodigoService : BaseService
    {
        protected override string ApiController => "api/lotecodigo";

        public LoteCodigoService(ServiceOptions options) : base(options)
        {

        }

        public Response obtenerProveedorPorRuc(string ruc)
        {
            var response = EntityGet<ResponseDto<GetProveedorDto>>($"/ruc/{ruc}");
            return ResponseData(response);
        }

        public Response get(int id)
        {
            var response = EntityGet<ResponseDto<GetLoteCodigoDto>>($"/{id}");
            return ResponseNoData(response);
        }

        public Response listarLoteCodigo(SearchParamsDto<SearchLoteCodigoFilterDto> filter)
        {
            var response = EntityPost<SearchParamsDto<SearchLoteCodigoFilterDto>, ResponseDto<SearchResultDto<SearchLoteCodigoDto>>>("/search", filter);
            return ResponseSearchResult(response);
        }

        public Response insert(CreateLoteCodigoDto createDto)
        {
            var response = EntityPost<CreateLoteCodigoDto, ResponseDto<GetLoteCodigoDto>>(string.Empty, createDto);
            return ResponseData(response);
        }

        public Response update(UpdateLoteCodigoDto updateDto)
        {
            var response = EntityPut<UpdateLoteCodigoDto, ResponseDto<GetLoteCodigoDto>>(string.Empty, updateDto);
            return ResponseData(response);
        }

        public Response delete(int id)
        {
            var response = EntityDelete<ResponseDto>($"/{id}");
            return ResponseNoData(response);
        }
    }
}
