using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class CreateOrUpdateLoteOperacionCommandValidator : CommandValidatorBase<CreateOrUpdateLoteOperacionCommand>
    {
        private readonly IRepository<Entities.LoteOperacion> _operacionRepository;
        public CreateOrUpdateLoteOperacionCommandValidator(IRepository<Entities.LoteOperacion> operacionRepository)
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
