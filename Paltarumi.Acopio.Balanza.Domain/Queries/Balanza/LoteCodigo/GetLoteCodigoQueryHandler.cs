using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteCodigo
{
    public class GetLoteCodigoQueryHandler : QueryHandlerBase<GetLoteCodigoQuery, GetLoteCodigoDto>
    {
        private readonly IRepository<Entity.LoteCodigo> _lotecodigoRepository;

        public GetLoteCodigoQueryHandler(
            IMapper mapper,
            GetLoteCodigoQueryValidator validator,
            IRepository<Entity.LoteCodigo> lotecodigoRepository
        ) : base(mapper, validator)
        {
            _lotecodigoRepository = lotecodigoRepository;
        }

        protected override async Task<ResponseDto<GetLoteCodigoDto>> HandleQuery(GetLoteCodigoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteCodigoDto>();
            var lotecodigo = await _lotecodigoRepository.GetByAsync(x => x.IdLoteCodigo == request.Id);
            var lotecodigoDto = _mapper?.Map<GetLoteCodigoDto>(lotecodigo);

            if (lotecodigo != null && lotecodigoDto != null)
            {
                response.UpdateData(lotecodigoDto);
            }

            return await Task.FromResult(response);
        }
    }
}
