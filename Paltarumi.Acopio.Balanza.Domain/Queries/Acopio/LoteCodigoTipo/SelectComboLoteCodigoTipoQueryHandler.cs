using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteCodigoTipo;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Acopio.LoteCodigoTipo
{
    public class SelectComboLoteCodigoTipoQueryHandler : QueryHandlerBase<SelectComboLoteCodigoTipoQuery, IEnumerable<SelectComboLoteCodigoTipoDto>>
    {
        private readonly IRepository<Entity.LoteCodigoTipo> _repository;

        public SelectComboLoteCodigoTipoQueryHandler(
            IMapper mapper,
            IRepository<Entity.LoteCodigoTipo> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<SelectComboLoteCodigoTipoDto>>> HandleQuery(SelectComboLoteCodigoTipoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<SelectComboLoteCodigoTipoDto>>();
            var list = await _repository.FindByAsNoTrackingAsync(x => x.Activo == true);
            var listDtos = _mapper?.Map<IEnumerable<SelectComboLoteCodigoTipoDto>>(list);

            response.UpdateData(listDtos.OrderBy(x => x.Orden).ToList() ?? new List<SelectComboLoteCodigoTipoDto>());

            return await Task.FromResult(response);
        }
    }
}
