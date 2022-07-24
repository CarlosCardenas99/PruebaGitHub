using Newtonsoft.Json;
using Paltarumi.Acopio.Balanza.Domain.Commands.Base;
using Paltarumi.Acopio.Balanza.Dto.Balanza.LoteCodigo;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Base;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Balanza.Domain.Commands.Common
{
    public class CreateCodeRandomCorrelativeCommandHandler : CommandHandlerBase<CreateCodeRandomCorrelativeCommand, string>
    {

        private readonly IRepository<Entity.LoteCodigoControl> _loteCodigoControlRepository;
    
        public CreateCodeRandomCorrelativeCommandHandler(
            IUnitOfWork unitOfWork,
            IRepository<Entity.LoteCodigoControl> loteCodigoControlRepository
        ) : base(unitOfWork)
        {
            _loteCodigoControlRepository = loteCodigoControlRepository;
        }

        public override async Task<ResponseDto<string>> HandleCommand(CreateCodeRandomCorrelativeCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseDto<string>();

            var control = await _loteCodigoControlRepository.GetByAsync(x => x.Activo == true );

            CodigoLoteControlDto controlDto = new CodigoLoteControlDto();
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
                if (controlDto.position < controlDto.listNumeros.ToList().Count)
                {
                    var numero = $"{controlDto.listNumeros.ToList()[controlDto.position]}";
                    controlDto.position++;
                    response.UpdateData(numero);
                }
                else
                {
                    controlDto.listNumeros = generarListaNumeroAleatorios(controlDto.cursor);
                    controlDto.position = 0;
                    controlDto.cursor = controlDto.cursor + controlDto.listNumeros.ToList().Count;
                }
                control.BloqueCodigo = JsonConvert.SerializeObject(controlDto);
                await _loteCodigoControlRepository.UpdateAsync(control);
                await _loteCodigoControlRepository.SaveAsync();
            }
            else
                response.AddErrorResult("Error no se obtuvo CodigoLoteControl");

            return response;
        }

        private int[] generarListaNumeroAleatorios(int cursor)
        {
            var rand = new Random();
            int cantidad = rand.Next(20, 30);
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
