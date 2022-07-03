using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.Ticket
{
    public class DeleteTicketCommand : CommandBase
    {
        public DeleteTicketCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}