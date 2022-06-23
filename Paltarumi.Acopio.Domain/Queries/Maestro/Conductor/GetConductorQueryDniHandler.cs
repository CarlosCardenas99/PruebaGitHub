using AutoMapper;
using Paltarumi.Acopio.Common;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.Conductor;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Domain.Queries.Sunat;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.Conductor
{
    public class GetConductorQueryDniHandler : QueryHandlerBase<GetConductorQueryDni, GetConductorDto>
    {
        private readonly IRepository<Entity.Conductor> _conductorRepository;

        public GetConductorQueryDniHandler(
            IMapper mapper,
            IRepository<Entity.Conductor> conductorRepository
        ) : base(mapper)
        {
            _conductorRepository = conductorRepository;
        }

        protected override async Task<ResponseDto<GetConductorDto>> HandleQuery(GetConductorQueryDni request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetConductorDto>();
            var conductor = await _conductorRepository.GetByAsync(x => x.Numero.Equals(request.Dni) && x.CodigoTipoDocumento == Constants.TipoDocumento.DNI && x.Activo == true);
            var conductorDto = _mapper?.Map<GetConductorDto>(conductor);

            if (conductor != null && conductorDto != null)
            {
                response.UpdateData(conductorDto);
            }
            else
            {
                SunatStorage sunat = new SunatStorage();
                var result = sunat.ConsultaDni(request.Dni);
                if (result.response.responseCode == 0)
                {
                    conductor = mapperCreateConductorDto(result.sunatVo);
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
                    msg.Message = result.response.responseMessage;
                    msg.Key = "Error";
                    lisMsg.Add(msg);
                    response.Messages = lisMsg;
                }
            }

            return await Task.FromResult(response);
        }

        private Entity.Conductor? mapperCreateConductorDto(SunatConsultaRucVo sunatVo)
        {
            Entity.Conductor conductor = new Entity.Conductor();
            conductor.IdConductor = 0;
            conductor.Numero = sunatVo.ruc;
            conductor.Nombres = sunatVo.razonSocial;
            conductor.CodigoTipoDocumento = Constants.TipoDocumento.DNI;
            conductor.CodigoUbigeo = null;
            conductor.Licencia = String.Empty;
            conductor.Domicilio = String.Empty;
            conductor.Email = String.Empty;
            conductor.Telefono = String.Empty;
            conductor.Activo = true;
            return conductor;
        }
    }
}
