using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteBalanza;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCheckListCommand : CommandBase<GetLoteBalanzaCheckListDto>
    {
        public UpdateLoteBalanzaCheckListCommand(UpdateLoteBalanzaCheckListDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteBalanzaCheckListDto UpdateDto { get; set; }
    }
}
