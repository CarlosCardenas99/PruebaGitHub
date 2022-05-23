using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class DeleteLoteCommand : CommandBase
    {
        public DeleteLoteCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
