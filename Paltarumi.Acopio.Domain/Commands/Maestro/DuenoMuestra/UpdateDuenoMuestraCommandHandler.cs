using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.DuenoMuestra
{
    public class UpdateDuenoMuestraCommandHandler : CommandHandlerBase<UpdateDuenoMuestraCommand, GetDuenoMuestraDto>
    {
        private readonly IRepository<Entity.DuenoMuestra> _duenomuestraRepository;

        public UpdateDuenoMuestraCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateDuenoMuestraCommandValidator validator,
            IRepository<Entity.DuenoMuestra> duenomuestraRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _duenomuestraRepository = duenomuestraRepository;
        }

        public override async Task<ResponseDto<GetDuenoMuestraDto>> HandleCommand(UpdateDuenoMuestraCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetDuenoMuestraDto>();
            var duenomuestra = await _duenomuestraRepository.GetByAsync(x => x.IdDuenoMuestra == request.UpdateDto.IdDuenoMuestra);

            if (duenomuestra != null)
            {
                _mapper?.Map(request.UpdateDto, duenomuestra);
                await _duenomuestraRepository.UpdateAsync(duenomuestra);
            }

            var duenomuestraDto = _mapper?.Map<GetDuenoMuestraDto>(duenomuestra);
            if (duenomuestraDto != null) response.UpdateData(duenomuestraDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
