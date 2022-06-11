using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCodigo
{
    public class DeleteLoteCodigoCommand : CommandBase
    {
        public DeleteLoteCodigoCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
