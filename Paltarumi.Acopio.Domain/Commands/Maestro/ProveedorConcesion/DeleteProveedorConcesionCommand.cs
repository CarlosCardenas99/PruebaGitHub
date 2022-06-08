using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ProveedorConcesion
{
    public class DeleteProveedorConcesionCommand : CommandBase
    {
        public DeleteProveedorConcesionCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
