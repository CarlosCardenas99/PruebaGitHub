using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Maestro
{
    public class DeleteMaestroCommand : CommandBase
    {
        public DeleteMaestroCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
