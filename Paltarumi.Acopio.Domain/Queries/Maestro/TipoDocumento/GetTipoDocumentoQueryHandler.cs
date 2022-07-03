using AutoMapper;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.TipoDocumento;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.TipoDocumento
{
    public class GetTipoDocumentoQueryHandler : QueryHandlerBase<GetTipoDocumentoQuery, GetTipoDocumentoDto>
    {
        private readonly IRepository<Entity.TipoDocumento> _tipodocumentoRepository;

        public GetTipoDocumentoQueryHandler(
            IMapper mapper,
            GetTipoDocumentoQueryValidator validator,
            IRepository<Entity.TipoDocumento> tipodocumentoRepository
        ) : base(mapper, validator)
        {
            _tipodocumentoRepository = tipodocumentoRepository;
        }

        protected override async Task<ResponseDto<GetTipoDocumentoDto>> HandleQuery(GetTipoDocumentoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTipoDocumentoDto>();
            var tipodocumento = await _tipodocumentoRepository.GetByAsync(x => x.CodigoTipoDocumento.Equals(request.Id));
            var tipodocumentoDto = _mapper?.Map<GetTipoDocumentoDto>(tipodocumento);

            if (tipodocumento != null && tipodocumentoDto != null)
            {
                response.UpdateData(tipodocumentoDto);
            }

            return await Task.FromResult(response);
        }
    }
}
