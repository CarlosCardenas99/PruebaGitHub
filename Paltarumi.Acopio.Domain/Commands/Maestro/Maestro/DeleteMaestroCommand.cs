using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Maestro
{
    public class DeleteMaestroCommand : CommandBase
    {
        public DeleteMaestroCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
