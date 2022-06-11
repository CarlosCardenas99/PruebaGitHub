using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LeyesReferenciales;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LeyesReferenciales
{
    public class ListLeyesReferencialesQueryHandler : QueryHandlerBase<ListLeyesReferencialesQuery, IEnumerable<ListLeyesReferencialesDto>>
    {
        private readonly IRepositoryBase<Entity.LeyesReferenciales> _repository;

        public ListLeyesReferencialesQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.LeyesReferenciales> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListLeyesReferencialesDto>>> HandleQuery(ListLeyesReferencialesQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListLeyesReferencialesDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListLeyesReferencialesDto>>(list);

            response.UpdateData(listDtos ?? new List<ListLeyesReferencialesDto>());

            return await Task.FromResult(response);
        }
    }
}
