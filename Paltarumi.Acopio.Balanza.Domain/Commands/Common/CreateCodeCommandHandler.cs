using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Common
{
    public class CreateCodeCommandHandler : CommandHandlerBase<CreateCodeCommand, string>
    {
        private readonly IRepository<Entity.Correlativo> _correlativoRepository;
        private readonly IRepository<Entity.Empresa> _empresaRepository;

        public CreateCodeCommandHandler(
            IUnitOfWork unitOfWork,
            IRepository<Entity.Correlativo> correlativoRepository,
            IRepository<Entity.Empresa> empresaRepository
        ) : base(unitOfWork)
        {
            _correlativoRepository = correlativoRepository;
            _empresaRepository = empresaRepository;
        }

        public override async Task<ResponseDto<string>> HandleCommand(CreateCodeCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<string>();

            var empresa = await _empresaRepository.GetByAsNoTrackingAsync(x =>
                x.IdEmpresa == request.IdEmpresa
            );

            var correlativo = await _correlativoRepository.GetByAsync(x =>
                x.CodigoCorrelativoTipo == request.CodigoCorrelativoTipo && x.Serie == request.Serie && x.IdEmpresa == request.IdEmpresa
            );

            if (correlativo != null)
            {
                correlativo.Numero++;

                var numero =  string.Format("{0}{1}", empresa?.Prefijo, $"{correlativo.Numero}");

                await _correlativoRepository.UpdateAsync(correlativo);
                await _correlativoRepository.SaveAsync();

                response.UpdateData(numero);
            }

            return response;
        }
    }
}
