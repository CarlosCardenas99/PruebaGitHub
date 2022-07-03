using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza
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
