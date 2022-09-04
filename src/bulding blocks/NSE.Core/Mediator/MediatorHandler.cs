using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using System.Threading.Tasks;

namespace NSE.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task<ValidationResult> SendCommand<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }
    }
}
