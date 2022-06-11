using AutoMapper;
using Paltarumi.Acopio.Domain.Commands.Base;
using Paltarumi.Acopio.Domain.Dto.Base;
using Paltarumi.Acopio.Domain.Dto.Balanza.LoteCheckList;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Domain.Commands.Balanza.LoteCheckList
{
    public class CreateLoteCheckListCommandHandler : CommandHandlerBase<CreateLoteCheckListCommand, GetLoteCheckListDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepositoryBase<Entity.LoteCheckList> _lotechecklistRepository;

        public CreateLoteCheckListCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateLoteCheckListCommandValidator validator,
            IRepositoryBase<Entity.LoteCheckList> lotechecklistRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _lotechecklistRepository = lotechecklistRepository;
        }

        public override async Task<ResponseDto<GetLoteCheckListDto>> HandleCommand(CreateLoteCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteCheckListDto>();
            var lotechecklist = _mapper?.Map<Entity.LoteCheckList>(request.CreateDto);

            if (lotechecklist != null)
            {
                lotechecklist.Activo = true;


                await _lotechecklistRepository.AddAsync(lotechecklist);
                await _lotechecklistRepository.SaveAsync();
            }

            var lotechecklistDto = _mapper?.Map<GetLoteCheckListDto>(lotechecklist);
            if (lotechecklistDto != null) response.UpdateData(lotechecklistDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
