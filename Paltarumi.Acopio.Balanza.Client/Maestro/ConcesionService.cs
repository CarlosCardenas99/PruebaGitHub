using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Concesion;

namespace Paltarumi.Acopio.Balanza.Client.Maestro
{
    public class ConcesionService : BaseService
    {
        protected override string ApiController => "api/concesion";

        public ConcesionService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetConcesionDto>> Insert(CreateConcesionDto createDto)
            => await Post<CreateConcesionDto, GetConcesionDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetConcesionDto>> Update(UpdateConcesionDto updateDto)
            => await Put<UpdateConcesionDto, GetConcesionDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetConcesionDto>> Get(int id)
            => await Get<GetConcesionDto>($"/{id}")!;

        public async Task<ResponseDto<SearchResultDto<SearchConcesionDto>>> Search(SearchParamsDto<SearchConcesionFilterDto> filter)
            => await Post<SearchParamsDto<SearchConcesionFilterDto>, SearchResultDto<SearchConcesionDto>>("/search", filter)!;

        public async Task<ResponseDto<SearchResultDto<SearchConcesionDto>>> Select(SearchParamsDto<SearchConcesionFilterDto> filter)
            => await Post<SearchParamsDto<SearchConcesionFilterDto>, SearchResultDto<SearchConcesionDto>>("/select", filter)!;
    }
}
