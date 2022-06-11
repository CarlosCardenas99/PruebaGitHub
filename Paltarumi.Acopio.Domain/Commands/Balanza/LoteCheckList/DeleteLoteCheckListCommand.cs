using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCheckList
{
    public class DeleteLoteCheckListCommand : CommandBase
    {
        public DeleteLoteCheckListCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
