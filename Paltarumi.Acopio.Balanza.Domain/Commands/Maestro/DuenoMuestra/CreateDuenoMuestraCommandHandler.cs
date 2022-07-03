using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.DuenoMuestra;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.DuenoMuestra
{
    public class CreateDuenoMuestraCommandHandler : CommandHandlerBase<CreateDuenoMuestraCommand, GetDuenoMuestraDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.DuenoMuestra> _duenomuestraRepository;

        public CreateDuenoMuestraCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateDuenoMuestraCommandValidator validator,
            IRepository<Entity.DuenoMuestra> duenomuestraRepository
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
