using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Concesion
{
    public class DeleteConcesionCommand : CommandBase
    {
        public DeleteConcesionCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
