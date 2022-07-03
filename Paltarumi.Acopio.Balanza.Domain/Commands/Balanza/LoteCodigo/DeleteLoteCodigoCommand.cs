using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class DeleteLoteCodigoCommand : CommandBase
    {
        public DeleteLoteCodigoCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
