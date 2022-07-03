using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Vehiculo;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Vehiculo
{
    public class ListVehiculoQueryHandler : QueryHandlerBase<ListVehiculoQuery, IEnumerable<ListVehiculoDto>>
    {
        private readonly IRepository<Entity.Vehiculo> _repository;

        public ListVehiculoQueryHandler(
            IMapper mapper,
            IRepository<Entity.Vehiculo> repository
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
