using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Vehiculo
{
    public class DeleteVehiculoCommand : CommandBase
    {
        public DeleteVehiculoCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
