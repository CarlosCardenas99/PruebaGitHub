using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Common
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
