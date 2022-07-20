using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.TicketDoc;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.TicketDoc
{
    public class ListTicketDocQueryHandler : QueryHandlerBase<ListTicketDocQuery, IEnumerable<ListTicketDocDto>>
    {
        private readonly IRepository<Entity.TicketDoc> _repository;

        public ListTicketDocQueryHandler(
            IMapper mapper,
            IRepository<Entity.TicketDoc> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListTicketDocDto>>> HandleQuery(ListTicketDocQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListTicketDocDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListTicketDocDto>>(list);

            response.UpdateData(listDtos ?? new List<ListTicketDocDto>());

            return await Task.FromResult(response);
        }
    }
}
