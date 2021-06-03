using DesafioFWK_Core.Commands;
using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;

namespace DesafioFWK_Core.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<ValidationResult> SendCommand<TCommand>(TCommand command) where TCommand : Command
        {
            return _mediator.Send(command);
        }
    }
}
