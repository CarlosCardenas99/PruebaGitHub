using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Dto.Balanza.;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.Maestro
{
    public class GetMaestroQueryHandler : QueryHandlerBase<GetMaestroQuery, GetMaestroDto>
    {
        private readonly IRepositoryBase<Entity.Maestro> _maestroRepository;

        public GetMaestroQueryHandler(
            IMapper mapper,
            GetMaestroQueryValidator validator,
            IRepositoryBase<Entity.Maestro> maestroRepository
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
