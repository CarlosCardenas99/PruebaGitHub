using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class DeleteLoteBalanzaCommand : CommandBase
    {
        public DeleteLoteBalanzaCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
