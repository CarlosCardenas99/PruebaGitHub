using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.Ticket;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Utilitary;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LoteCodigo
{
    public class ListLoteCodigoQueryHandler : QueryHandlerBase<ListLoteCodigoQuery, IEnumerable<ListLoteCodigoDto>>
    {
        private readonly IRepository<Entities.LoteCodigo> _repository;

        public ListLoteCodigoQueryHandler(
            IMapper mapper,
            IRepository<Entities.LoteCodigo> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListLoteCodigoDto>>> HandleQuery(ListLoteCodigoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListLoteCodigoDto>>();
            var list = await _repository.FindByAsync(
                    x => x.IdLoteNavigation!.CodigoLote == request.CodigoLote && x.Activo,
                    x => x.IdLoteNavigation!,
                    x => x.IdModuloNavigation,
                    x => x.IdLoteCodigoEstadoNavigation,
                    x => x.IdLoteCodigoTipoNavigation,
                    x => x.IdProveedorNavigation!,
                    x => x.IdDuenoMuestraNavigation!
                    );
            var listDtos = _mapper?.Map<IEnumerable<ListLoteCodigoDto>>(list);

            if (listDtos != null)
                listDtos.ToList().ForEach(item =>
                {
                    item.CodigoPlantaRandom = Commons.base64Decode(item.CodigoPlantaRandom);
                });

            response.UpdateData(listDtos ?? new List<ListLoteCodigoDto>());

            return await Task.FromResult(response);
        }
    }
}
