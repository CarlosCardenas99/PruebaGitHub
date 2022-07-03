using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Maestro.Dto.Transporte;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Maestro.Transporte
{
    public class UpdateTransporteCommandHandler : CommandHandlerBase<UpdateTransporteCommand, GetTransporteDto>
    {
        private readonly IRepository<Entity.Transporte> _transporteRepository;

        public UpdateTransporteCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UpdateTransporteCommandValidator validator,
            IRepository<Entity.Transporte> transporteRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _transporteRepository = transporteRepository;
        }

        public override async Task<ResponseDto<GetTransporteDto>> HandleCommand(UpdateTransporteCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTransporteDto>();
            var transporte = await _transporteRepository.GetByAsync(x => x.IdTransporte == request.UpdateDto.IdTransporte);

            if (transporte != null)
            {
                _mapper?.Map(request.UpdateDto, transporte);
                await _transporteRepository.UpdateAsync(transporte);
            }

            var transporteDto = _mapper?.Map<GetTransporteDto>(transporte);
            if (transporteDto != null) response.UpdateData(transporteDto);

            response.AddOkResult(Resources.Common.UpdateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
