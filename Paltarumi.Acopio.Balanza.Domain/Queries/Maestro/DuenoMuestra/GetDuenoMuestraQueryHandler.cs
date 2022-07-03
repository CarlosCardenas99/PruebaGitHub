using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraQueryHandler : QueryHandlerBase<GetDuenoMuestraQuery, GetDuenoMuestraDto>
    {
        private readonly IRepository<Entity.DuenoMuestra> _duenomuestraRepository;

        public GetDuenoMuestraQueryHandler(
            IMapper mapper,
            GetDuenoMuestraQueryValidator validator,
            IRepository<Entity.DuenoMuestra> duenomuestraRepository
        ) : base(mapper, validator)
        {
            _duenomuestraRepository = duenomuestraRepository;
        }

        protected override async Task<ResponseDto<GetDuenoMuestraDto>> HandleQuery(GetDuenoMuestraQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetDuenoMuestraDto>();
            var duenomuestra = await _duenomuestraRepository.GetByAsync(x => x.IdDuenoMuestra == request.Id);
            var duenomuestraDto = _mapper?.Map<GetDuenoMuestraDto>(duenomuestra);

            if (duenomuestra != null && duenomuestraDto != null)
            {
                response.UpdateData(duenomuestraDto);
            }

            return await Task.FromResult(response);
        }
    }
}
