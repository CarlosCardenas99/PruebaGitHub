using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Ticket
{
    public class UpdateTicketCommand : CommandBase<GetTicketDto>
    {
        public UpdateTicketCommand(UpdateTicketDto updateDto) => UpdateDto = updateDto;
        public UpdateTicketDto UpdateDto { get; set; }
    }
}