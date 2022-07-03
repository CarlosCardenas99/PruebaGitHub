using AutoMapper;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.LeyReferencial;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LeyReferencial
{
    public class CreateLeyReferencialCommandHandler : CommandHandlerBase<CreateLeyReferencialCommand, GetLeyReferencialDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.LeyReferencial> _leyreferencialRepository;

        public CreateLeyReferencialCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateLeyReferencialCommandValidator validator,
            IRepository<Entity.LeyReferencial> leyreferencialRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _leyreferencialRepository = leyreferencialRepository;
        }

        public override async Task<ResponseDto<GetLeyReferencialDto>> HandleCommand(CreateLeyReferencialCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLeyReferencialDto>();
            var leyreferencial = _mapper?.Map<Entity.LeyReferencial>(request.CreateDto);

            if (leyreferencial != null)
            {
                leyreferencial.Activo = true;


                await _leyreferencialRepository.AddAsync(leyreferencial);
                await _leyreferencialRepository.SaveAsync();
            }

            var leyreferencialDto = _mapper?.Map<GetLeyReferencialDto>(leyreferencial);
            if (leyreferencialDto != null) response.UpdateData(leyreferencialDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
