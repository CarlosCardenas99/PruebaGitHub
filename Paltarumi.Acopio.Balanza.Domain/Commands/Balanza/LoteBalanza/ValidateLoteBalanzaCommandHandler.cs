using AutoMapper;
using MediatR;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Domain.Queries.Sunat;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Paltarumi.DataType.Extension;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class ValidateLoteBalanzaCommandHandler : CommandHandlerBase<ValidateLoteBalanzaCommand>
    {
        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;

        public ValidateLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IRepository<Entities.LoteBalanza> loteBalanzaRepository
        ) : base(unitOfWork, mapper, mediator)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
        }

        public override async Task<ResponseDto> HandleCommand(ValidateLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            if (request.ValidateDto.CreateDto != null)
            {
                await validarPlacaCreateDto(request.ValidateDto.CreateDto, response);
            }
            if(request.ValidateDto.UpdateDto != null)
            {
                await validarPlacaUpdateDto(request.ValidateDto.UpdateDto, response);
            }

            return response;
        }

        private async Task validarPlacaUpdateDto(UpdateLoteBalanzaDto updateDto, ResponseDto response)
        {
            var idVehiculos = updateDto.TicketDetails!.Where(x => x.Activo == true).Select(x => x.IdVehiculo).ToList();
            var loteBalanza = await _loteBalanzaRepository.GetByAsNoTrackingAsync(x => x.IdLoteBalanza == updateDto.IdLoteBalanza);

            var dateHasta = getDate(loteBalanza!.CreateDate.DateTime);
            var dateDesde = dateHasta.AddDays(-1);

            var exists = await _loteBalanzaRepository.FindByAsNoTrackingAsync(
                        x => x.CreateDate > dateDesde && x.CreateDate <= dateHasta && x.IdLoteBalanza != updateDto.IdLoteBalanza &&
                        x.Tickets.Where(m => idVehiculos.Contains(m.IdVehiculo)).ToList().Count > 0,
                        x => x.Tickets
                );
            var lotes = String.Join(",", exists.Select(x => x.CodigoLote + " fecha:" + getDate(x.CreateDate.DateTime).ToShortDateFormat() + " " + getDate(x.CreateDate.DateTime).ToShortHourFormat()));

            if (exists.Any())
            {
                response.AddErrorResult(Resources.Balanza.LoteBalanza.RecordDuplicatePlaca24 + lotes);
            }
        }

        private async Task validarPlacaCreateDto(CreateLoteBalanzaDto createDto, ResponseDto response)
        {
            var idVehiculos = createDto.TicketDetails!.Select(x => x.IdVehiculo).ToList();
            DateTime date24 = getDate(DateTime.Now);

            Console.Write(date24);
            date24 = date24.AddDays(-1);
            var exists = await _loteBalanzaRepository.FindByAsNoTrackingAsync(
                        x => x.CreateDate > date24 &&
                        x.Tickets.Where(m => idVehiculos.Contains(m.IdVehiculo)).ToList().Count > 0,
                        x => x.Tickets
                );

            var lotes = String.Join(",", exists.Select(x => x.CodigoLote + " fecha:" + getDate(x.CreateDate.DateTime).ToShortDateFormat() + " " + getDate(x.CreateDate.DateTime).ToShortHourFormat()));

            if (exists.Any())
            {
                response.AddErrorResult(Resources.Balanza.LoteBalanza.RecordDuplicatePlaca24 + lotes);
            }
        }

        private DateTime getDate(DateTime date)
        {
            try
            {
                Console.Write("Eastern Standard Time");
                return TimeZoneInfo.ConvertTime(date, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            }
            catch (Exception)
            {
                Console.Write("America/New_York");
                return TimeZoneInfo.ConvertTime(date, TimeZoneInfo.FindSystemTimeZoneById("America/New_York"));
            }
        }
    }
}
