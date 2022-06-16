using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteBalanza;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.LoteBalanza
{
    public class ListLoteBalanzaQueryHandler : QueryHandlerBase<ListLoteBalanzaQuery, IEnumerable<ListLoteBalanzaDto>>
    {
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;

        public ListLoteBalanzaQueryHandler(
            IMapper mapper,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository
        ) : base(mapper)
        {
            _loteBalanzaRepository = loteBalanzaRepository;
        }

        protected override async Task<ResponseDto<IEnumerable<ListLoteBalanzaDto>>> HandleQuery(ListLoteBalanzaQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<IEnumerable<ListLoteBalanzaDto>>();
            var lotes = await _loteBalanzaRepository.FindAll().ToListAsync(cancellationToken);
            var loteDtos = _mapper?.Map<IEnumerable<ListLoteBalanzaDto>>(lotes);


            response.UpdateData(loteDtos ?? new List<ListLoteBalanzaDto>());



            return await Task.FromResult(response);
        }
    }
}
