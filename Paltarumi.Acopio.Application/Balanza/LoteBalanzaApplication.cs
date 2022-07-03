using MediatR;
using Paltarumi.Acopio.Application.Abstractions.Balanza;
using Paltarumi.Acopio.Application.Base;
using Paltarumi.Acopio.Domain.Commands.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Queries.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Queries.Maestro.LoteBalanza;
using Paltarumi.Acopio.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Application.Balanza
{
    public class LoteBalanzaApplication : ApplicationBase, ILoteBalanzaApplication
    {
        public LoteBalanzaApplication(IMediator mediator) : base(mediator)
        {

        }
        public async Task<ResponseDto<GetLoteBalanzaDto>> Create(CreateLoteBalanzaDto createDto)
            => await _mediator.Send(new CreateLoteBalanzaCommand(createDto));

        public async Task<ResponseDto<GetLoteBalanzaDto>> Update(UpdateLoteBalanzaDto updateDto)
            => await _mediator.Send(new UpdateLoteBalanzaCommand(updateDto));

        public async Task<ResponseDto> Delete(int id)
            => await _mediator.Send(new DeleteLoteBalanzaCommand(id));

        public async Task<ResponseDto<GetLoteBalanzaDto>> Get(int id)
            => await _mediator.Send(new GetLoteBalanzaQuery(id));

        public async Task<ResponseDto<GetLoteBalanzaCodigoDto>> GetbyCodigo(string codigo)
            => await _mediator.Send(new GetLoteBalanzaByCodigoQuery(codigo));



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
