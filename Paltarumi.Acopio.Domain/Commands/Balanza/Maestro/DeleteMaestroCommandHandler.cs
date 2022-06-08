using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.Maestro
{
    public class DeleteMaestroCommandHandler : CommandHandlerBase<DeleteMaestroCommand>
    {
        private readonly IRepositoryBase<Entity.Maestro> _maestroRepository;

        public DeleteMaestroCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteMaestroCommandValidator validator,
            IRepositoryBase<Entity.Maestro> maestroRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _maestroRepository = maestroRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteMaestroCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var maestro = await _maestroRepository.GetByAsync(x => x.IdMaestro == request.Id);

            if (maestro != null)
            {
                maestro.Activo = false;
                await _maestroRepository.UpdateAsync(maestro);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
