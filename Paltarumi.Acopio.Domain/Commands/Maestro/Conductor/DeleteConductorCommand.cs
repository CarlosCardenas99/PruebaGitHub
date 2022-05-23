using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Conductor
{
    public class DeleteConductorCommand : CommandBase
    {
        public DeleteConductorCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
