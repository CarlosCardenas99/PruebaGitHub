using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Constantes;
using Paltarumi.Acopio.Dto.Base;
using Paltarumi.Acopio.Repository.Abstractions.Base;
using Paltarumi.Acopio.Repository.Abstractions.Transactions;
using Entities = Paltarumi.Acopio.Entity;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Common
{
    public class CreateCodeRandomCorrelativeCommandHandler : CommandHandlerBase<CreateCodeRandomCorrelativeCommand, string>
    {

        private readonly IRepository<Entities.LoteCodigoControl> _loteCodigoControlRepository;

        public CreateCodeRandomCorrelativeCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IRepository<Entities.LoteCodigoControl> loteCodigoControlRepository
        ) : base(unitOfWork, mapper, mediator)
        {
            _loteCodigoControlRepository = loteCodigoControlRepository;
        }

        public override async Task<ResponseDto<string>> HandleCommand(CreateCodeRandomCorrelativeCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<string>();
            CodigoLoteControlDto controlDto = new CodigoLoteControlDto();
            string numero = string.Empty;

            var control = await _loteCodigoControlRepository.GetByAsync(x => x.Activo == true);

            if (String.IsNullOrEmpty(control?.BloqueCodigo))
            {
                controlDto.cursor = 10000;
                controlDto.position = 0;
                controlDto.listNumeros = new int[0];
            }
            else
                controlDto = JsonConvert.DeserializeObject<CodigoLoteControlDto>(control.BloqueCodigo);

            if (controlDto != null)
            {
                if (!(controlDto.position < controlDto.listNumeros.ToList().Count))
                {
                    controlDto.listNumeros = generarListaNumeroAleatorios(controlDto.cursor);
                    controlDto.position = 0;
                    controlDto.cursor = controlDto.cursor + controlDto.listNumeros.ToList().Count;
                }

                numero = $"{controlDto.listNumeros.ToList()[controlDto.position]}";

                controlDto.position++;
                control.BloqueCodigo = JsonConvert.SerializeObject(controlDto);

                await _loteCodigoControlRepository.UpdateAsync(control);
                await _loteCodigoControlRepository.SaveAsync();

                var bytes = System.Text.Encoding.UTF8.GetBytes(numero);
                var encryp = Convert.ToBase64String(bytes);

                response.UpdateData(encryp);
            }

            return response;
        }

        private int[] generarListaNumeroAleatorios(int cursor)
        {
            var rand = new Random();
            int cantidad = rand.Next(CONST_ACOPIO.NUMERO_ALEATORIO.VALOR_INICIAL, CONST_ACOPIO.NUMERO_ALEATORIO.VALOR_FINAL);
            int[] arreglo = generaListInt(cantidad, cursor);
            int[] nuevoarreglo = new int[cantidad];

            for (int ctr = cantidad; ctr > 0; ctr--)
            {
                int aleatorio = rand.Next(0, ctr);
                int encontrado = arreglo[aleatorio];
                nuevoarreglo[cantidad - ctr] = encontrado;
                arreglo = arreglo.Where(val => val != encontrado).ToArray();
            }

            return nuevoarreglo;
        }

        private int[] generaListInt(int cantidad, int cursor)
        {
            int[] listInt = new int[cantidad];

            for (int ctr = 0; ctr < cantidad; ctr++)
                listInt[ctr] = cursor + ctr + 1;

            return listInt;
        }
    }
}
