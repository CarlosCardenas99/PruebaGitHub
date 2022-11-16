using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteCodigo
{
    public class GetLoteCodigoQueryHandler : QueryHandlerBase<GetLoteCodigoQuery, GetLoteCodigoDto>
    {
        private readonly IRepository<Entities.LoteCodigo> _lotecodigoRepository;
        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entities.Lote> _loteRepository;

        public GetLoteCodigoQueryHandler(
            IMapper mapper,
            GetLoteCodigoQueryValidator validator,
            IRepository<Entities.LoteCodigo> lotecodigoRepository,
            IRepository<Entities.LoteBalanza> loteBalanzaRepository,
            IRepository<Entities.Lote> loteRepository
        ) : base(mapper, validator)
        {
            _lotecodigoRepository = lotecodigoRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _loteRepository = loteRepository;
        }

        protected override async Task<ResponseDto<GetLoteCodigoDto>> HandleQuery(GetLoteCodigoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteCodigoDto>();

            var lotecodigo = await _lotecodigoRepository.GetByAsync(
                x => x.IdLoteCodigo == request.Id,
                x => x.IdLoteNavigation,
                x => x.IdLoteCodigoEstadoNavigation,
                x => x.IdDuenoMuestraNavigation,
                x => x.IdProveedorNavigation
                );

            var lotecodigoDto = _mapper?.Map<GetLoteCodigoDto>(lotecodigo);

            if (lotecodigo != null && lotecodigoDto != null)
            {
                response.UpdateData(lotecodigoDto);
            }

            return await Task.FromResult(response);
        }
    }
}
