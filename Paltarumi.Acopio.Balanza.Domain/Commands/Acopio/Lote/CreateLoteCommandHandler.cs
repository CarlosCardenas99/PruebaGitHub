using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Common;
using Paltarumi.Acopio.Balanza.Dto.Acopio.Lote;
using Paltarumi.Acopio.Balanza.Dto.Acopio.LoteOperacion;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.Lote
{
    public class CreateLoteCommandHandler : CommandHandlerBase<CreateLoteCommand, GetLoteDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entity.Lote> _loteRepository;

        public CreateLoteCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteCommandValidator validator,
            IRepository<Entity.Lote> loteRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteRepository = loteRepository;
        }

        public override async Task<ResponseDto<GetLoteDto>> HandleCommand(CreateLoteCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteDto>();
            var lote = _mapper?.Map<Entity.Lote>(request.CreateDto);

            // Actualizar la serie harcoded
            var codeResponse = await _mediator.Send(new CreateCodeCommand(Constants.CodigoCorrelativoTipo.LOTE, "1"));
            var code = codeResponse?.Data ?? string.Empty;

            lote.CodigoLote = code;
            lote.UserNameCreate = "";
            lote.CreateDate = DateTimeOffset.Now;

            if (lote != null)
            {
                await _loteRepository.AddAsync(lote);
                await _loteRepository.SaveAsync();
            }

            var loteDto = _mapper?.Map<GetLoteDto>(lote);
            if (loteDto != null) response.UpdateData(loteDto);

            CreateLoteOperacionDto createLoteOperacion = new CreateLoteOperacionDto();
            createLoteOperacion.IdLote = lote.IdLote;
            await _mediator.Send(new CreateLoteOperacionCommand(createLoteOperacion));

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
