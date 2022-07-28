using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class UpdateTicketCodigoCommand : CommandBase<GetTicketDto>
    {
        public UpdateTicketCodigoCommand(UpdateTicketCodigoDto updateDto) => UpdateDto = updateDto;
        public UpdateTicketCodigoDto UpdateDto { get; set; }
    }
}