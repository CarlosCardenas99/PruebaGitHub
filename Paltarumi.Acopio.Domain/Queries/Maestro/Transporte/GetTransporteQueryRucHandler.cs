using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Domain.Queries.Sunat;
using Paltarumi.Acopio.Domain.Dto.Maestro.Transporte;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Proveedor
{
    public class GetTransporteQueryRucHandler : QueryHandlerBase<GetTransporteQueryRuc, GetTransporteDto>
    {
        private readonly IRepositoryBase<Entity.Transporte> _transporteRepository;

        public GetTransporteQueryRucHandler(
            IMapper mapper,
            IRepositoryBase<Entity.Transporte> transporteRepository
        ) : base(mapper)
        {
            _transporteRepository = transporteRepository;
        }

        protected override async Task<ResponseDto<GetTransporteDto>> HandleQuery(GetTransporteQueryRuc request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTransporteDto>();
            var transporte = await _transporteRepository.GetByAsync(x => x.Ruc == request.Ruc);
            var transporteDto = _mapper?.Map<GetTransporteDto>(transporte);

            if (transporte != null && transporteDto != null)
            {
                response.UpdateData(transporteDto);
            }
            else
            {
                SunatStorage sunat = new SunatStorage();
                var result = sunat.ConsultaRuc(request.Ruc);
                if (result.response.responseCode == 0 )
                {
                    transporte = mapperCreateTransporteDto(result.sunatVo);
                    await _transporteRepository.AddAsync(transporte);
                    await _transporteRepository.SaveAsync();
                    transporteDto = _mapper?.Map<GetTransporteDto>(transporte);
                    response.UpdateData(transporteDto);
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

        private Entity.Transporte mapperCreateTransporteDto(SunatConsultaRucVo sunatVo)
        {
            Entity.Transporte transporte = new Entity.Transporte();
            transporte.Ruc = sunatVo.ruc;
            transporte.RazonSocial = sunatVo.razonSocial;
            transporte.CodigoUbigeo = null;
            transporte.Direccion = sunatVo.direccion;
            transporte.Email = String.Empty;
            transporte.Telefono = String.Empty;
            transporte.Activo = true;
            return transporte;
        }
    }
}
