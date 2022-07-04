using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.ProveedorConcesion;

namespace Paltarumi.Acopio.Balanza.Client.Maestro
{
    public class ProveedorConcesionService : BaseService
    {
        protected override string ApiController => "api/proveedorconcesion";

        public ProveedorConcesionService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetProveedorConcesionDto>> Insert(CreateProveedorConcesionDto createDto)
            => await Post<CreateProveedorConcesionDto, GetProveedorConcesionDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetProveedorConcesionDto>> Update(UpdateProveedorConcesionDto updateDto)
            => await Put<UpdateProveedorConcesionDto, GetProveedorConcesionDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetProveedorConcesionDto>> Get(int id)
            => await Get<GetProveedorConcesionDto>($"/{id}")!;

        public async Task<ResponseDto<SearchResultDto<SearchProveedorConcesionDto>>> Search(SearchParamsDto<SearchProveedorConcesionFilterDto> filter)
            => await Post<SearchParamsDto<SearchProveedorConcesionFilterDto>, SearchResultDto<SearchProveedorConcesionDto>>("/search", filter)!;

        public async Task<ResponseDto<IEnumerable<ListProveedorConcesionDto>>> ListarProveedorConcesionCombo(int idProveedor)
            => await Get<IEnumerable<ListProveedorConcesionDto>>($"/list/{idProveedor}")!;
    }
}
