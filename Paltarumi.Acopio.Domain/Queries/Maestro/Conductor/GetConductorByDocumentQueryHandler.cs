using AutoMapper;
using Paltarumi.Acopio.Common;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Domain.Queries.Sunat;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class GetConductorByDocumentQueryHandler : QueryHandlerBase<GetConductorByDocumentQuery, GetConductorDto>
    {
        private readonly IRepository<Entity.Conductor> _conductorRepository;

        public GetConductorByDocumentQueryHandler(
            IMapper mapper,
            IRepository<Entity.Conductor> conductorRepository
        ) : base(mapper)
        {
            _conductorRepository = conductorRepository;
        }

        protected override async Task<ResponseDto<GetConductorDto>> HandleQuery(GetConductorByDocumentQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetConductorDto>();
            var conductor = await _conductorRepository.GetByAsync(x => x.Numero.Equals(request.Filter.Numero) || x.Licencia.Equals(request.Filter.Numero) && x.CodigoTipoDocumento.Equals(request.Filter.CodigoTipoDocumento) && x.Activo == true);
            var conductorDto = _mapper?.Map<GetConductorDto>(conductor);

            if (conductor != null && conductorDto != null)
            {
                response.UpdateData(conductorDto);
            }
            else
            {
                SunatConsultaRucDto result = null!;
                SunatStorage sunat = new SunatStorage();

                if (string.Equals(Constants.TipoDocumento.DNI, request?.Filter?.CodigoTipoDocumento))
                    result = sunat.ConsultaDni(request?.Filter.Numero);

                else if (string.Equals(Constants.TipoDocumento.RUC, request?.Filter?.CodigoTipoDocumento))
                    result = sunat.ConsultaRuc(request?.Filter.Numero);
                else
                    return await Task.FromResult(response);

                if (result != null && result?.response.responseCode == 0)
                {
                    conductor = mapperCreateConductorDto(result.sunatVo, request?.Filter?.CodigoTipoDocumento);

                    await _conductorRepository.AddAsync(conductor!);
                    await _conductorRepository.SaveAsync();

                    conductorDto = _mapper?.Map<GetConductorDto>(conductor);

                    response.UpdateData(conductorDto!);
                }
                else
                {
                    List<ApplicationMessageDto> lisMsg = new List<ApplicationMessageDto>();
                    ApplicationMessageDto msg = new ApplicationMessageDto();
                    msg.MessageType = ApplicationMessageType.Error;
                    msg.Message = result?.response.responseMessage;
                    msg.Key = "Error";
                    lisMsg.Add(msg);
                    response.Messages = lisMsg;
                }
            }

            return await Task.FromResult(response);
        }

        private Entity.Conductor? mapperCreateConductorDto(SunatConsultaRucVo sunatVo, string? codigoTipoDocumento)
        {
            Entity.Conductor conductor = new Entity.Conductor();

            conductor.IdConductor = 0;
            conductor.Numero = sunatVo.ruc;
            conductor.Nombres = sunatVo.razonSocial;
            conductor.CodigoTipoDocumento = codigoTipoDocumento ?? string.Empty;
            conductor.CodigoUbigeo = null;
            conductor.Licencia = string.Empty;
            conductor.Domicilio = string.Empty;
            conductor.Email = string.Empty;
            conductor.Telefono = string.Empty;
            conductor.Activo = true;

            return conductor;
        }
    }
}
