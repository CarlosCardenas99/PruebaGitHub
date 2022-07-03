using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Transporte;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.Transporte
{
    public class GetTransporteQueryHandler : QueryHandlerBase<GetTransporteQuery, GetTransporteDto>
    {
        private readonly IRepository<Entity.Transporte> _transporteRepository;

        public GetTransporteQueryHandler(
            IMapper mapper,
            GetTransporteQueryValidator validator,
            IRepository<Entity.Transporte> transporteRepository
        ) : base(mapper, validator)
        {
            _transporteRepository = transporteRepository;
        }

        protected override async Task<ResponseDto<GetTransporteDto>> HandleQuery(GetTransporteQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTransporteDto>();
            var transporte = await _transporteRepository.GetByAsync(x => x.IdTransporte == request.Id);
            var transporteDto = _mapper?.Map<GetTransporteDto>(transporte);

            if (transporte != null && transporteDto != null)
            {
                response.UpdateData(transporteDto);
            }

            return await Task.FromResult(response);
        }
    }
}
