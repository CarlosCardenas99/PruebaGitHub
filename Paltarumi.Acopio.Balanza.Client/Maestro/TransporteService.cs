using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Transporte;

namespace Paltarumi.Acopio.Balanza.Client.Maestro
{
    public class TransporteService : BaseService
    {
        protected override string ApiController => "api/transporte";

        public TransporteService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetTransporteDto>> Insert(CreateTransporteDto createDto)
            => await Post<CreateTransporteDto, GetTransporteDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetTransporteDto>> Update(UpdateTransporteDto updateDto)
            => await Put<UpdateTransporteDto, GetTransporteDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetTransporteDto>> Get(int id)
            => await Get<GetTransporteDto>($"/{id}")!;

        public async Task<ResponseDto<SearchResultDto<SearchTransporteDto>>> Search(SearchParamsDto<SearchTransporteFilterDto> filter)
            => await Post<SearchParamsDto<SearchTransporteFilterDto>, SearchResultDto<SearchTransporteDto>>("/search", filter)!;

        public async Task<ResponseDto<GetTransporteDto>> ObtenerTransportePorRuc(string ruc)
            => await Get<GetTransporteDto>($"/ruc/{ruc}")!;
    }
}
