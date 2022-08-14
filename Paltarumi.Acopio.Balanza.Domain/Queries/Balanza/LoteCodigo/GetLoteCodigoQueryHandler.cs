﻿using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteCodigo
{
    public class GetLoteCodigoQueryHandler : QueryHandlerBase<GetLoteCodigoQuery, GetLoteCodigoDto>
    {
        private readonly IRepository<Entity.LoteCodigo> _lotecodigoRepository;
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entity.Lote> _loteRepository;

        public GetLoteCodigoQueryHandler(
            IMapper mapper,
            GetLoteCodigoQueryValidator validator,
            IRepository<Entity.LoteCodigo> lotecodigoRepository,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IRepository<Entity.Lote> loteRepository
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
                x => x.IdDuenoMuestraNavigation
                );

            var lotecodigoDto = _mapper?.Map<GetLoteCodigoDto>(lotecodigo);

            if (lotecodigo.IdLote != null) {

                var lote = await _loteRepository.GetByAsNoTrackingAsync(x => x.IdLote == lotecodigo.IdLote);

                var loteBalanzas = await _loteBalanzaRepository.GetByAsNoTrackingAsync(
                    x => x.CodigoLote.Equals(lote.CodigoLote),
                    x => x.IdEstadoNavigation,
                    x => x.IdProveedorNavigation
                );

                lotecodigoDto.Proveedor = loteBalanzas.IdProveedorNavigation.RazonSocial;
            }

            if (lotecodigo != null && lotecodigoDto != null)
            {
                //lotecodigoDto.Proveedor=
                response.UpdateData(lotecodigoDto);
            }

            return await Task.FromResult(response);
        }
    }
}
