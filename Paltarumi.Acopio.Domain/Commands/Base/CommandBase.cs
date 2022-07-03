using MediatR;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Domain.Commands.Base
{
    public class CommandBase : IRequest<ResponseDto>
    {

    }

    public class CommandBase<TResponse> : IRequest<ResponseDto<TResponse>>
    {

    }
}
