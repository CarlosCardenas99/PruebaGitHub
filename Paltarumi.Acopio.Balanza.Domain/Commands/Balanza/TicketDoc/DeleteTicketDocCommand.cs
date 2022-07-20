using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.TicketDoc
{
    public class DeleteTicketDocCommand : CommandBase
    {
        public DeleteTicketDocCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
