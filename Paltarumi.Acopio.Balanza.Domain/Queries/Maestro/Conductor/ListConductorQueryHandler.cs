using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Conductor;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Conductor
{
    public class ListConductorQueryHandler : QueryHandlerBase<ListConductorQuery, IEnumerable<ListConductorDto>>
    {
        private readonly IRepository<Entity.Conductor> _conductorRepository;

        public ListConductorQueryHandler(
            IMapper mapper,
            IRepository<Entity.Conductor> conductorRepository
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
