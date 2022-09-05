// TO DO : PRUEBA
using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Chancado.LoteChancado;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.LoteChancado
{
    public class UpdateEstadoLoteChancadoCommandHandler : CommandHandlerBase<UpdateEstadoLoteChancadoCommand, GetLoteChancadoDto>
    {
        private readonly IRepository<Entity.LoteChancado> _loteChancadoRepository;

        public UpdateEstadoLoteChancadoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IRepository<Entity.LoteChancado> loteChancadoRepository
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
