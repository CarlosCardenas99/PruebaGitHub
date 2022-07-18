using AutoMapper;
using Paltarumi.Acopio.Balanza.Common;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Acopio.LoteOperacion
{
    public class CreateOrUpdateLoteOperacionCommandHandler : CommandHandlerBase<CreateOrUpdateLoteOperacionCommand>
    {
        private readonly IRepository<Entity.Lote> _loteRepository;
        private readonly IRepository<Entity.Modulo> _moduloRepository;
        private readonly IRepository<Entity.Operacion> _operacionRepository;
        private readonly IRepository<Entity.LoteOperacion> _loteOperacionRepository;

        public CreateOrUpdateLoteOperacionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            CreateOrUpdateLoteOperacionCommandValidator validator,
            IRepository<Entity.Lote> loteRepository,
            IRepository<Entity.Modulo> moduloRepository,
            IRepository<Entity.Operacion> operacionRepository,
            IRepository<Entity.LoteOperacion> loteOperacionRepository
        ) : base(unitOfWork, mapper, validator)
        {
            _loteRepository = loteRepository;
            _moduloRepository = moduloRepository;
            _operacionRepository = operacionRepository;
            _loteOperacionRepository = loteOperacionRepository;
        }

        public override async Task<ResponseDto> HandleCommand(CreateOrUpdateLoteOperacionCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto();

            var lote = await _loteRepository.GetByAsNoTrackingAsync(x => x.CodigoLote == request.LoteOperacionDto.CodigoLote);
            if (lote == null)
            {
                response.AddErrorResult(Resources.Acopio.LoteOperacion.LoteNoExiste);
                return response;
            }

            var modulo = await _moduloRepository.GetByAsNoTrackingAsync(x => x.Nombre == request.LoteOperacionDto.Modulo);
            if (modulo == null)
            {
                response.AddErrorResult(Resources.Acopio.LoteOperacion.ModuloNoExiste);
                return response;
            }

            var operacion = await _operacionRepository.GetByAsNoTrackingAsync(x => x.Codigo == request.LoteOperacionDto.Operacion);
            if (operacion == null)
            {
                response.AddErrorResult(Resources.Acopio.LoteOperacion.OperacionNoExiste);
                return response;
            }

            var loteOperacion = await _loteOperacionRepository.GetByAsync(x =>
                x.IdOperacionNavigation.IdModulo == modulo.IdModulo &&
                x.IdOperacion == operacion.IdOperacion &&
                x.IdLoteNavigation.CodigoLote == request.LoteOperacionDto.CodigoLote
            );

            var existe = loteOperacion != null;

            loteOperacion ??= new Entity.LoteOperacion();
            loteOperacion.IdLote = lote.IdLote;
            loteOperacion.Body = request.LoteOperacionDto.Body;
            loteOperacion.Attempts++;

            loteOperacion.Status = request.LoteOperacionDto.Exception == null ?
                Constants.Operaciones.Status.SUCCESS :
                Constants.Operaciones.Status.ERROR;

            loteOperacion.Message = request.LoteOperacionDto.Exception == null ?
                string.Empty :
                $"{request.LoteOperacionDto.Exception.Message}:{Environment.NewLine}{request.LoteOperacionDto.Exception.StackTrace}";


            if (!existe)
                await _loteOperacionRepository.AddAsync(loteOperacion);
            else
                await _loteOperacionRepository.UpdateAsync(loteOperacion);

            await _loteOperacionRepository.SaveAsync();

            return await Task.FromResult(response);
        }
    }
}
