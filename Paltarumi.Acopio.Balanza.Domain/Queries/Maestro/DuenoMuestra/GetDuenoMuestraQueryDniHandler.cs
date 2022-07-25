using AutoMapper;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Queries.Base;
using Paltarumi.Acopio.Balanza.Domain.Queries.Sunat;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Domain.Queries.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraQueryDniHandler : QueryHandlerBase<GetDuenoMuestraQueryDni, GetDuenoMuestraDto>
    {
        private readonly IRepository<Entity.DuenoMuestra> _duenoMuestraRepository;

        public GetDuenoMuestraQueryDniHandler(
            IMapper mapper,
            IRepository<Entity.DuenoMuestra> duenoMuestraRepository
        ) : base(mapper)
        {
            _duenoMuestraRepository = duenoMuestraRepository;
        }
        protected override async Task<ResponseDto<GetDuenoMuestraDto>> HandleQuery(GetDuenoMuestraQueryDni request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetDuenoMuestraDto>();
            var duenoMuestra = await _duenoMuestraRepository.GetByAsync(x => x.Numero.Equals(request.Dni) && x.CodigoTipoDocumento == Constants.TipoDocumento.DNI && x.Activo == true);
            var duenoMuestraDto = _mapper?.Map<GetDuenoMuestraDto>(duenoMuestra);

            if (duenoMuestra != null && duenoMuestraDto != null)
            {
                response.UpdateData(duenoMuestraDto);
            }
            else
            {
                SunatStorage sunat = new SunatStorage();
                var result = sunat.ConsultaDni(request.Dni);
                if (result.response.responseCode == 0)
                {
                    duenoMuestra = mapperCreateDuenoMuestraDto(result.sunatVo);
                    await _duenoMuestraRepository.AddAsync(duenoMuestra!);
                    await _duenoMuestraRepository.SaveAsync();
                    duenoMuestraDto = _mapper?.Map<GetDuenoMuestraDto>(duenoMuestra);
                    response.UpdateData(duenoMuestraDto!);
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
        private Entity.DuenoMuestra? mapperCreateDuenoMuestraDto(SunatConsultaRucVo sunatVo)
        {
            Entity.DuenoMuestra duenoMuestra = new Entity.DuenoMuestra();

            duenoMuestra.IdDuenoMuestra = 0;
            duenoMuestra.Numero = sunatVo.ruc;
            duenoMuestra.Nombres = sunatVo.razonSocial;
            duenoMuestra.CodigoTipoDocumento = Constants.TipoDocumento.DNI;
            duenoMuestra.Email = string.Empty;
            duenoMuestra.Telefono = string.Empty;
            duenoMuestra.Direccion = sunatVo.direccion ?? string.Empty;
            duenoMuestra.Activo = true;

            return duenoMuestra;
        }
    }
}
