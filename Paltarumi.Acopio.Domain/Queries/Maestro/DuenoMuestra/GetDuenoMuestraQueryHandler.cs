using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraQueryHandler : QueryHandlerBase<GetDuenoMuestraQuery, GetDuenoMuestraDto>
    {
        private readonly IRepositoryBase<Entity.DuenoMuestra> _duenomuestraRepository;

        public GetDuenoMuestraQueryHandler(
            IMapper mapper,
            GetDuenoMuestraQueryValidator validator,
            IRepositoryBase<Entity.DuenoMuestra> duenomuestraRepository
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
