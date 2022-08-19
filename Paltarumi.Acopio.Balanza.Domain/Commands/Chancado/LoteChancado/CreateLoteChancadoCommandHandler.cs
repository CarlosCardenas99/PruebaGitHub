using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.Mapa;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Dto.Chancado.Mapa;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado
{
    public class CreateLoteChancadoCommandHandler : CommandHandlerBase<CreateLoteChancadoCommand, GetLoteChancadoDto>
    {
        private readonly IRepository<Entity.Ticket> _ticketRepository;
        private readonly IRepository<Entity.LoteChancado> _lotechancadoRepository;

        public CreateLoteChancadoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteChancadoCommandValidator validator,
            IRepository<Entity.Ticket> ticketRepository,
            IRepository<Entity.LoteChancado> lotechancadoRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _ticketRepository = ticketRepository;
            _lotechancadoRepository = lotechancadoRepository;
        }

        public override async Task<ResponseDto<GetLoteChancadoDto>> HandleCommand(CreateLoteChancadoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteChancadoDto>();

            var loteChancado = _mapper?.Map<Entity.LoteChancado>(request.CreateDto);
            if (loteChancado == null)
            {
                response.AddErrorResult(Resources.Chancado.LoteChancado.LoteChancadoRequired);
                return response;
            }

            var ticket = await _ticketRepository.GetByAsync(
                x => x.IdLoteBalanza == request.CreateDto.IdLoteBalanza,
                x => x.IdVehiculoNavigation
            );

            loteChancado.Placa = ticket?.IdVehiculoNavigation?.Placa ?? string.Empty;
            loteChancado.PlacaCarreta = ticket?.IdVehiculoNavigation?.PlacaCarreta ?? string.Empty;

            await _lotechancadoRepository.AddAsync(loteChancado);
            await _lotechancadoRepository.SaveAsync();

            var createMapaDto = new CreateMapaDto { IdLoteChancado = loteChancado.IdLoteChancado };
            var createMapaResponse = await _mediator?.Send(new CreateMapaCommand(createMapaDto), cancellationToken)!;

            if (createMapaResponse?.IsValid == false)
            {
                response.AttachResults(createMapaResponse);
                return response;
            }

            var lotechancadoDto = _mapper?.Map<GetLoteChancadoDto>(loteChancado);
            if (lotechancadoDto != null) response.UpdateData(lotechancadoDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
