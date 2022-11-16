using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateStatusLoteBalanzaCommandHandler : CommandHandlerBase<UpdateStatusLoteBalanzaCommand, GetLoteBalanzaDto>
    {
        private readonly IRepository<Entities.Lote> _loteRepository;
        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;

        public UpdateStatusLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IRepository<Entities.Lote> loteRepository,
            IRepository<Entities.LoteBalanza> loteBalanzaRepository
        ) : base(unitOfWork, mapper, mediator)
        {
            _loteRepository = loteRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaDto>> HandleCommand(UpdateStatusLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaDto>();

            var loteBalanza = await _loteBalanzaRepository.GetByAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
            var lote = await _loteRepository.GetByAsNoTrackingAsync(x => x.CodigoLote.Equals(loteBalanza.CodigoLote));

            if (loteBalanza != null)
            {
                loteBalanza.UserNameUpdate = "";
                loteBalanza.UpdateDate = DateTimeOffset.Now;
                loteBalanza.IdLoteEstado = request.UpdateDto.CodigoEstado!;

                await _loteBalanzaRepository.UpdateAsync(loteBalanza);
                await _loteBalanzaRepository.SaveAsync();

                lote.UserNameUpdate = "";
                lote.UpdateDate = DateTimeOffset.Now;

                var updateEstadoChancado = await _mediator?.Send(new UpdateEstadoLoteChancadoCommand(new UpdateEstadoLoteChancadoDto
                {
                    CodigoLote = loteBalanza.CodigoLote!,
                    IdLoteEstado = loteBalanza.IdLoteEstado
                }), cancellationToken)!;

                if (updateEstadoChancado?.IsValid == false)
                    response.AttachResults(updateEstadoChancado);

                var updateEstadoMuestreo = await _mediator?.Send(new UpdateEstadoLoteMuestreoCommand(new UpdateEstadoLoteMuestreoDto
                {
                    CodigoLote = loteBalanza.CodigoLote!,
                    IdLoteEstado = loteBalanza.IdLoteEstado
                }), cancellationToken)!;

                if (updateEstadoMuestreo?.IsValid == false)
                    response.AttachResults(updateEstadoMuestreo);

                await _loteRepository.UpdateAsync(lote);
                await _loteRepository.SaveAsync();

                var loteDto = _mapper?.Map<GetLoteBalanzaDto>(loteBalanza);

                if (loteDto != null)
                {
                    response.UpdateData(loteDto);
                    response.AddOkResult(Resources.Common.UpdateSuccessMessage);
                }
            }

            return response;
        }
    }
}
