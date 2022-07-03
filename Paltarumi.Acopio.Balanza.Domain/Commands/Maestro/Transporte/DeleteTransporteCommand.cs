using Paltarumi.Acopio.Balanza.Domain.Commands.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Transporte
{
    public class DeleteTransporteCommand : CommandBase
    {
        public DeleteTransporteCommand(int id) => Id = id;
        public int Id { get; set; }
    }
}
