using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Balanza.Dto.Muestreo.LoteMuestreo;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Muestreo.LoteMuestreo
{
    public class CreateLoteMuestreoCommandHandler : CommandHandlerBase<CreateLoteMuestreoCommand, GetLoteMuestreoDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.LoteMuestreo> _lotemuestreoRepository;

        public CreateLoteMuestreoCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateLoteMuestreoCommandValidator validator,
            IRepository<Entity.LoteMuestreo> lotemuestreoRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _lotemuestreoRepository = lotemuestreoRepository;
        }

        public override async Task<ResponseDto<GetLoteMuestreoDto>> HandleCommand(CreateLoteMuestreoCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteMuestreoDto>();
            var lotemuestreo = _mapper?.Map<Entity.LoteMuestreo>(request.CreateDto);

            if (lotemuestreo != null)
            {
                lotemuestreo.Activo = true;


                await _lotemuestreoRepository.AddAsync(lotemuestreo);
                await _lotemuestreoRepository.SaveAsync();
            }

            var lotemuestreoDto = _mapper?.Map<GetLoteMuestreoDto>(lotemuestreo);
            if (lotemuestreoDto != null) response.UpdateData(lotemuestreoDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
