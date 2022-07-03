using MediatR;
using Paltarumi.Acopio.Dto.Base;

namespace Paltarumi.Acopio.Domain.Queries.Base
{
    public class QueryBase : IRequest<ResponseDto>
    {

    }

    public class QueryBase<TResponse> : IRequest<ResponseDto<TResponse>>
    {

    }
}
