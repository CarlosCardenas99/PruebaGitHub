using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Transporte
{
    public class ListTransporteQueryHandler : QueryHandlerBase<ListTransporteQuery, IEnumerable<ListTransporteDto>>
    {
        private readonly IRepository<Entity.Transporte> _repository;

        public ListTransporteQueryHandler(
            IMapper mapper,
            IRepository<Entity.Transporte> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListTransporteDto>>> HandleQuery(ListTransporteQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListTransporteDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListTransporteDto>>(list);

            response.UpdateData(listDtos ?? new List<ListTransporteDto>());

            return await Task.FromResult(response);
        }
    }
}
