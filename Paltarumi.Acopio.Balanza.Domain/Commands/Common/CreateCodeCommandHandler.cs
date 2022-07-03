using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Common
{
    public class CreateCodeCommandHandler : CommandHandlerBase<CreateCodeCommand, string>
    {

        private readonly IRepository<Entity.Correlativo> _correlativoRepository;

        public CreateCodeCommandHandler(
            IUnitOfWork unitOfWork,
            IRepository<Entity.Correlativo> correlativoRepository
        ) : base(unitOfWork)
        {
            _correlativoRepository = correlativoRepository;
        }

        public override async Task<ResponseDto<string>> HandleCommand(CreateCodeCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<string>();

            var correlativo = await _correlativoRepository.GetByAsync(x =>
                x.CodigoCorrelativoTipo == request.CodigoCorrelativoTipo && x.Serie == request.Serie
            );

            if (correlativo != null)
            {
                correlativo.Numero++;

                var numero = $"{correlativo.Numero}";

                await _correlativoRepository.UpdateAsync(correlativo);
                await _correlativoRepository.SaveAsync();

                response.UpdateData(numero);
            }

            return response;
        }
    }
}
