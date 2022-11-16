using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado
{
    public class UpdateEstadoLoteChancadoCommandHandler : CommandHandlerBase<UpdateEstadoLoteChancadoCommand, GetLoteChancadoDto>
    {
        private readonly IRepository<Entities.LoteChancado> _loteChancadoRepository;

        public UpdateEstadoLoteChancadoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IRepository<Entities.LoteChancado> loteChancadoRepository
        ) : base(unitOfWork, mapper, mediator)
        {
            _loteChancadoRepository = loteChancadoRepository;
        }

        public override async Task<ResponseDto<GetLoteChancadoDto>> HandleCommand(UpdateEstadoLoteChancadoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteChancadoDto>();

            var loteChancado = await _loteChancadoRepository.GetByAsync(x => x.CodigoLote == request.UpdateDto.CodigoLote);
            if (loteChancado == null)
            {
                response.AddErrorResult(Resources.Chancado.LoteChancado.LoteChancadoRequired);
                return response;
            }

            _mapper?.Map(request.UpdateDto, loteChancado);

            await _loteChancadoRepository.UpdateAsync(loteChancado);
            await _loteChancadoRepository.SaveAsync();

            //___________________________Update Estado Mapa_____________________
            //var updateMapaEstado = await _mediator?.Send(new UpdateMapaEstadoCommand(new UpdateMapaEstadoDto
            //{
            //    IdLoteChancado = loteChancado.IdLoteChancado,
            //    Activo = false,
            //}), cancellationToken)!;

            //if (updateMapaEstado?.IsValid == false)
            //    response.AttachResults(updateMapaEstado);
            //_________________________________________________________________

            return await Task.FromResult(response);
        }
    }
}
