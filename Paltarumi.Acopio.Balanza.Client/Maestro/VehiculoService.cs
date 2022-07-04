using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Client.Vehiculo
{
    public class VehiculoService : BaseService
    {
        protected override string ApiController => "api/vehiculo";

        public VehiculoService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetVehiculoDto>> Insert(CreateVehiculoDto createDto)
            => await Post<CreateVehiculoDto, GetVehiculoDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetVehiculoDto>> Update(UpdateVehiculoDto updateDto)
            => await Put<UpdateVehiculoDto, GetVehiculoDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetVehiculoDto>> Get(int id)
            => await Get<GetVehiculoDto>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<GetVehiculoDto>>> List()
            => await Get<IEnumerable<GetVehiculoDto>>($"/list")!;

        public async Task<ResponseDto<SearchResultDto<SearchVehiculoDto>>> Search(SearchParamsDto<SearchVehiculoFilterDto> filter)
            => await Post<SearchParamsDto<SearchVehiculoFilterDto>, SearchResultDto<SearchVehiculoDto>>("/search", filter)!;

        public async Task<ResponseDto<GetVehiculoDto>> GetByPlaca(string placa)
            => await Get<GetVehiculoDto>($"/findbyplaca/{placa}")!;
    }
}
