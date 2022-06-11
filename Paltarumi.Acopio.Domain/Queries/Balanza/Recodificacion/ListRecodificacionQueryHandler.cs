using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Recodificacion;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Recodificacion
{
    public class ListRecodificacionQueryHandler : QueryHandlerBase<ListRecodificacionQuery, IEnumerable<ListRecodificacionDto>>
    {
        private readonly IRepositoryBase<Entity.Recodificacion> _repository;

        public ListRecodificacionQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Recodificacion> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListRecodificacionDto>>> HandleQuery(ListRecodificacionQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListRecodificacionDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListRecodificacionDto>>(list);

            response.UpdateData(listDtos ?? new List<ListRecodificacionDto>());

            return await Task.FromResult(response);
        }
    }
}
