using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.ItemCheck
{
    public class DeleteItemCheckCommand : CommandBase
    {
        public DeleteItemCheckCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
