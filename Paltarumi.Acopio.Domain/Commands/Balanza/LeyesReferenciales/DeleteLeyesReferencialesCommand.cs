using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LeyesReferenciales
{
    public class DeleteLeyesReferencialesCommand : CommandBase
    {
        public DeleteLeyesReferencialesCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
