using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Maestro;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Maestro
{
    public class GetMaestroQueryHandler : QueryHandlerBase<GetMaestroQuery, GetMaestroDto>
    {
        private readonly IRepository<Entity.Maestro> _maestroRepository;

        public GetMaestroQueryHandler(
            IMapper mapper,
            GetMaestroQueryValidator validator,
            IRepository<Entity.Maestro> maestroRepository
        ) : base(mapper, validator)
        {
            _maestroRepository = maestroRepository;
        }

        protected override async Task<ResponseDto<GetMaestroDto>> HandleQuery(GetMaestroQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetMaestroDto>();
            var maestro = await _maestroRepository.GetByAsync(x => x.IdMaestro == request.Id);
            var maestroDto = _mapper?.Map<GetMaestroDto>(maestro);

            if (maestro != null && maestroDto != null)
            {
                response.UpdateData(maestroDto);
            }

            return await Task.FromResult(response);
        }
    }
}
