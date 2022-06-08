using Paltarumi.Acopio.Domain.Commands.Base;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Transporte
{
    public class DeleteTransporteCommand : CommandBase
    {
        public DeleteTransporteCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
