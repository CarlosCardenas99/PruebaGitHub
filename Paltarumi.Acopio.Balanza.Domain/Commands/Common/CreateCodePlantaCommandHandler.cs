using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Common
{
    public class CreateCodePlantaCommandHandler : CommandHandlerBase<CreateCodePlantaCommand, string>
    {
        private readonly IRepository<Entity.LoteCodigoNomenclatura> _loteCodigoNomenclaturaRepository;
    
        public CreateCodePlantaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IRepository<Entity.LoteCodigoNomenclatura> loteCodigoNomenclaturaRepository
        ) : base(unitOfWork, mapper, mediator)
        {
            _loteCodigoNomenclaturaRepository = loteCodigoNomenclaturaRepository;
        }

        public override async Task<ResponseDto<string>> HandleCommand(CreateCodePlantaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<string>();
            string separador = string.Empty;
            var loteCodigoNomenclatura = await _loteCodigoNomenclaturaRepository.GetByAsync(x => x.IdEmpresa == request.IdEmpresa && x.IdLoteCodigoTipo == request.IdLoteCodigoTipo);
            if (!string.IsNullOrEmpty(loteCodigoNomenclatura?.TipoLoteCodigoNomenclatura))
                separador = "-";

            if(request.IdLoteCodigoTipo.Equals(Constants.LoteCodigo.Tipo.MUESTRA_REFERENCIAL))
            {
                var codeResponse = await _mediator?.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.LOTE_REFERENCIAL, "1", request.IdEmpresa))!;
                request.CodigoLote = codeResponse?.Data ?? string.Empty;
            }

            response.UpdateData(String.Format("{0}{1}{2}-{3}", loteCodigoNomenclatura?.TipoLoteCodigoNomenclatura, separador, loteCodigoNomenclatura?.EmpresaNomenclatura, request.CodigoLote));
            
            return response;
        }

    }
}
