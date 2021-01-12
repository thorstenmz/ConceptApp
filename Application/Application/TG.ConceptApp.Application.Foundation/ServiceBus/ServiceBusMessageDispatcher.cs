using System;
using System.Threading.Tasks;
using TG.ConceptApp.Application.Foundation.Interfaces.Commands;
using TG.ConceptApp.Application.Foundation.Interfaces.Events;
using TG.ConceptApp.Application.Foundation.Interfaces.ServiceBus;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Events;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Messages;

namespace TG.ConceptApp.Application.Foundation.ServiceBus
{
    public class ServiceBusMessageDispatcher : IServiceBusMessageDispatcher
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IEventDispatcher _eventDispatcher;

        public ServiceBusMessageDispatcher(ICommandDispatcher commandDispatcher, IEventDispatcher eventDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _eventDispatcher = eventDispatcher;
        }

        public async Task DispatchAsync(IMessage message)
        {
            if (message is ICommand command)
            {
                await _commandDispatcher.DispatchAsync(command);
            }
            else if (message is IEvent @event)
            {
                await _eventDispatcher.DispatchIntegrationEventAsync(@event);
            }
            else
            {
                throw new InvalidOperationException("Message is neither command nor event.");
            }
        }
    }
}
