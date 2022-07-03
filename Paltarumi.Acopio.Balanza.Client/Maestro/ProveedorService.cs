using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Proveedor;

namespace Paltarumi.Acopio.Balanza.Client.Maestro
{
    public class ProveedorService : BaseService
    {
        protected override string ApiController => "api/proveedor";

        public ProveedorService(ServiceOptions options) : base(options)
        {

        }

        public Response obtenerProveedorPorRuc(string ruc)
        {
            var response = EntityGet<ResponseDto<GetProveedorDto>>($"/ruc/{ruc}");
            return ResponseData(response);
        }

        public Response get(int id)
        {
            ResponseDto response = EntityGet<ResponseDto<GetProveedorDto>>($"/{id}");
            return ResponseNoData(response);
        }

        public Response search(SearchParamsDto<SearchProveedorFilterDto> filter)
        {
            var response = EntityPost<SearchParamsDto<SearchProveedorFilterDto>, ResponseDto<SearchResultDto<SearchProveedorDto>>>("/search", filter);
            return ResponseSearchResult(response);
        }

        public Response insert(CreateProveedorDto createDto)
        {
            var response = EntityPost<CreateProveedorDto, ResponseDto<GetProveedorDto>>(string.Empty, createDto);
            return ResponseData(response);
        }

        public Response update(UpdateProveedorDto updateDto)
        {
            var response = EntityPost<UpdateProveedorDto, ResponseDto<GetProveedorDto>>(string.Empty, updateDto);
            return ResponseData(response);
        }

        public Response delete(int id)
        {
            var response = EntityDelete<ResponseDto>($"/{id}");
            return ResponseNoData(response);
        }
    }
}
