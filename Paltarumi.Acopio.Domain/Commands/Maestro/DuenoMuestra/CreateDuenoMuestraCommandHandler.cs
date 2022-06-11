using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Maestro.DuenoMuestra;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.DuenoMuestra
{
    public class CreateDuenoMuestraCommandHandler : CommandHandlerBase<CreateDuenoMuestraCommand, GetDuenoMuestraDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepositoryBase<Entity.DuenoMuestra> _duenomuestraRepository;

        public CreateDuenoMuestraCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateDuenoMuestraCommandValidator validator,
            IRepositoryBase<Entity.DuenoMuestra> duenomuestraRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _duenomuestraRepository = duenomuestraRepository;
        }

        public override async Task<ResponseDto<GetDuenoMuestraDto>> HandleCommand(CreateDuenoMuestraCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetDuenoMuestraDto>();
            var duenomuestra = _mapper?.Map<Entity.DuenoMuestra>(request.CreateDto);

            if (duenomuestra != null)
            {
                duenomuestra.Activo = true;


                await _duenomuestraRepository.AddAsync(duenomuestra);
                await _duenomuestraRepository.SaveAsync();
            }

            var duenomuestraDto = _mapper?.Map<GetDuenoMuestraDto>(duenomuestra);
            if (duenomuestraDto != null) response.UpdateData(duenomuestraDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
