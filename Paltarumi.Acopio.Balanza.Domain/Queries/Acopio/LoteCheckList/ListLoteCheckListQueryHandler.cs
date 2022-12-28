using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCheckList;
using Paltarumi.Acopio.Constantes;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.LoteCheckList
{
    public class ListLoteCheckListQueryHandler : QueryHandlerBase<ListLoteCheckListQuery, IEnumerable<ListLoteCheckListDto>>
    {
        private readonly IRepository<Entity.LoteCheckList> _repository;

        //private readonly IEnumerable<LoteCheckListDto> list;

        public ListLoteCheckListQueryHandler(
            IMapper mapper,
            IRepository<Entity.LoteCheckList> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListLoteCheckListDto>>> HandleQuery(ListLoteCheckListQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListLoteCheckListDto>>();


            if (request.Modulo == CONST_ACOPIO.LOTECODIGO_MODULO.BALANZA)
            {
                var list = await _repository.FindByAsNoTrackingAsync(
                    x => x.IdLoteBalanza == request.IdLoteBalanza &&
                    x.IdItemCheckNavigation.IdModulo == request.Modulo,
                    x => x.IdItemCheckNavigation,
                    x => x.IdItemCheckNavigation.IdModuloNavigation
                    );

                var listDtos = _mapper?.Map<IEnumerable<ListLoteCheckListDto>>(list);

                response.UpdateData(listDtos ?? new List<ListLoteCheckListDto>());
            }
            else
            {
                var list = await _repository.FindByAsNoTrackingAsync(
                    x => x.IdLoteBalanza == request.IdLoteBalanza,
                    x => x.IdItemCheckNavigation,
                    x => x.IdItemCheckNavigation.IdModuloNavigation
                    );

                var listDtos = _mapper?.Map<IEnumerable<ListLoteCheckListDto>>(list);

                response.UpdateData(listDtos ?? new List<ListLoteCheckListDto>());
            }

            return await Task.FromResult(response);
        }
    }
}
