using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteEstado;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Common;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.LoteEstado
{
    public class SelectComboLoteEstadoQueryHandler : QueryHandlerBase<SelectComboLoteEstadoQuery, IEnumerable<SelectComboLoteEstadoDto>>
    {
        private readonly IRepository<Entity.LoteEstado> _repository;

        public SelectComboLoteEstadoQueryHandler(
            IMapper mapper,
            IRepository<Entity.LoteEstado> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<SelectComboLoteEstadoDto>>> HandleQuery(SelectComboLoteEstadoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<SelectComboLoteEstadoDto>>();
            var list = await _repository.FindByAsync( x =>x.IdLoteEstado != Constants.acopio.LoteEstado.RETIRADO && x.IdLoteEstado != Constants.acopio.LoteEstado.ANULADO); //.ToListAsync(cancellationToken)
            var listDtos = _mapper?.Map<IEnumerable<SelectComboLoteEstadoDto>>(list);

            response.UpdateData(listDtos ?? new List<SelectComboLoteEstadoDto>());

            return await Task.FromResult(response);
        }
    }
}
