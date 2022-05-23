using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class ListConductorQueryHandler : QueryHandlerBase<ListConductorQuery, IEnumerable<ListConductorDto>>
    {
        private readonly IRepositoryBase<Entity.Conductor> _conductorRepository;

        public ListConductorQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Conductor> conductorRepository
        ) : base(mapper)
        {
            _conductorRepository = conductorRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListConductorDto>>> HandleQuery(ListConductorQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListConductorDto>>();
            var condutors = await _conductorRepository.FindAll().ToListAsync(cancellationToken);
            var condutorDtos = _mapper?.Map<IEnumerable<ListConductorDto>>(condutors);

            response.UpdateData(condutorDtos ?? new List<ListConductorDto>());

            return await Task.FromResult(response);
        }
    }
}
