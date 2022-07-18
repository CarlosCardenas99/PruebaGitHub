using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class CreateOrUpdateLoteOperacionCommandValidator : CommandValidatorBase<CreateOrUpdateLoteOperacionCommand>
    {
        private readonly IRepository<Entity.LoteOperacion> _operacionRepository;
        public CreateOrUpdateLoteOperacionCommandValidator(IRepository<Entity.LoteOperacion> operacionRepository)
        {
            _operacionRepository = operacionRepository;

            RequiredInformation(x => x.LoteOperacionDto).DependentRules(() =>
            {
                RequiredField(x => x.LoteOperacionDto.Modulo, Resources.Acopio.LoteOperacion.Modulo);
                RequiredField(x => x.LoteOperacionDto.Operacion, Resources.Acopio.LoteOperacion.Operacion);
                RequiredField(x => x.LoteOperacionDto.CodigoLote, Resources.Acopio.LoteOperacion.CodigoLote);
            });
        }
    }
}
