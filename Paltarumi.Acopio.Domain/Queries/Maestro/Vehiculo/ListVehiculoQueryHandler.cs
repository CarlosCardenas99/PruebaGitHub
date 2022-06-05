using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Vehiculo;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Vehiculo
{
    public class ListVehiculoQueryHandler : QueryHandlerBase<ListVehiculoQuery, IEnumerable<ListVehiculoDto>>
    {
        private readonly IRepositoryBase<Entity.Vehiculo> _repository;

        public ListVehiculoQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Vehiculo> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListVehiculoDto>>> HandleQuery(ListVehiculoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListVehiculoDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListVehiculoDto>>(list);

            response.UpdateData(listDtos ?? new List<ListVehiculoDto>());

            return await Task.FromResult(response);
        }
    }
}
