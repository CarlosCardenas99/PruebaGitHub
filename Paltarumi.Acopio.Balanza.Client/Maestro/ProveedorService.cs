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

        public async Task<ResponseDto<GetProveedorDto>> Insert(CreateProveedorDto createDto)
            => await Post<CreateProveedorDto, GetProveedorDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetProveedorDto>> Update(UpdateProveedorDto updateDto)
            => await Put<UpdateProveedorDto, GetProveedorDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetProveedorDto>> Get(int id)
            => await Get<GetProveedorDto>($"/{id}")!;

        public async Task<ResponseDto<SearchResultDto<SearchProveedorDto>>> Search(SearchParamsDto<SearchProveedorFilterDto> filter)
            => await Post<SearchParamsDto<SearchProveedorFilterDto>, SearchResultDto<SearchProveedorDto>>("/search", filter)!;

        public async Task<ResponseDto<GetProveedorDto>> ObtenerProveedorPorRuc(string ruc)
            => await Get<GetProveedorDto>($"/ruc/{ruc}")!;
    }
}
