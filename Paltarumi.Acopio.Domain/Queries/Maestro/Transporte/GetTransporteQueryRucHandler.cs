using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Domain.Queries.Sunat;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class GetTransporteQueryRucHandler : QueryHandlerBase<GetTransporteQueryRuc, GetTransporteDto>
    {
        private readonly IRepositoryBase<Entity.Transporte> _transporteRepository;
        private readonly IRepositoryBase<Entity.Ubigeo> _ubigeoRepository;
        public GetTransporteQueryRucHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Transporte> transporteRepository,
            IRepositoryBase<Entity.Ubigeo> ubigeoRepository
        ) : base(mapper)
        {
            _transporteRepository = transporteRepository;
            _ubigeoRepository = ubigeoRepository;
        }

        protected override async Task<ResponseDto<GetTransporteDto>> HandleQuery(GetTransporteQueryRuc request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTransporteDto>();
            var transporte = await _transporteRepository.GetByAsync(x => x.Ruc == request.Ruc && x.Activo == true);
            var transporteDto = _mapper?.Map<GetTransporteDto>(transporte);

            if (transporte != null && transporteDto != null)
            {
                response.UpdateData(transporteDto);
            }
            else
            {
                var sunat = new SunatStorage();
                var result = sunat.ConsultaRuc(request.Ruc);

                if (result.response.responseCode == 0)
                {
                    var departamento = result.sunatVo.departamento ?? string.Empty;
                    var provincia = result.sunatVo.provincia ?? string.Empty;
                    var distrito = result.sunatVo.distrito ?? string.Empty;

                    var ubigeo = await _ubigeoRepository.GetByAsync(x =>
                       string.Equals(x.Departamento.ToLower(), departamento.ToLower()) &&
                       string.Equals(x.Provincia.ToLower(), provincia.ToLower()) &&
                       string.Equals(x.Distrito.ToLower(), distrito.ToLower())
                    );

                    if (ubigeo == null) ubigeo = new Entity.Ubigeo();

                    transporte = mapperCreateTransporteDto(result.sunatVo, ubigeo);

                    transporte.Direccion ??= string.Empty;
                    transporte.Telefono ??= string.Empty;
                    transporte.Email ??= string.Empty;

                    await _transporteRepository.AddAsync(transporte);
                    await _transporteRepository.SaveAsync();

                    transporteDto = _mapper?.Map<GetTransporteDto>(transporte);

                    response.UpdateData(transporteDto);
                }
                else
                {
                    var lisMsg = new List<ApplicationMessageDto>();
                    var msg = new ApplicationMessageDto();

                    msg.MessageType = ApplicationMessageType.Error;
                    msg.Message = result.response.responseMessage;
                    msg.Key = "Error";

                    lisMsg.Add(msg);

                    response.Messages = lisMsg;
                }
            }

            return await Task.FromResult(response);
        }

        private Entity.Transporte mapperCreateTransporteDto(SunatConsultaRucVo sunatVo, Entity.Ubigeo ubigeo) 
            => new Entity.Transporte
            {
                Ruc = sunatVo.ruc,
                RazonSocial = sunatVo.razonSocial,
                CodigoUbigeo = ubigeo.CodigoUbigeo,
                Direccion = sunatVo.direccion,
                Email = string.Empty,
                Telefono = string.Empty,
                Activo = true
            };
    }
}
