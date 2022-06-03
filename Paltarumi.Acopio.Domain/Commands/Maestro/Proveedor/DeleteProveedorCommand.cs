using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Proveedor
{
    public class DeleteProveedorCommand : CommandBase
    {
        public DeleteProveedorCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
