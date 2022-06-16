using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Domain.Queries.Sunat;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class GetProveedorQueryRucHandler : QueryHandlerBase<GetProveedorQueryRuc, GetProveedorDto>
    {
        private readonly IRepository<Entity.Proveedor> _proveedorRepository;
        private readonly IRepository<Entity.Ubigeo> _ubigeoRepository;
        public GetProveedorQueryRucHandler(
            IMapper mapper,
            IRepository<Entity.Proveedor> proveedorRepository,
            IRepository<Entity.Ubigeo> ubigeoRepository
        ) : base(mapper)
        {
            _proveedorRepository = proveedorRepository;
            _ubigeoRepository = ubigeoRepository;
        }

        protected override async Task<ResponseDto<GetProveedorDto>> HandleQuery(GetProveedorQueryRuc request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetProveedorDto>();
            var proveedor = await _proveedorRepository.GetByAsync(x => x.Ruc == request.Ruc && x.Activo == true);
            var proveedorDto = _mapper?.Map<GetProveedorDto>(proveedor);

            if (proveedor != null && proveedorDto != null)
            {
                response.UpdateData(proveedorDto);
            }
            else
            {
                SunatStorage sunat = new SunatStorage();
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

                    proveedor = mapperCreateProveedorDto(result.sunatVo, ubigeo);

                    proveedor.Direccion ??= string.Empty;
                    proveedor.Telefono ??= string.Empty;
                    proveedor.Email ??= string.Empty;

                    await _proveedorRepository.AddAsync(proveedor);
                    await _proveedorRepository.SaveAsync();

                    proveedorDto = _mapper?.Map<GetProveedorDto>(proveedor);

                    if (proveedorDto != null) response.UpdateData(proveedorDto);
                }
                else
                {
                    List<ApplicationMessageDto> lisMsg = new List<ApplicationMessageDto>();
                    ApplicationMessageDto msg = new ApplicationMessageDto();
                    msg.MessageType = ApplicationMessageType.Error;
                    msg.Message = result.response.responseMessage;
                    msg.Key = "Error";
                    lisMsg.Add(msg);
                    response.Messages = lisMsg;
                }
            }

            return await Task.FromResult(response);
        }

        private Entity.Proveedor mapperCreateProveedorDto(SunatConsultaRucVo sunatVo, Entity.Ubigeo? ubigeo)
            => new Entity.Proveedor
            {
                Ruc = sunatVo.ruc,
                RazonSocial = sunatVo.razonSocial,
                CodigoUbigeo = ubigeo?.CodigoUbigeo ?? null,
                Direccion = sunatVo.direccion,
                Email = String.Empty,
                Telefono = String.Empty,
                Activo = true
            };
    }
}
