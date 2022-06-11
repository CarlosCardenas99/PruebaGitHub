using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Recodificacion
{
    public class DeleteRecodificacionCommand : CommandBase
    {
        public DeleteRecodificacionCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
