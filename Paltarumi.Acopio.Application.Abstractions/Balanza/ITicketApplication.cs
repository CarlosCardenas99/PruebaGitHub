using Paltarumi.Acopio.Domain.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Domain.Dto.Base;

namespace Paltarumi.Acopio.Application.Abstractions.Balanza
{
    public interface ITicketApplication
    {
        Task<ResponseDto<GetTicketDto>> Create(CreateTicketDto createDto);
        Task<ResponseDto<GetTicketDto>> Update(UpdateTicketDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetTicketDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListTicketDto>>> List(int idLote);
        Task<ResponseDto<SearchResultDto<SearchTicketDto>>> Search(SearchParamsDto<TicketFilterDto> searchParams);

    }
}
