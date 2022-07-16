using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class CreateTicketCommand : CommandBase<GetTicketDto>
    {
        public CreateTicketCommand(CreateTicketDto createDto) => CreateDto = createDto;
        public CreateTicketDto CreateDto { get; set; }
    }
}
