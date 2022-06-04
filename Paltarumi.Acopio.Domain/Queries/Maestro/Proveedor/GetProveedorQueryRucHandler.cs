using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.Proveedor;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Domain.Queries.Sunat;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class GetProveedorQueryRucHandler : QueryHandlerBase<GetProveedorQueryRuc, GetProveedorDto>
    {
        private readonly IRepositoryBase<Entity.Proveedor> _proveedorRepository;

        public GetProveedorQueryRucHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Proveedor> proveedorRepository
        ) : base(mapper)
        {
            _proveedorRepository = proveedorRepository;
        }

        protected override async Task<ResponseDto<GetProveedorDto>> HandleQuery(GetProveedorQueryRuc request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetProveedorDto>();
            var proveedor = await _proveedorRepository.GetByAsync(x => x.Ruc == request.Ruc);
            var proveedorDto = _mapper?.Map<GetProveedorDto>(proveedor);

            if (proveedor != null && proveedorDto != null)
            {
                response.UpdateData(proveedorDto);
            }
            else
            {
                SunatStorage sunat = new SunatStorage();
                var result = sunat.consultaRuc(request.Ruc);
                if (result.response.responseCode == 0 )
                {
                    proveedor = mapperCreateProveedorDto(result.sunatVo);
                    proveedor.Activo = true;
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

        private Entity.Proveedor mapperCreateProveedorDto(SunatConsultaRucVo sunatVo)
        {
            Entity.Proveedor proveedor = new Entity.Proveedor();
            proveedor.Ruc = sunatVo.ruc;
            proveedor.RazonSocial = sunatVo.razonSocial;
            proveedor.CodigoUbigeo = sunatVo.ubigeo;
            proveedor.Direccion = sunatVo.direccion;
            proveedor.Activo = true;
            proveedor.Email = String.Empty;
            proveedor.Telefono = String.Empty;
            return proveedor;
        }
    }
}
