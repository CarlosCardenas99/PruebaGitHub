using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Common;
using Paltarumi.Acopio.Constantes;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Common
{
    public class CreateCodePlantaCommandHandler : CommandHandlerBase<CreateCodePlantaCommand, CreateCodeDto>
    {
        private readonly IRepository<Entities.LoteCodigoNomenclatura> _loteCodigoNomenclaturaRepository;

        public CreateCodePlantaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IRepository<Entities.LoteCodigoNomenclatura> loteCodigoNomenclaturaRepository
        ) : base(unitOfWork, mapper, mediator)
        {
            _loteCodigoNomenclaturaRepository = loteCodigoNomenclaturaRepository;
        }

        public override async Task<ResponseDto<CreateCodeDto>> HandleCommand(CreateCodePlantaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<CreateCodeDto>();
            var createCodeDto = new CreateCodeDto();

            string separador = string.Empty;
            var loteCodigoNomenclatura = await _loteCodigoNomenclaturaRepository.GetByAsync(x => x.IdEmpresa == request.IdEmpresa && x.IdLoteCodigoTipo == request.IdLoteCodigoTipo);

            if (!string.IsNullOrEmpty(loteCodigoNomenclatura?.EmpresaNomenclatura) && !string.IsNullOrEmpty(loteCodigoNomenclatura?.TipoLoteCodigoNomenclatura))
                separador = "-";

            if (request.IdLoteCodigoTipo.Equals(CONST_ACOPIO.LOTECODIGO_TIPO.MUESTRA_REFERENCIAL))
            {
                var codeResponse = await _mediator?.Send(new CreateCodeCommand(CONST_ACOPIO.CODIGOCORRELATIVO_TIPO.LOTE_REFERENCIAL, request.Serie, request.IdEmpresa, request.IdSucursal))!;
                request.CodigoLote = codeResponse?.Data.Numero ?? string.Empty;

                createCodeDto.IdCorrelativo = codeResponse!.Data!.IdCorrelativo;

            }

            createCodeDto.Numero = (String.Format("{0}{1}{2}-{3}", loteCodigoNomenclatura?.TipoLoteCodigoNomenclatura, separador, loteCodigoNomenclatura?.EmpresaNomenclatura, request.CodigoLote));

            response.UpdateData(createCodeDto);

            return response;
        }

    }
}
