using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Conductor
{
    public class DeleteConductorCommand : CommandBase
    {
        public DeleteConductorCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
