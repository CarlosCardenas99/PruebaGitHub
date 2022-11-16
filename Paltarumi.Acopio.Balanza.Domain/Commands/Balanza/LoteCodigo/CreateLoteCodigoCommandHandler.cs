using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Domain.Commands.Common;
using Paltarumi.Acopio.Balanza.Dto.LoteCodigo;
using Paltarumi.Acopio.Constantes;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Repository.Security;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Balanza.LoteCodigo
{
    public class CreateLoteCodigoCommandHandler : CommandHandlerBase<CreateLoteCodigoCommand, GetLoteCodigoDto>
    {
        protected override bool UseTransaction => false;

        private readonly IRepository<Entities.Lote> _loteRepository;
        private readonly IRepository<Entities.LoteBalanza> _loteBalanzaRepository;
        private readonly IRepository<Entities.LoteCodigo> _lotecodigoRepository;
        private readonly IUserIdentity _userIdentity;

        public CreateLoteCodigoCommandHandler(
            IUnitOfWork unitOfWork,
            IMediator mediator,
            IMapper mapper,
            IUserIdentity userIdentity,
            CreateLoteCodigoCommandValidator validator,
            IRepository<Entities.Lote> loteRepository,
            IRepository<Entities.LoteBalanza> loteBalanzaRepository,
            IRepository<Entities.LoteCodigo> lotecodigoRepository
        ) : base(unitOfWork, mapper, mediator, validator)
        {
            _loteRepository = loteRepository;
            _lotecodigoRepository = lotecodigoRepository;
            _userIdentity = userIdentity;
            _loteBalanzaRepository = loteBalanzaRepository;
        }

        public override async Task<ResponseDto<GetLoteCodigoDto>> HandleCommand(CreateLoteCodigoCommand request, CancellationToken cancellationToken)
        {
            var idSucursal = _userIdentity.GetIdSucursal();

            var response = new ResponseDto<GetLoteCodigoDto>();
            var lotecodigo = _mapper?.Map<Entities.LoteCodigo>(request.CreateDto);

            if (lotecodigo != null)
            {
                lotecodigo.Activo = true;

                lotecodigo.IdLoteCodigoEstado = CONST_ACOPIO.LOTECODIGO_ESTADO.PENDIENTE;

                string codigoLote = string.Empty;
                int idEmpresa = Constants.Empresa.PALTARUMI;
                int idCorrelativo = 0;

                if (request.CreateDto.IdLote != null)
                {
                    var lote = await _loteRepository.GetByAsNoTrackingAsync(x => x.IdLote == request.CreateDto.IdLote);
                    codigoLote = lote.CodigoLote;
                    idEmpresa = lote.IdEmpresa;

                    var loteBalanza = await _loteBalanzaRepository.GetByAsNoTrackingAsync(x => x.CodigoLote == codigoLote);
                    idCorrelativo = loteBalanza!.IdCorrelativo;
                    lotecodigo.IdProveedor = loteBalanza.IdProveedor;
                }

                lotecodigo.CodigoPlantaRandom = (await _mediator!.Send(new CreateCodeRandomCorrelativeCommand()))?.Data ?? string.Empty;

                var codeAndCorrelativo = await _mediator.Send(new CreateCodePlantaCommand(idEmpresa, codigoLote, request.CreateDto.IdLoteCodigoTipo, request.CreateDto.IdSucursal, request.CreateDto.Serie));
                lotecodigo.CodigoPlanta = codeAndCorrelativo.Data!.Numero;

                if (idCorrelativo == 0) lotecodigo.IdCorrelativo = codeAndCorrelativo.Data!.IdCorrelativo;
                else lotecodigo.IdCorrelativo = idCorrelativo;

                await _lotecodigoRepository.AddAsync(lotecodigo);
                await _lotecodigoRepository.SaveAsync();
            }

            var lotecodigoDto = _mapper?.Map<GetLoteCodigoDto>(lotecodigo);
            if (lotecodigoDto != null) response.UpdateData(lotecodigoDto);

            response.AddOkResult(Resources.Common.CreateSuccessMessage);

            return await Task.FromResult(response);
        }
    }
}
