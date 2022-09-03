

using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Chancado.Mapa;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.Mapa
{
    public class UpdateMapaCommandHandler : CommandHandlerBase<UpdateMapaCommand, GetMapaDto>
    {
        private readonly IRepository<Entity.Mapa> _mapaRepository;

        public UpdateMapaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            UpdateMapaCommandValidator validator,
            IRepository<Entity.Mapa> mapaRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _mapaRepository = mapaRepository;
        }

        public override async Task<ResponseDto<GetMapaDto>> HandleCommand(UpdateMapaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetMapaDto>();

            var mapa = await _mapaRepository.GetByAsync(x => x.IdLoteChancado == request.UpdateDto.IdLoteChancado);
            if (mapa == null)
            {
                response.AddErrorResult(Resources.Chancado.Mapa.MapaRequired);
                return response;
            }

            _mapper?.Map(request.UpdateDto, mapa);

            await _mapaRepository.UpdateAsync(mapa);
            await _mapaRepository.SaveAsync();

            return await Task.FromResult(response);
        }
    }
}
