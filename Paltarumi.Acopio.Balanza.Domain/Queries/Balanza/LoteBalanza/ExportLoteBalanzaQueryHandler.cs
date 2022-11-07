using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Export.Application.App;
using Paltarumi.Acopio.Export.Application.Dto;
using System.Reflection;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza
{
    public class ExportLoteBalanzaQueryHandler : QueryHandlerBase<ExportLoteBalanzaQuery, SearchResultDto<byte>>
    {

        public ExportLoteBalanzaQueryHandler(
            IMapper mapper,
            IMediator mediator
        ) : base(mapper, mediator)
        {

        }

        protected override async Task<ResponseDto<SearchResultDto<byte>>> HandleQuery(ExportLoteBalanzaQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<SearchResultDto<byte>>();
            var searchResult = await _mediator?.Send(new SearchLoteBalanzaQuery(request.SearchParams.search))!;
            var itemsToExport = searchResult?.Data?.Items ?? new List<SearchLoteBalanzaDto>();

            var app = new ExportApp();
            var lista = (IEnumerable<object>)itemsToExport;
            var rowsData = (await app.getData(lista.ToList())).Data.ToList();

            var ext = app.Export(rowsData, request.SearchParams.infoHeaders!.ToList());

            response.UpdateData(new SearchResultDto<byte>
            {
                Items = ext.Result.Data
            });

            return await Task.FromResult(response);
        }


    }
}
