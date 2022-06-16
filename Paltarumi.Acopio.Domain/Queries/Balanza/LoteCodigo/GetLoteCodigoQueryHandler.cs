using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Balanza.LoteCodigo
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
