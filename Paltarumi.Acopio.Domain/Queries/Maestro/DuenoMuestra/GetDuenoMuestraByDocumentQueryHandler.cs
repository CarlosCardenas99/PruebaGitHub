using AutoMapper;
using Paltarumi.Acopio.Common;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Domain.Queries.Sunat;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Repository.Abstractions.Base;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraByDocumentQueryHandler : QueryHandlerBase<GetDuenoMuestraByDocumentQuery, GetDuenoMuestraDto>
    {
        private readonly IRepository<Entity.DuenoMuestra> _duenoMuestraRepository;

        public GetDuenoMuestraByDocumentQueryHandler(
            IMapper mapper,
            IRepository<Entity.DuenoMuestra> duenomuestraRepository
        ) : base(mapper)
        {
            _duenoMuestraRepository = duenomuestraRepository;
        }

        protected override async Task<ResponseDto<GetDuenoMuestraDto>> HandleQuery(GetDuenoMuestraByDocumentQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetDuenoMuestraDto>();
            var duenoMuestra = await _duenoMuestraRepository.GetByAsync(x => x.Numero.Equals(request.Filter.Numero) && x.CodigoTipoDocumento.Equals(request.Filter.CodigoTipoDocumento) && x.Activo == true);
            var duenoMuestraDto = _mapper?.Map<GetDuenoMuestraDto>(duenoMuestra);

            if (duenoMuestra != null && duenoMuestraDto != null)
            {
                response.UpdateData(duenoMuestraDto);
            }
            else
            {
                SunatConsultaRucDto result = null!;
                SunatStorage sunat = new SunatStorage();

                if (string.Equals(Constants.TipoDocumento.DNI, request.Filter.CodigoTipoDocumento))
                    result = sunat.ConsultaDni(request.Filter.Numero);

                else if (string.Equals(Constants.TipoDocumento.RUC, request.Filter.CodigoTipoDocumento))
                    result = sunat.ConsultaRuc(request.Filter.Numero);
                else
                    return await Task.FromResult(response);

                if (result != null && result?.response.responseCode == 0)
                {
                    duenoMuestra = mapperCreateDuenoMuestraDto(result.sunatVo, request.Filter.CodigoTipoDocumento);

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
                    msg.Message = result?.response.responseMessage;
                    msg.Key = "Error";
                    lisMsg.Add(msg);
                    response.Messages = lisMsg;
                }
            }

            return await Task.FromResult(response);
        }

        private Entity.DuenoMuestra? mapperCreateDuenoMuestraDto(SunatConsultaRucVo sunatVo, string? codigoTipoDocumento)
        {
            Entity.DuenoMuestra duenoMuestra = new Entity.DuenoMuestra();

            duenoMuestra.IdDuenoMuestra = 0;
            duenoMuestra.Numero = sunatVo.ruc;
            duenoMuestra.Nombres = sunatVo.razonSocial;
            duenoMuestra.CodigoTipoDocumento = codigoTipoDocumento ?? string.Empty;
            duenoMuestra.Email = string.Empty;
            duenoMuestra.Telefono = string.Empty;
            duenoMuestra.Direccion = sunatVo.direccion ?? string.Empty;
            duenoMuestra.Activo = true;

            return duenoMuestra;
        }
    }
}
