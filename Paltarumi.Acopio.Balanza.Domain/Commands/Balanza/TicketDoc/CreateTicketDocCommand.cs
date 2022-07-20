using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.TicketDoc
{
    public class CreateTicketDocCommand : CommandBase<GetTicketDocDto>
    {
        public CreateTicketDocCommand(CreateTicketDocDto createDto) => CreateDto = createDto;
        public CreateTicketDocDto CreateDto { get; set; }
    }
}
