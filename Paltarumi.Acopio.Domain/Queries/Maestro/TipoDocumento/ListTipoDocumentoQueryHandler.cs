using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.TipoDocumento;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.TipoDocumento
{
    public class ListTipoDocumentoQueryHandler : QueryHandlerBase<ListTipoDocumentoQuery, IEnumerable<ListTipoDocumentoDto>>
    {
        private readonly IRepositoryBase<Entity.TipoDocumento> _repository;

        public ListTipoDocumentoQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.TipoDocumento> repository
        ) : base(mapper)
        {
            _repository = repository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListTipoDocumentoDto>>> HandleQuery(ListTipoDocumentoQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListTipoDocumentoDto>>();
            var list = await _repository.FindAll().ToListAsync(cancellationToken);
            var listDtos = _mapper?.Map<IEnumerable<ListTipoDocumentoDto>>(list);

            response.UpdateData(listDtos ?? new List<ListTipoDocumentoDto>());

            return await Task.FromResult(response);
        }
    }
}
