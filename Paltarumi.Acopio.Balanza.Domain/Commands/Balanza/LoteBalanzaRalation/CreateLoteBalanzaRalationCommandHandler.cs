using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteBalanzaRalation;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteBalanzaRalation
{
    public class CreateLoteBalanzaRalationCommandHandler : CommandHandlerBase<CreateLoteBalanzaRalationCommand, GetLoteBalanzaRalationDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entities.LoteBalanzaRalation> _lotebalanzaRalationRepository;
        private readonly IRepository<Entities.LoteBalanza> _lotebalanzaRepository;
        private readonly IRepository<Entities.LoteMuestreo> _loteMuestreoRepository;

        public CreateLoteBalanzaRalationCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            CreateLoteBalanzaRalationCommandValidator validator,
            IRepository<Entities.LoteBalanzaRalation> lotebalanzaRalationRepository,
            IRepository<Entities.LoteBalanza> lotebalanzaRepository,
            IRepository<Entities.LoteMuestreo> loteMuestreoRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _lotebalanzaRalationRepository = lotebalanzaRalationRepository;
            _lotebalanzaRepository = lotebalanzaRepository;
            _loteMuestreoRepository = loteMuestreoRepository;
        }

        public override async Task<ResponseDto<GetLoteBalanzaRalationDto>> HandleCommand(CreateLoteBalanzaRalationCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<GetLoteBalanzaRalationDto>();
            List<Entities.LoteBalanzaRalation> list = new List<Entities.LoteBalanzaRalation>();

            var createDtos = request.CreateDto.ItemLoteBalanzaRalation!.ToList();

            //OBTENER ID_LOTES_TRUJILLO
            var idLotesTrujillo = createDtos?.Select(x => x.IdLoteBalanzaOrigin) ?? new List<int>();

            //OBTENER ID_LOTEBALANZA
            var idLoteBalanza = createDtos.Select(x => x.IdLoteBalanza).FirstOrDefault();
            var lotesTrujillo = await _lotebalanzaRepository.FindByAsNoTrackingAsync(x => idLotesTrujillo.Contains(x.IdLoteBalanza));

            foreach (var createDto in createDtos)
            {
                Entities.LoteBalanzaRalation newReg = new Entities.LoteBalanzaRalation();
                newReg.IdLoteBalanzaOrigin = createDto.IdLoteBalanzaOrigin;
                newReg.IdLoteBalanza = createDto.IdLoteBalanza;

                list.Add(newReg);
            }

            await _lotebalanzaRalationRepository.AddAsync(list.ToArray());
            await _lotebalanzaRalationRepository.SaveAsync();

            //var updateCodigoTrujilloLoteBalanza = await _mediator?.Send(new UpdateCodigoTrujilloLoteBalanzaCommand(
            //    new UpdateCodigoTrujilloLoteBalanzaDto
            //    {
            //        IdLoteBalanza = idLoteBalanza,
            //        CodigoTrujillo = lotesTrujillo != null ? string.Join(",", lotesTrujillo.Select(x => x.CodigoLote)) : String.Empty
            //    }), cancellationToken)!;

            //if (updateCodigoTrujilloLoteBalanza?.IsValid == false)
            //    response.AttachResults(updateCodigoTrujilloLoteBalanza);

            var lotebalanzaralationDto = _mapper?.Map<GetLoteBalanzaRalationDto>(list.ToArray().FirstOrDefault(new Entities.LoteBalanzaRalation()));
            if (lotebalanzaralationDto != null) response.UpdateData(lotebalanzaralationDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }

    }
}
