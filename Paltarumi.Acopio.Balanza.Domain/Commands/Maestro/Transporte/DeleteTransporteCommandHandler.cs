using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Transporte
{
    public class DeleteTransporteCommandHandler : CommandHandlerBase<DeleteTransporteCommand>
    {
        private readonly IRepository<Entity.Transporte> _transporteRepository;

        public DeleteTransporteCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            DeleteTransporteCommandValidator validator,
            IRepository<Entity.Transporte> transporteRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _transporteRepository = transporteRepository;
        }

        public override async Task<ResponseDto> HandleCommand(DeleteTransporteCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();
            var transporte = await _transporteRepository.GetByAsync(x => x.IdTransporte == request.Id);

            if (transporte != null)
            {
                transporte.Activo = false;
                await _transporteRepository.UpdateAsync(transporte);
                response.AddOkResult(Resources.Common.DeleteSuccessMessage);
            }

            return response;
        }
    }
}
