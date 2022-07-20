using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;

namespace Paltarumi.Acopio.Balanza.Application.Abstractions.Balanza
{
    public interface ITicketDocApplication
    {
        Task<ResponseDto<GetTicketDocDto>> Create(CreateTicketDocDto createDto);
        Task<ResponseDto<GetTicketDocDto>> Update(UpdateTicketDocDto updateDto);
        Task<ResponseDto> Delete(int id);
        Task<ResponseDto<GetTicketDocDto>> Get(int id);
        Task<ResponseDto<IEnumerable<ListTicketDocDto>>> List();
        Task<ResponseDto<SearchResultDto<SearchTicketDocDto>>> Search(SearchParamsDto<SearchTicketDocFilterDto> searchParams);
    }
}
