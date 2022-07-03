using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Maestro;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Maestro
{
    public class UpdateMaestroCommandHandler : CommandHandlerBase<UpdateMaestroCommand, GetMaestroDto>
    {
        private readonly IRepository<Entity.Maestro> _maestroRepository;

        public UpdateMaestroCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateMaestroCommandValidator validator,
            IRepository<Entity.Maestro> maestroRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _maestroRepository = maestroRepository;
        }

        public override async Task<ResponseDto<GetMaestroDto>> HandleCommand(UpdateMaestroCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetMaestroDto>();
            var maestro = await _maestroRepository.GetByAsync(x => x.IdMaestro == request.UpdateDto.IdMaestro);

            if (maestro != null)
            {
                _mapper?.Map(request.UpdateDto, maestro);
                await _maestroRepository.UpdateAsync(maestro);
            }

            var maestroDto = _mapper?.Map<GetMaestroDto>(maestro);
            if (maestroDto != null) response.UpdateData(maestroDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
