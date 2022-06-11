using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LeyReferencial
{
    public class DeleteLeyReferencialCommand : CommandBase
    {
        public DeleteLeyReferencialCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
