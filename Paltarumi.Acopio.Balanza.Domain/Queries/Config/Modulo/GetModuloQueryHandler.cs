using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Config.Dto.Modulo;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Config.Modulo
{
    public class GetModuloQueryHandler : QueryHandlerBase<GetModuloQuery, GetModuloDto>
    {
        private readonly IRepository<Entity.Modulo> _moduloRepository;

        public GetModuloQueryHandler(
            IMapper mapper,
            GetModuloQueryValidator validator,
            IRepository<Entity.Modulo> moduloRepository
        ) : base(mapper, validator)
        {
            _moduloRepository = moduloRepository;
        }

        protected override async Task<ResponseDto<GetModuloDto>> HandleQuery(GetModuloQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetModuloDto>();
            var modulo = await _moduloRepository.GetByAsync(x => x.IdModulo == request.Id);
            var moduloDto = _mapper?.Map<GetModuloDto>(modulo);

            if (modulo != null && moduloDto != null)
            {
                response.UpdateData(moduloDto);
            }

            return await Task.FromResult(response);
        }
    }
}
