using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Client.Maestro
{
    public class ConductorService : BaseService
    {
        protected override string ApiController => "api/conductor";

        public ConductorService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetConductorDto>> Insert(CreateConductorDto createDto)
            => await Post<CreateConductorDto, GetConductorDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetConductorDto>> Update(UpdateConductorDto updateDto)
            => await Put<UpdateConductorDto, GetConductorDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetConductorDto>> Get(int id)
            => await Get<GetConductorDto>($"/{id}")!;

        public async Task<ResponseDto<SearchResultDto<SearchConductorDto>>> Search(SearchParamsDto<SearchConductorFilterDto> filter)
            => await Post<SearchParamsDto<SearchConductorFilterDto>, SearchResultDto<SearchConductorDto>>("/search", filter)!;

        public async Task<ResponseDto<GetConductorDto>> GetByDocument(GetConductorByDocumentFilterDto filter)
            => await Post<GetConductorByDocumentFilterDto, GetConductorDto>("/findbydocument", filter)!;
    }
}
