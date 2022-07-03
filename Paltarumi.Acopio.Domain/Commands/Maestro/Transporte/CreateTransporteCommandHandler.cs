using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Dto.Maestro.Transporte;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Maestro.Transporte
{
    public class CreateTransporteCommandHandler : CommandHandlerBase<CreateTransporteCommand, GetTransporteDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.Transporte> _transporteRepository;

        public CreateTransporteCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateTransporteCommandValidator validator,
            IRepository<Entity.Transporte> transporteRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _transporteRepository = transporteRepository;
        }

        public override async Task<ResponseDto<GetTransporteDto>> HandleCommand(CreateTransporteCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetTransporteDto>();
            var transporte = _mapper?.Map<Entity.Transporte>(request.CreateDto);

            if (transporte != null)
            {
                transporte.Activo = true;


                await _transporteRepository.AddAsync(transporte);
                await _transporteRepository.SaveAsync();
            }

            var transporteDto = _mapper?.Map<GetTransporteDto>(transporte);
            if (transporteDto != null) response.UpdateData(transporteDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
