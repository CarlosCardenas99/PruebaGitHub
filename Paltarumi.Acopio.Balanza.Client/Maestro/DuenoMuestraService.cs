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

        public async Task<ResponseDto<GetDuenoMuestraDto>> Insert(CreateDuenoMuestraDto createDto)
            => await Post<CreateDuenoMuestraDto, GetDuenoMuestraDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetDuenoMuestraDto>> Update(UpdateDuenoMuestraDto updateDto)
            => await Put<UpdateDuenoMuestraDto, GetDuenoMuestraDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetDuenoMuestraDto>> Get(int id)
            => await Get<GetDuenoMuestraDto>($"/{id}")!;

        public async Task<ResponseDto<SearchResultDto<SearchDuenoMuestraDto>>> Search(SearchParamsDto<SearchDuenoMuestraFilterDto> filter)
            => await Post<SearchParamsDto<SearchDuenoMuestraFilterDto>, SearchResultDto<SearchDuenoMuestraDto>>("/search", filter)!;

        public async Task<ResponseDto<GetDuenoMuestraDto>> ObtenerDuenoMuestraPorRuc(GetDuenoMuestraByDocumentFilterDto filter)
            => await Post<GetDuenoMuestraByDocumentFilterDto, GetDuenoMuestraDto>("/findbydocument", filter)!;
    }
}
