using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.TipoDocumento;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.TipoDocumento
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
