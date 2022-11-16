using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Chancado.Mapa;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Chancado.Mapa
{
    public class CreateMapaCommandHandler : CommandHandlerBase<CreateMapaCommand, GetMapaDto>
    {

        private readonly IRepository<Entities.Mapa> _mapaRepository;

        public CreateMapaCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateMapaCommandValidator validator,
            IRepository<Entities.Mapa> mapaRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _mapaRepository = mapaRepository;
        }

        public override async Task<ResponseDto<GetMapaDto>> HandleCommand(CreateMapaCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetMapaDto>();

            var mapa = _mapper?.Map<Entities.Mapa>(request.CreateDto);
            if (mapa == null)
            {
                response.AddErrorResult(Resources.Chancado.Mapa.MapaRequired);
                return response;
            }

            await _mapaRepository.AddAsync(mapa);
            await _mapaRepository.SaveAsync();

            var mapaDto = _mapper?.Map<GetMapaDto>(mapa);
            if (mapaDto != null) response.UpdateData(mapaDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
