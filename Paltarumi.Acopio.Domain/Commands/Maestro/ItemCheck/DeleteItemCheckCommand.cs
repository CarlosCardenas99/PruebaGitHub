using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.ItemCheck
{
    public class DeleteItemCheckCommand : CommandBase
    {
        public DeleteItemCheckCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
