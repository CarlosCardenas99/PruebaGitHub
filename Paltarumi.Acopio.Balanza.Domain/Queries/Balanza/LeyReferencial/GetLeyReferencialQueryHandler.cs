﻿using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Dto.LeyReferencial;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestros.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Maestros.Dto.Maestro.Maestro;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Balanza.LeyReferencial
{
    public class GetLeyReferencialQueryHandler : QueryHandlerBase<GetLeyReferencialQuery, GetLeyReferencialDto>
    {
        private readonly IRepository<Entity.LeyReferencial> _leyreferencialRepository;

        public GetLeyReferencialQueryHandler(
            IMapper mapper,
            GetLeyReferencialQueryValidator validator,
            IRepository<Entity.LeyReferencial> leyreferencialRepository
        ) : base(mapper, validator)
        {
            _leyreferencialRepository = leyreferencialRepository;
        }

        protected override async Task<ResponseDto<GetLeyReferencialDto>> HandleQuery(GetLeyReferencialQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLeyReferencialDto>();
            var leyreferencial = await _leyreferencialRepository.GetByAsync(
                x => x.IdLeyReferencial == request.Id,
                x => x.IdDuenoMuestraNavigation,
                x => x.IdTipoMineralNavigation!
            );
            var leyreferencialDto = _mapper?.Map<GetLeyReferencialDto>(leyreferencial);

            if (leyreferencial != null && leyreferencialDto != null)
            {
                leyreferencialDto.DuenoMuestra = leyreferencial.IdDuenoMuestraNavigation == null ? null : _mapper?.Map<GetDuenoMuestraDto>(leyreferencial.IdDuenoMuestraNavigation);
                leyreferencialDto.TipoMineral = leyreferencial.IdTipoMineralNavigation == null ? null : _mapper?.Map<GetMaestroDto>(leyreferencial.IdTipoMineralNavigation);
                response.UpdateData(leyreferencialDto);
            }

            return await Task.FromResult(response);
        }
    }
}
