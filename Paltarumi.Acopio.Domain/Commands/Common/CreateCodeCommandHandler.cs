﻿using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Common
{
    public class CreateCodeCommandHandler : CommandHandlerBase<CreateCodeCommand, string>
    {
        private readonly IRepositoryBase<Entity.Correlativo> _correlativoRepository;

        public CreateCodeCommandHandler(
            IUnitOfWork unitOfWork,
            IRepositoryBase<Entity.Correlativo> correlativoRepository
        ) : base(unitOfWork)
        {
            _correlativoRepository = correlativoRepository;
        }

        public override async Task<ResponseDto<string>> HandleCommand(CreateCodeCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<string>();

            var correlativo = await _correlativoRepository.GetByAsNoTrackingAsync(x =>
                x.CodigoCorrelativoTipo == request.CodigoCorrelativoTipo && x.Serie == request.Serie
            );

            if (correlativo != null)
            {
                correlativo.Numero++;

                var numero = $"{correlativo.Numero}";

                await _correlativoRepository.UpdateAsync(correlativo);

                response.UpdateData(numero);
            }

            return response;
        }
    }
}
