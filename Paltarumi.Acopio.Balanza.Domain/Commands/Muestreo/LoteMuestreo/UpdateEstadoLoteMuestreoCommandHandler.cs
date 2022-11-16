using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class UpdateEstadoLoteMuestreoCommandHandler : CommandHandlerBase<UpdateEstadoLoteMuestreoCommand, GetLoteMuestreoDto>
    {
        private readonly IRepository<Entities.LoteMuestreo> _loteMuestreoRepository;
        private readonly IRepository<Entities.LoteCodigoMuestreo> _loteCodigoMuestreoRepository;

        public UpdateEstadoLoteMuestreoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IRepository<Entities.LoteMuestreo> loteMuestreoRepository,
            IRepository<Entities.LoteCodigoMuestreo> loteCodigoMuestreoRepository
        ) : base(unitOfWork, mapper, mediator)
        {
            _loteMuestreoRepository = loteMuestreoRepository;
            _loteCodigoMuestreoRepository = loteCodigoMuestreoRepository;
        }

        public override async Task<ResponseDto<GetLoteMuestreoDto>> HandleCommand(UpdateEstadoLoteMuestreoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteMuestreoDto>();

            var loteMuestreo = await _loteMuestreoRepository.GetByAsync(
                x => x.CodigoLote == request.UpdateDto.CodigoLote,
                x => x.LoteCodigoMuestreos
                );
            if (loteMuestreo == null)
            {
                response.AddErrorResult(Resources.Muestreo.LoteMuestreo.LoteMuestreoRequired);
                return response;
            }

            _mapper?.Map(request.UpdateDto, loteMuestreo);

            await _loteMuestreoRepository.UpdateAsync(loteMuestreo);
            await _loteMuestreoRepository.SaveAsync();

            //________________UPDATE ESTADO LOTECODIGOMUESTREO_________________________
            //var loteCodigoMuestreos = await _loteCodigoMuestreoRepository.FindByAsNoTrackingAsync(x => x.IdLoteMuestreo == loteMuestreo.IdLoteMuestreo);

            //foreach (var loteCodigoMuestreo in (loteCodigoMuestreos ?? new List<Entities.LoteCodigoMuestreo>()))
            //{
            //    var loteCodigoMuestreoDto = loteMuestreo.LoteCodigoMuestreos?.FirstOrDefault(x => x.IdLoteCodigoMuestreo == loteCodigoMuestreo.IdLoteCodigoMuestreo);

            //    if (loteCodigoMuestreoDto != null)
            //    {
            //        var updateResponse = await _mediator?.Send(new UpdateLoteCodigoMuestreoCommand(
            //            new UpdateLoteCodigoMuestreoDto
            //            {
            //                IdLoteCodigoMuestreo = loteCodigoMuestreoDto.IdLoteCodigoMuestreo,
            //                Activo = false,
            //            }), cancellationToken)!;

            //        if (updateResponse?.IsValid == false)
            //            response.AttachResults(updateResponse);
            //    }
            //}
            //________________________________________________________________________
            return await Task.FromResult(response);
        }
    }
}