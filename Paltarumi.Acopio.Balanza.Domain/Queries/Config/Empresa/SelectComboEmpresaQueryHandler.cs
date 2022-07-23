using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Config.Empresa;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Config.Empresa
{
    public class SelectComboEmpresaQueryHandler : QueryHandlerBase<SelectComboEmpresaQuery, IEnumerable<SelectComboEmpresaDto>>
    {
        private readonly IRepository<Entity.Empresa> _repository;

        public SelectComboEmpresaQueryHandler(
            IMapper mapper,
            IRepository<Entity.Empresa> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<SelectComboEmpresaDto>>> HandleQuery(SelectComboEmpresaQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<SelectComboEmpresaDto>>();
            var list = await _repository.FindByAsync(x => x.Activo == true);
            var listDtos = _mapper?.Map<IEnumerable<SelectComboEmpresaDto>>(list);

            response.UpdateData(listDtos ?? new List<SelectComboEmpresaDto>());

            return await Task.FromResult(response);
        }
    }
}
