using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCheckList
{
    public class CreateLoteCheckListCommand : CommandBase<GetLoteCheckListDto>
    {
        public CreateLoteCheckListCommand(CreateLoteCheckListDto createDto) => CreateDto = createDto;
        public CreateLoteCheckListDto CreateDto { get; set; }
    }
}
