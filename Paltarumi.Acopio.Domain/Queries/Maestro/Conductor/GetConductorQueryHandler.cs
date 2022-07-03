using AutoMapper;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class GetConductorQueryHandler : QueryHandlerBase<GetConductorQuery, GetConductorDto>
    {
        private readonly IRepository<Entity.Conductor> _conductorRepository;

        public GetConductorQueryHandler(
            IMapper mapper,
            GetConductorQueryValidator validator,
            IRepository<Entity.Conductor> conductorRepository
        ) : base(mapper, validator)
        {
            _conductorRepository = conductorRepository;
        }

        protected override async Task<ResponseDto<GetConductorDto>> HandleQuery(GetConductorQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetConductorDto>();
            var conductor = await _conductorRepository.GetByAsync(x => x.IdConductor == request.Id);
            var conductorDto = _mapper?.Map<GetConductorDto>(conductor);

            if (conductor != null && conductorDto != null)
            {
                response.UpdateData(conductorDto);
            }

            return await Task.FromResult(response);
        }
    }
}
