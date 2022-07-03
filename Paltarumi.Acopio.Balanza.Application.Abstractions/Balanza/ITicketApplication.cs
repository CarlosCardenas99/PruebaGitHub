using Paltarumi.Acopio.Balanza.Dto.Ticket;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza
{
    public interface ITicketApplication
    {
        Task<ResponseDto<GetTicketDto>> Create(CreateTicketDto createDto);
        Task<ResponseDto<GetTicketDto>> Update(UpdateTicketDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetTicketDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListTicketDto>>> List(int idLoteBalanza);
        Task<ResponseDto<SearchResultDto<SearchTicketDto>>> Search(SearchParamsDto<SearchTicketFilterDto> searchParams);//SearchQuery
        Task<ResponseDto<SearchResultDto<SearchConsultaTicketDto>>> SearchQuery(SearchParamsDto<SearchConsultaTicketFilterDto> searchParams);

    }
}
