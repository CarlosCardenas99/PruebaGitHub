using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.DuenoMuestra
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
