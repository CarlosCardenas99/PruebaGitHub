using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Lote;
using Paltarumi.Acopio.Constantes;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.Lote
{
    public class CreateLoteCommandHandler : CommandHandlerBase<CreateLoteCommand, GetLoteDto>
    {
        private readonly IRepository<Entities.Lote> _loteRepository;
        private readonly IRepository<Entities.Maestro> _maestroRepository;
        public CreateLoteCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteCommandValidator validator,
            IRepository<Entities.Lote> loteRepository,
            IRepository<Entities.Maestro> maestroRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteRepository = loteRepository;
            _maestroRepository = maestroRepository;
        }

        public override async Task<ResponseDto<GetLoteDto>> HandleCommand(CreateLoteCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteDto>();

            var lote = _mapper?.Map<Entities.Lote>(request.CreateDto)!;
            if (lote == null)
            {
                response.AddErrorResult(Resources.Acopio.Lote.LoteRequired);
                return response;
            }

            var estado = await _maestroRepository.GetByAsNoTrackingAsync(x =>
                x.CodigoTabla.Equals(CONST_MAESTRO.CODIGO_TABLA.LOTE_ESTADO) &&
                x.CodigoItem.Equals(CONST_MAESTRO.LOTE_ESTADO.PENDIENTE)
            );

            if (estado == null)
            {
                response.AddErrorResult(Resources.Acopio.Lote.EstadoNotFound);
                return response;
            }

            lote.IdEstado = estado.IdMaestro;

            await _loteRepository.AddAsync(lote);
            await _loteRepository.SaveAsync();

            var loteDto = _mapper?.Map<GetLoteDto>(lote);
            if (loteDto != null) response.UpdateData(loteDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
