using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Common;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Commands.Common;
using Paltarumi.Acopio.Domain.Dto.Balanza.Lote;
using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Lote
{
    public class CreateLoteCommandHandler : CommandHandlerBase<CreateLoteCommand, GetLoteDto>
    {
        private readonly IRepositoryBase<Entity.Lote> _loteRepository;
        private readonly IRepositoryBase<Entity.Vehiculo> _vehiculoRepository;
        private readonly IRepositoryBase<Entity.Transporte> _transporteRepository;
        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;

        public CreateLoteCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteCommandValidator validator,
            IRepositoryBase<Entity.Lote> loteRepository,
            IRepositoryBase<Entity.Vehiculo> vehiculoRepository,
            IRepositoryBase<Entity.Transporte> transporteRepository,
            IRepositoryBase<Entity.Conductor> conductorRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _vehiculoRepository = vehiculoRepository;
            _transporteRepository = transporteRepository;
            _conductorRepository = conductorRepository;
            _loteRepository = loteRepository;
        }

        public override async Task<ResponseDto<GetLoteDto>> HandleCommand(CreateLoteCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteDto>();
            var lote = _mapper?.Map<Entity.Lote>(request.CreateDto) ?? new Entity.Lote();

            var idVehiculos = request.CreateDto?.TicketDetails?.Select(x => x.IdVehiculo) ?? new List<int>();
            var vehiculos = await _vehiculoRepository.FindByAsNoTrackingAsync(x => idVehiculos.Contains(x.IdVehiculo));

            var idTransportistas = request.CreateDto?.TicketDetails?.Select(x => x.IdTransporte) ?? new List<int>();
            var transportistas = await _transporteRepository.FindByAsNoTrackingAsync(x => idTransportistas.Contains(x.IdTransporte));

            var idConductores = request.CreateDto?.TicketDetails?.Select(x => x.IdConductor) ?? new List<int>();
            var conductores = await _conductorRepository.FindByAsNoTrackingAsync(x => idConductores.Contains(x.IdConductor));

            if (lote != null && _mediator != null)
            {
                // Actualizar la serie harcoded
                var codeResponse = await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.LOTE, "1"));
                var code = codeResponse?.Data ?? string.Empty;

                lote.CreateDate = DateTime.Now;
                lote.Codigo = code;
                lote.Tickets =
                    _mapper?.Map<List<Entity.Ticket>>(request.CreateDto?.TicketDetails) ?? new List<Entity.Ticket>();
 
                lote.Activo = true;
                lote.Tickets.ToList().ForEach(async t => { 
                    t.Numero = (await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.TICKET , "1")))?.Data ?? string.Empty;
                    t.Activo = true; 
                    t.CreateDate = DateTime.Now; 
                });

                lote.Vehiculos = string.Join(",", vehiculos.Select(x => x.Placa));
                lote.Transportistas = string.Join(",", transportistas.Select(x => x.RazonSocial));
                lote.Conductores = string.Join(",", conductores.Select(x => x.RazonSocial));

                lote.CantidadSacos = request.CreateDto?.TicketDetails?.Count(x => x.IdUnidadMedida == Constants.Maestro.UnidadMedida.SACOS).ToString() ?? String.Empty;

                lote.FechaIngreso = request.CreateDto?.TicketDetails?.Min(x => x.FechaIngreso) ?? DateTime.Now;
                lote.HoraIngreso = request.CreateDto?.TicketDetails?.Min(x => x.FechaIngreso).ToString("HH:mm") ?? string.Empty;

                lote.FechaAcopio = request.CreateDto?.TicketDetails?.Max(x => x.FechaSalida) ?? DateTime.Now;
                lote.HoraAcopio = request.CreateDto?.TicketDetails?.Max(x => x.FechaSalida)?.ToString("HH:mm") ?? string.Empty;

                lote.Tms = request.CreateDto?.TicketDetails?.Sum(x => x.PesoNeto) ?? 0;
                lote.Tms100 = request.CreateDto?.TicketDetails?.Sum(x => x.PesoNeto100) ?? 0;
                lote.TmsBase = request.CreateDto?.TicketDetails?.Sum(x => x.PesoNetoBase) ?? 0;
                lote.NumeroTickets = string.Join(",", lote.Tickets.Select(x => x.Numero));

                await _loteRepository.AddAsync(lote);
                await _loteRepository.SaveAsync();

                var loteDto = _mapper?.Map<GetLoteDto>(lote);
                if (loteDto != null)
                {
                    //loteDto.TicketDetails =
                    //    _mapper?.Map<List<GetTicketDto>>(lote.Tickets) ?? new List<GetTicketDto>();

                    response.UpdateData(loteDto);
                }

                response.AddOkResult(Resources.Common.CreateSuccessMessage);
            }

            return response;
        }
    }
}
