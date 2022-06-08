using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Common;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Commands.Common;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Entity.Extensions;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class CreateLoteCommandHandler : CommandHandlerBase<CreateLoteCommand, GetLoteDto>
    {
        private readonly IRepositoryBase<Entity.Lote> _loteRepository;
        private readonly IRepositoryBase<Entity.Maestro> _maestroRepository;
        private readonly IRepositoryBase<Entity.Vehiculo> _vehiculoRepository;
        private readonly IRepositoryBase<Entity.Transporte> _transporteRepository;
        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;

        public CreateLoteCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteCommandValidator validator,
            IRepositoryBase<Entity.Lote> loteRepository,
            IRepositoryBase<Entity.Maestro> maestroRepository,
            IRepositoryBase<Entity.Vehiculo> vehiculoRepository,
            IRepositoryBase<Entity.Transporte> transporteRepository,
            IRepositoryBase<Entity.Conductor> conductorRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteRepository = loteRepository;
            _maestroRepository = maestroRepository;
            _vehiculoRepository = vehiculoRepository;
            _transporteRepository = transporteRepository;
            _conductorRepository = conductorRepository;
        }

        public override async Task<ResponseDto<GetLoteDto>> HandleCommand(CreateLoteCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteDto>();

            var lote = _mapper?.Map<Entity.Lote>(request.CreateDto) ?? new Entity.Lote();
            var ticketDetails = request.CreateDto?.TicketDetails;

            var idVehiculos = ticketDetails?.Select(x => x.IdVehiculo) ?? new List<int>();
            var vehiculos = await _vehiculoRepository.FindByAsNoTrackingAsync(x => idVehiculos.Contains(x.IdVehiculo));

            var idTransportistas = ticketDetails?.Select(x => x.IdTransporte) ?? new List<int>();
            var transportistas = await _transporteRepository.FindByAsNoTrackingAsync(x => idTransportistas.Contains(x.IdTransporte));

            var idConductores = ticketDetails?.Select(x => x.IdConductor) ?? new List<int>();
            var conductores = await _conductorRepository.FindByAsNoTrackingAsync(x => idConductores.Contains(x.IdConductor));

            if (lote != null && _mediator != null)
            {
                // Actualizar la serie harcoded
                var codeResponse = await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.LOTE, "1"));
                var code = codeResponse?.Data ?? string.Empty;

                lote.Codigo = code;

                lote.Tickets = _mapper?.Map<List<Entity.Ticket>>(ticketDetails) ?? new List<Entity.Ticket>();

                foreach(var ticket in lote.Tickets)
                {
                    ticket.Numero = (await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.TICKET, "1")))?.Data ?? string.Empty;
                    ticket.Activo = true;
                }

                var estadoLote = await _maestroRepository.GetByAsNoTrackingAsync(x =>
                    x.CodigoTabla == Constants.Maestro.CodigoTabla.ESTADO_LOTE && 
                    x.CodigoItem == Constants.Maestro.EstadoLote.EN_ESPERA
                 );

                lote.Enable();
                lote.UpdateCreation();
                lote.UpdateVehiculos(vehiculos);
                lote.UpdateTransportistas(transportistas);
                lote.UpdateConductores(conductores);
                lote.UpdateCantidadSacos();
                lote.UpdateFechaIngreso();
                lote.UpdateHoraIngreso();
                lote.UpdateFechaAcopio();
                lote.UpdateHoraAcopio();
                lote.UpdateTms();
                lote.UpdateTms100();
                lote.UpdateTmsBase();
                lote.UpdateNumeroTickets();
                lote.IdEstado = estadoLote.IdMaestro;

                await _loteRepository.AddAsync(lote);
                await _loteRepository.SaveAsync();

                var loteDto = _mapper?.Map<GetLoteDto>(lote);

                if (loteDto != null)
                {
                    loteDto.TicketDetails = _mapper?.Map<List<ListTicketDto>>(lote.Tickets) ?? new List<ListTicketDto>();

                    response.UpdateData(loteDto);
                }

                response.AddOkResult(Resources.Common.CreateSuccessMessage);
            }

            return response;
        }
    }
}
