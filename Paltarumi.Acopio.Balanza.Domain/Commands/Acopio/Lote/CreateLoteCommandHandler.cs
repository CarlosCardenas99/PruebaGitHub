using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Lote;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.Lote
{
    public class CreateLoteCommandHandler : CommandHandlerBase<CreateLoteCommand, GetLoteDto>
    {
        private readonly IRepository<Entity.Lote> _loteRepository;
        private readonly IRepository<Entity.Maestro> _maestroRepository;
        private readonly IRepository<Entity.Operacion> _operacionRepository;

        public CreateLoteCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteCommandValidator validator,
            IRepository<Entity.Lote> loteRepository,
            IRepository<Entity.Maestro> maestroRepository,
            IRepository<Entity.Operacion> operacionRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteRepository = loteRepository;
            _maestroRepository = maestroRepository;
            _operacionRepository = operacionRepository;
        }

        public override async Task<ResponseDto<GetLoteDto>> HandleCommand(CreateLoteCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteDto>();

            var lote = _mapper?.Map<Entity.Lote>(request.CreateDto)!;
            if (lote == null)
            {
                response.AddErrorResult(Resources.Acopio.Lote.LoteRequired);
                return response;
            }

            var estado = await _maestroRepository.GetByAsNoTrackingAsync(x =>
                x.CodigoTabla.Equals(Constants.Maestro.CodigoTabla.LOTE_ESTADO) &&
                x.CodigoItem.Equals(Constants.Maestro.LoteEstado.EN_ESPERA)
            );
            if (estado == null)
            {
                response.AddErrorResult(Resources.Acopio.Lote.EstadoNotFound);
                return response;
            }

            var loteOperaciones = new List<Entity.LoteOperacion>();
            var operaciones = await _operacionRepository.FindByAsNoTrackingAsync(x =>
                x.Codigo.Equals(Constants.Operaciones.Operacion.CREATE)
            );

            foreach (var operacion in operaciones)
            {
                loteOperaciones.Add(new Entity.LoteOperacion
                {
                    IdOperacionNavigation = null!,
                    IdOperacion = operacion.IdOperacion,
                    Status = Constants.Operaciones.Status.PENDING,
                    Attempts = 0,
                    Body = string.Empty,
                    Message = string.Empty
                });
            }

            lote.IdEstado = estado.IdMaestro;
            lote.LoteOperacions = loteOperaciones;

            await _loteRepository.AddAsync(lote);
            await _loteRepository.SaveAsync();

            var createLoteOperacionDto = new CreateLoteOperacionDto { IdLote = lote.IdLote };
            var createLoteOperacionResponse = await _mediator?.Send(new CreateLoteOperacionCommand(createLoteOperacionDto), cancellationToken)!;

            if (createLoteOperacionResponse?.IsValid == false)
            {
                response.AttachResults(createLoteOperacionResponse);
                return response;
            }

            var loteDto = _mapper?.Map<GetLoteDto>(lote);
            if (loteDto != null) response.UpdateData(loteDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
