using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.Maestro;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Maestro
{
    public class CreateMaestroCommandHandler : CommandHandlerBase<CreateMaestroCommand, GetMaestroDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepositoryBase<Entity.Maestro> _maestroRepository;

        public CreateMaestroCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateMaestroCommandValidator validator,
            IRepositoryBase<Entity.Maestro> maestroRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _maestroRepository = maestroRepository;
        }

        public override async Task<ResponseDto<GetMaestroDto>> HandleCommand(CreateMaestroCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetMaestroDto>();
            var maestro = _mapper?.Map<Entity.Maestro>(request.CreateDto);

            if (maestro != null)
            {
                maestro.Activo = true;


                await _maestroRepository.AddAsync(maestro);
                await _maestroRepository.SaveAsync();
            }

            var maestroDto = _mapper?.Map<GetMaestroDto>(maestro);
            if (maestroDto != null) response.UpdateData(maestroDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
