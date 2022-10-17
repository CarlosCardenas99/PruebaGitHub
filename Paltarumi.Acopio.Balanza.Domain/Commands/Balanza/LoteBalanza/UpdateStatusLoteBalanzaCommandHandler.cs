using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Dto.LoteBalanza;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanza
{
    public class UpdateStatusLoteBalanzaCommandHandler : CommandHandlerBase<UpdateStatusLoteBalanzaCommand, GetLoteBalanzaDto>
    {
        private readonly IRepository<Entity.Lote> _loteRepository;
        private readonly IRepository<Entity.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entity.Maestro> _maestroRepository;
        private readonly IRepository<Entity.LoteEstado> _loteEstadoRepository;

        public UpdateStatusLoteBalanzaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IRepository<Entity.Lote> loteRepository,
            IRepository<Entity.LoteBalanza> loteBalanzaRepository,
            IRepository<Entity.Maestro> maestroRepository,
            IRepository<Entity.LoteEstado> loteEstadoRepository
        ) : base(unitOfWork, mapper, mediator)
        {
            _loteRepository = loteRepository;
            _loteBalanzaRepository = loteBalanzaRepository;
            _maestroRepository = maestroRepository;
            _loteEstadoRepository = loteEstadoRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaDto>> HandleCommand(UpdateStatusLoteBalanzaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaDto>();

            var loteBalanza = await _loteBalanzaRepository.GetByAsync(x => x.IdLoteBalanza == request.UpdateDto.IdLoteBalanza);
            var lote = await _loteRepository.GetByAsNoTrackingAsync(x => x.CodigoLote.Equals(loteBalanza.CodigoLote));
            //var estado = await _maestroRepository.GetByAsNoTrackingAsync(x => x.CodigoTabla.Equals(Constants.Maestro.CodigoTabla.LOTE_ESTADO) && x.CodigoItem.Equals(request.UpdateDto.CodigoEstado));
            //var estado = await _loteEstadoRepository.GetByAsNoTrackingAsync(x => x.IdLoteEstado.Equals(request.UpdateDto.CodigoEstado));

            if (loteBalanza != null)
            {
                loteBalanza.UserNameUpdate = "";
                loteBalanza.UpdateDate = DateTimeOffset.Now;
                loteBalanza.IdLoteEstado = request.UpdateDto.CodigoEstado!;

                await _loteBalanzaRepository.UpdateAsync(loteBalanza);
                await _loteBalanzaRepository.SaveAsync();

                lote.UserNameUpdate = "";
                lote.UpdateDate = DateTimeOffset.Now;
                //lote.IdEstado = estado.IdLoteEstado;

                // TO DO : PRUEBA
                //__________________________________________________________________

                //update estado lote chancado
                var updateEstadoChancado = await _mediator?.Send(new UpdateEstadoLoteChancadoCommand(new UpdateEstadoLoteChancadoDto
                {
                    CodigoLote = loteBalanza.CodigoLote!,
                    IdLoteEstado = loteBalanza.IdLoteEstado
                }), cancellationToken)!;

                if (updateEstadoChancado?.IsValid == false)
                    response.AttachResults(updateEstadoChancado);

                //update estado lote Muestreo
                var updateEstadoMuestreo = await _mediator?.Send(new UpdateEstadoLoteMuestreoCommand(new UpdateEstadoLoteMuestreoDto
                {
                    CodigoLote = loteBalanza.CodigoLote!,
                    IdLoteEstado = loteBalanza.IdLoteEstado
                }), cancellationToken)!;

                if (updateEstadoMuestreo?.IsValid == false)
                    response.AttachResults(updateEstadoMuestreo);
                //__________________________________________________________________

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
