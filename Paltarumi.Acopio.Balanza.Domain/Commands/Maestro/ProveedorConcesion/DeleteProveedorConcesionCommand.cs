using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.ProveedorConcesion
{
    public class DeleteProveedorConcesionCommand : CommandBase
    {
        public DeleteProveedorConcesionCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
