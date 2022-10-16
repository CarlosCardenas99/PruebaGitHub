using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Common;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class CreateLoteCodigoCommandHandler : CommandHandlerBase<CreateLoteCodigoCommand, GetLoteCodigoDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.Lote> _loteRepository;
        private readonly IRepository<Entity.LoteCodigo> _lotecodigoRepository;

        public CreateLoteCodigoCommandHandler(
            IUnitOfWork unitOfWork,
            IMediator mediator,
            IMapper mapper,
            CreateLoteCodigoCommandValidator validator,
            IRepository<Entity.Lote> loteRepository,
            IRepository<Entity.LoteCodigo> lotecodigoRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteRepository = loteRepository;
            _lotecodigoRepository = lotecodigoRepository;
        }

        public override async Task<ResponseDto<GetLoteCodigoDto>> HandleCommand(CreateLoteCodigoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteCodigoDto>();
            var lotecodigo = _mapper?.Map<Entity.LoteCodigo>(request.CreateDto);

            if (lotecodigo != null)
            {
                lotecodigo.Activo = true;

                lotecodigo.IdLoteCodigoEstado = Constants.Maestro.LoteCodigoEstado.PENDIENTE;

                string codigoLote = string.Empty;
                if(request.CreateDto.IdLote != null)
                {
                    var lote = await _loteRepository.GetByAsNoTrackingAsync(x => x.IdLote == request.CreateDto.IdLote);
                    codigoLote = lote.CodigoLote;
                }

                lotecodigo.CodigoPlantaRandom = (await _mediator.Send(new CreateCodeRandomCorrelativeCommand()))?.Data ?? string.Empty;
                lotecodigo.CodigoPlanta = (await _mediator.Send(new CreateCodePlantaCommand(Constants.Empresa.PALTARUMI, codigoLote, request.CreateDto.IdLoteCodigoTipo, request.CreateDto.IdSucursal, request.CreateDto.Serie)))?.Data ?? string.Empty;

                await _lotecodigoRepository.AddAsync(lotecodigo);
                await _lotecodigoRepository.SaveAsync();
            }

            var lotecodigoDto = _mapper?.Map<GetLoteCodigoDto>(lotecodigo);
            if (lotecodigoDto != null) response.UpdateData(lotecodigoDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
