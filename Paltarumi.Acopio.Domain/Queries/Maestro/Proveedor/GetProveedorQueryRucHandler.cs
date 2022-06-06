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
        private readonly IRepositoryBase<Entity.Proveedor> _proveedorRepository;
        private readonly IRepositoryBase<Entity.Ubigeo> _ubigeoRepository;
        public GetProveedorQueryRucHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Proveedor> proveedorRepository,
            IRepositoryBase<Entity.Ubigeo> ubigeoRepository
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

                    var ubigeo = await _ubigeoRepository.GetByAsync(x =>
                        x.Departamento.ToLower().Equals(result.sunatVo.departamento.ToLower()) &&
                        x.Provincia.ToLower().Equals(result.sunatVo.provincia.ToLower()) &&
                        x.Distrito.ToLower().Equals(result.sunatVo.distrito.ToLower())
                    );
                    if (ubigeo == null) ubigeo = new Entity.Ubigeo();
                    proveedor = mapperCreateProveedorDto(result.sunatVo, ubigeo);
                    await _proveedorRepository.AddAsync(proveedor);
                    await _proveedorRepository.SaveAsync();
                    proveedorDto = _mapper?.Map<GetProveedorDto>(proveedor);
                    response.UpdateData(proveedorDto);
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
        {
            Entity.Proveedor proveedor = new Entity.Proveedor();
            proveedor.Ruc = sunatVo.ruc;
            proveedor.RazonSocial = sunatVo.razonSocial;
            proveedor.CodigoUbigeo = ubigeo?.CodigoUbigeo ?? null;
            proveedor.Direccion = sunatVo.direccion;
            proveedor.Email = String.Empty;
            proveedor.Telefono = String.Empty;
            proveedor.Activo = true;
            return proveedor;
        }
    }
}
