using Paltarumi.Acopio.Balanza.Client.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Client.Acopio
{
    public class LoteCheckListService : BaseService
    {
        protected override string ApiController => "api/LoteCheckList";

        public LoteCheckListService(ServiceOptions options) : base(options)
        {

        }

        public async Task<ResponseDto<GetLoteCheckListDto>> Insert(CreateLoteCheckListDto createDto)
            => await Post<CreateLoteCheckListDto, GetLoteCheckListDto>(string.Empty, createDto)!;

        public async Task<ResponseDto<GetLoteCheckListDto>> Update(UpdateLoteCheckListDto updateDto)
            => await Put<UpdateLoteCheckListDto, GetLoteCheckListDto>(string.Empty, updateDto)!;

        public async Task<ResponseDto<GetLoteCheckListDto>> Get(int id)
            => await Get<GetLoteCheckListDto>($"/{id}")!;

        public async Task<ResponseDto<IEnumerable<ListLoteCheckListDto>>> List(int idLoteBalanza)
            => await Get<IEnumerable<ListLoteCheckListDto>>($"/list/{idLoteBalanza}")!;
    }
}
