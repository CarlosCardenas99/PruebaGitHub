using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class UpdateTicketCommand : CommandBase<GetTicketDto>
    {
        public UpdateTicketCommand(UpdateTicketDto updateDto) => UpdateDto = updateDto;
        public UpdateTicketDto UpdateDto { get; set; }
    }
}