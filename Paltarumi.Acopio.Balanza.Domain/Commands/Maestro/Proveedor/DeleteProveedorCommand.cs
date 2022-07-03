using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Proveedor
{
    public class DeleteProveedorCommand : CommandBase
    {
        public DeleteProveedorCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
