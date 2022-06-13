using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteBalanza
{
    public class DeleteLoteBalanzaCommand : CommandBase
    {
        public DeleteLoteBalanzaCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
