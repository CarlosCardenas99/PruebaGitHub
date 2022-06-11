using AutoMapper;
using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Queries.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Domain.Queries.Sunat;
using Paltarumi.Acopio.Common;

namespace Paltarumi.Acopio.Domain.Queries.Maestro.DuenoMuestra
{
    public class GetDuenoMuestraByDocumentQueryHandler : QueryHandlerBase<GetDuenoMuestraByDocumentQuery, GetDuenoMuestraDto>
    {
        private readonly IRepositoryBase<Entity.DuenoMuestra> _duenoMuestraRepository;

        public GetDuenoMuestraByDocumentQueryHandler(
            IMapper mapper,
            IRepositoryBase<Entity.DuenoMuestra> duenomuestraRepository
        ) : base(mapper)
        {
            _duenoMuestraRepository = duenomuestraRepository;
        }

        protected override async Task<ResponseDto<GetDuenoMuestraDto>> HandleQuery(GetDuenoMuestraByDocumentQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetDuenoMuestraDto>();
            var duenoMuestra = await _duenoMuestraRepository.GetByAsync(x => x.Numero.Equals(request.Filter.numero) && x.CodigoTipoDocumento.Equals(request.Filter.CodigoTipoDocumento) && x.Activo == true);
            var duenoMuestraDto = _mapper?.Map<GetDuenoMuestraDto>(duenoMuestra);

            if (duenoMuestra != null && duenoMuestraDto != null)
            {
                response.UpdateData(duenoMuestraDto);
            }
            else
            {
                SunatConsultaRucDto result = null;
                SunatStorage sunat = new SunatStorage();
                if (request.Filter.CodigoTipoDocumento.Equals(Constants.TipoDocumento.DNI))
                    result = sunat.ConsultaDni(request.Filter.numero);
                else if (request.Filter.CodigoTipoDocumento.Equals(Constants.TipoDocumento.RUC))
                    result = sunat.ConsultaRuc(request.Filter.numero);
                else
                    return await Task.FromResult(response);

                if (result != null && result?.response.responseCode == 0)
                {
                    duenoMuestra = mapperCreateDuenoMuestraDto(result.sunatVo, request.Filter.CodigoTipoDocumento);
                    await _duenoMuestraRepository.AddAsync(duenoMuestra);
                    await _duenoMuestraRepository.SaveAsync();
                    duenoMuestraDto = _mapper?.Map<GetDuenoMuestraDto>(duenoMuestra);
                    response.UpdateData(duenoMuestraDto);
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

        private Entity.DuenoMuestra? mapperCreateDuenoMuestraDto(SunatConsultaRucVo sunatVo, string codigoTipoDocumento)
        {
            Entity.DuenoMuestra duenoMuestra = new Entity.DuenoMuestra();
            duenoMuestra.IdDuenoMuestra = 0;
            duenoMuestra.Numero = sunatVo.ruc;
            duenoMuestra.Nombres = sunatVo.razonSocial;
            duenoMuestra.CodigoTipoDocumento = codigoTipoDocumento;
            duenoMuestra.CodigoUbigeo = null;
            duenoMuestra.Email = String.Empty;
            duenoMuestra.Telefono = String.Empty;
            duenoMuestra.Direccion = sunatVo.direccion ?? string.Empty;
            duenoMuestra.Activo = true;
            return duenoMuestra;
        }
    }
}
