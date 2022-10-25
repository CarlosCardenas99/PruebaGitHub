using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Common;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Common
{
    public class CreateCodeCommandHandler : CommandHandlerBase<CreateCodeCommand, CreateCodeDto>
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

        public override async Task<ResponseDto<CreateCodeDto>> HandleCommand(CreateCodeCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<CreateCodeDto>();
            var createCodeDto = new CreateCodeDto();

            var empresa = await _empresaRepository.GetByAsNoTrackingAsync(x =>
                x.IdEmpresa == request.IdEmpresa
            );

            var correlativo = new Entity.Correlativo();

            if(string.IsNullOrEmpty(request.Serie))
                correlativo = await _correlativoRepository.GetByAsync(x =>
                    x.CodigoCorrelativoTipo == request.CodigoCorrelativoTipo && x.IdEmpresa == request.IdEmpresa && x.IdSucursal == request.IdSucursal
                );
            else
                correlativo = await _correlativoRepository.GetByAsync(x =>
                    x.CodigoCorrelativoTipo == request.CodigoCorrelativoTipo && x.IdEmpresa == request.IdEmpresa && x.IdSucursal == request.IdSucursal && x.Serie == request.Serie
                );

            if (correlativo != null)
            {
                correlativo.Numero++;

                var numero =  string.Format("{0}-{1}{2}", correlativo.Serie, empresa?.Prefijo, $"{correlativo.Numero}");

                await _correlativoRepository.UpdateAsync(correlativo);
                await _correlativoRepository.SaveAsync();

                createCodeDto.Numero = numero;
                createCodeDto.IdCorrelativo = correlativo.IdCorrelativo;

                response.UpdateData(createCodeDto);
            }

            return response;
        }
    }
}
