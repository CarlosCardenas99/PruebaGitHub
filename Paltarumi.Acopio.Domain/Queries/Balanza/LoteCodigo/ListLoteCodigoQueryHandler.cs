using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCodigo
{
    public class ListLoteCodigoQueryHandler : QueryHandlerBase<ListLoteCodigoQuery, IEnumerable<ListLoteCodigoDto>>
    {
        private readonly IRepository<Entity.LoteCodigo> _repository;

        public ListLoteCodigoQueryHandler(
            IMapper mapper,
            IRepository<Entity.LoteCodigo> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListLoteCodigoDto>>> HandleQuery(ListLoteCodigoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListLoteCodigoDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListLoteCodigoDto>>(list);

            response.UpdateData(listDtos ?? new List<ListLoteCodigoDto>());

            return await Task.FromResult(response);
        }
    }
}
