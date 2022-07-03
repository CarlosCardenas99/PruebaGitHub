using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateLoteBalanzaCheckListCommand : CommandBase<GetLoteBalanzaCheckListDto>
    {
        public UpdateLoteBalanzaCheckListCommand(UpdateLoteBalanzaCheckListDto updateDto) => UpdateDto = updateDto;
        public UpdateLoteBalanzaCheckListDto UpdateDto { get; set; }
    }
}
