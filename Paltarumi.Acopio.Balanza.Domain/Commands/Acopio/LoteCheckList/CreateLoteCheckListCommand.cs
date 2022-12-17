using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteCheckList
{
    public class CreateLoteCheckListCommand : CommandBase<GetLoteCheckListDto>
    {
        public CreateLoteCheckListCommand(CreateLoteCheckListDto createDto) => CreateDto = createDto;
        public CreateLoteCheckListDto CreateDto { get; set; }
    }
}
