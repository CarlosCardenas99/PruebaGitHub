using AutoMapper;
using MediatR;
using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Balanza.Application.Base
{
    public class ApplicationBase
    {
        protected readonly IMapper? _mapper;
        protected readonly IMediator _mediator;
        protected readonly IUnitOfWork? _unitOfWork;

        public ApplicationBase(IMediator mediator)
            => _mediator = mediator;

        public ApplicationBase(IMediator mediator, IMapper mapper) : this(mediator)
            => _mapper = mapper;

        public ApplicationBase(IMediator mediator, IMapper mapper, IUnitOfWork unitOfWork) : this(mediator, mapper)
            => _unitOfWork = unitOfWork;
    }
}
