using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Concesion
{
    public class DeleteConcesionCommand : CommandBase
    {
        public DeleteConcesionCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
