using Newtonsoft.Json;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Common
{
    public class CreateCodeRandomCorrelativeCommandHandler : CommandHandlerBase<CreateCodeRandomCorrelativeCommand, string>
    {

        private readonly IRepository<Entity.LoteCodigoControl> _loteCodigoControlRepository;
        private readonly IRepository<Entity.Empresa> _empresaRepository;

        public CreateCodeRandomCorrelativeCommandHandler(
            IUnitOfWork unitOfWork,
            IRepository<Entity.LoteCodigoControl> loteCodigoControlRepository
        ) : base(unitOfWork)
        {
            _loteCodigoControlRepository = loteCodigoControlRepository;
        }

        public override async Task<ResponseDto<string>> HandleCommand(CreateCodeRandomCorrelativeCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<string>();

            var control = await _loteCodigoControlRepository.GetByAsNoTrackingAsync(x =>
                x.Activo == true
            );

            CodigoLoteControlDto controlDto = JsonConvert.DeserializeObject<CodigoLoteControlDto>(control.BloqueCodigo);

            if (correlativo != null)
            {
                correlativo.Numero++;

                var numero =  String.Format("{0}{1}", empresa?.Prefijo, $"{correlativo.Numero}");

                await _correlativoRepository.UpdateAsync(correlativo);
                await _correlativoRepository.SaveAsync();

                response.UpdateData(numero);
            }

            return response;
        }
    }
}
