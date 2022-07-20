using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.TicketDoc
{
    public class UpdateTicketDocCommand : CommandBase<GetTicketDocDto>
    {
        public UpdateTicketDocCommand(UpdateTicketDocDto updateDto) => UpdateDto = updateDto;
        public UpdateTicketDocDto UpdateDto { get; set; }
    }
}
