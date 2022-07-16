using MediatR;
using Newtonsoft.Json;
using Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Balanza.Application.Base;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.Lote;
using Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.Operacion;
using Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza;
using Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteBalanza;
using Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Lote;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Operacion;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Application.Balanza
{
    public class LoteBalanzaApplication : ApplicationBase, ILoteBalanzaApplication
    {
        public LoteBalanzaApplication(IMediator mediator) : base(mediator)
        {

        }
        public async Task<ResponseDto<GetLoteBalanzaDto>> Create(CreateLoteBalanzaDto createDto)
        {
            CreateLoteDto createLote = new CreateLoteDto();
            var respuestaLote = await _mediator.Send(new CreateLoteCommand(createLote));

            createDto.CodigoLote = respuestaLote.Data?.CodigoLote;
            var respuestaLoteBalanza = await _mediator.Send(new CreateLoteBalanzaCommand(createDto));

            UpdateLoteOperacionDto updateLoteOperacion = new UpdateLoteOperacionDto();
            updateLoteOperacion.IdLote = respuestaLote.Data == null ? 0 : respuestaLote.Data.IdLote;
            updateLoteOperacion.IdModulo = Constants.Operaciones.Modulo.BALANZA;
            updateLoteOperacion.Codigo = Constants.Operaciones.CrudOpeacion.CREATE;
            updateLoteOperacion.Body = JsonConvert.SerializeObject(createDto);
            if (respuestaLoteBalanza.IsValid && updateLoteOperacion.IdLote != 0)
                updateLoteOperacion.Status = Constants.Operaciones.Status.CORRECTO;
            else
                updateLoteOperacion.Status = Constants.Operaciones.Status.ERROR;
            var respuestaUpdateLoteOperacion = await _mediator.Send(new UpdateLoteOperacionCommand(updateLoteOperacion));

            return respuestaLoteBalanza;
        }
        public async Task<ResponseDto<GetLoteBalanzaDto>> Update(UpdateLoteBalanzaDto updateDto)
            => await _mediator.Send(new UpdateLoteBalanzaCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteLoteBalanzaCommand(id));

        public async Task<ResponseDto<GetLoteBalanzaDto>> Get(int id)
            => await _mediator.Send(new GetLoteBalanzaQuery(id));

        public async Task<ResponseDto<GetLoteBalanzaCodigoDto>> GetbyCodigo(string codigoLote)
            => await _mediator.Send(new GetLoteBalanzaByCodigoQuery(codigoLote));

        public async Task<ResponseDto<IEnumerable<ListLoteBalanzaDto>>> List()
            => await _mediator.Send(new ListLoteBalanzaQuery());

        public async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaDto>>> Search(SearchParamsDto<SearchLoteBalanzaFilterDto> searchParams)
            => await _mediator.Send(new SearchLoteBalanzaQuery(searchParams));

        public async Task<ResponseDto<SearchResultDto<SearchLoteBalanzaChecklistDto>>> SearchWithCheckList(SearchParamsDto<SearchLoteBalanzaChecklistFilterDto> searchParams)
            => await _mediator.Send(new SearchLoteBalanzaCheckListQuery(searchParams));

        public async Task<ResponseDto<byte[]>> ExportReport(string reportPath, int idTicket)
            => await _mediator.Send(new ExportLoteBalanzaReportCommand(reportPath, idTicket));

        public async Task<ResponseDto<GetLoteBalanzaCheckListDto>> UpdateLoteBalanzaCheckList(UpdateLoteBalanzaCheckListDto updateDto)
            => await _mediator.Send(new UpdateLoteBalanzaCheckListCommand(updateDto));


    }
}
