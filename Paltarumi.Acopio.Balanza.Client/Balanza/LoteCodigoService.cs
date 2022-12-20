using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Client.Balanza
{
    public class LoteCodigoService : BaseService
    {
        protected override string ApiController => "api/lotecodigo";

        public LoteCodigoService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetLoteCodigoDto>> Insert(CreateLoteCodigoDto createDto)
            => await Post<CreateLoteCodigoDto, GetLoteCodigoDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetLoteCodigoDto>> SaveVerificado(SaveVerificadoLoteCodigoDto createDto)
            => await Post<SaveVerificadoLoteCodigoDto, GetLoteCodigoDto>("/verificar", createDto)!;

        public async Task<ResponseDto<GetLoteCodigoDto>> Update(UpdateLoteCodigoDto updateDto)
            => await Put<UpdateLoteCodigoDto, GetLoteCodigoDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto> Delete(int id)
            => await Delete($"/{id}")!;

        public async Task<ResponseDto<GetLoteCodigoDto>> Get(int id)
            => await Get<GetLoteCodigoDto>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListLoteCodigoDto>>> List(string loteCodigo)
           => await Get<IEnumerable<ListLoteCodigoDto>>($"/list/{loteCodigo}")!;


        public async Task<ResponseDto<SearchResultDto<SearchLoteCodigoDto>>> Search(SearchParamsDto<SearchLoteCodigoFilterDto> filter)
            => await Post<SearchParamsDto<SearchLoteCodigoFilterDto>, SearchResultDto<SearchLoteCodigoDto>>("/search", filter)!;

        //public async Task<ResponseDto<GetProveedorDto>> ObtenerProveedorPorRuc(string ruc)
        //    => await Get<GetProveedorDto>($"/ruc/{ruc}")!;
    }
}
