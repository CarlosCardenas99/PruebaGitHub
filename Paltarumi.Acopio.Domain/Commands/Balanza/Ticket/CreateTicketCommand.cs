using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Ticket
{
    public class CreateTicketCommand : CommandBase<GetTicketDto>
    {
        public CreateTicketCommand(CreateTicketDto createDto) => CreateDto = createDto;
        public CreateTicketDto CreateDto { get; set; }
    }
}
