using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.LoteBalanza
{
    public class ListLoteBalanzaQueryHandler : QueryHandlerBase<ListLoteBalanzaQuery, IEnumerable<ListLoteBalanzaDto>>
    {
        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;

        public ListLoteBalanzaQueryHandler(
            IMapper mapper,
            IRepository<Entities.LoteBalanza> loteBalanzaRepository
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
