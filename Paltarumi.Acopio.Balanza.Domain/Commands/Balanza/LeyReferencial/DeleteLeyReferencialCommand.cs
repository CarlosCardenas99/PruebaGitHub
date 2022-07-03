using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LeyReferencial
{
    public class DeleteLeyReferencialCommand : CommandBase
    {
        public DeleteLeyReferencialCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
