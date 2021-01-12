using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TG.ConceptApp.Application.Foundation.Interfaces.Commands;
using TG.ConceptApp.Application.Foundation.Interfaces.Events;
using TG.ConceptApp.Shared.Extensions;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Events;

namespace TG.ConceptApp.Application.Foundation.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly ReadOnlyDictionary<Type, IReadOnlyCollection<object>> _domainEventHandlers;
        private readonly ReadOnlyDictionary<Type, IReadOnlyCollection<object>> _integrationEventHandlers;
        private readonly ICommandPublisher _commandPublisher;

        public EventDispatcher(ReadOnlyDictionary<Type, IReadOnlyCollection<object>> domainEventHandlers,
                               ReadOnlyDictionary<Type, IReadOnlyCollection<object>> integrationEventHandlers,
                               ICommandPublisher commandPublisher)
        {
            _domainEventHandlers = domainEventHandlers;
            _integrationEventHandlers = integrationEventHandlers;
            _commandPublisher = commandPublisher;
        }

        public async Task DispatchDomainEventAsync(IEvent @event)
        {
            if (_domainEventHandlers.TryGetValue(@event.GetType(), out IReadOnlyCollection<object> handlers))
            {
                foreach (object handler in handlers)
                {
                    await ((dynamic)handler).HandleAsync(@event);
                }
            }
        }

        public async Task DispatchDomainEventsAsync(IEnumerable<IEvent> events) =>
            await events.ForEachAsync(@event => DispatchDomainEventAsync(@event));

        public async Task DispatchIntegrationEventAsync(IEvent @event)
        {
            if (_integrationEventHandlers.TryGetValue(@event.GetType(), out IReadOnlyCollection<object> handlers))
            {
                foreach (object handler in handlers)
                {
                    IEnumerable<ICommand> commands = ((dynamic)handler).DetermineCommandsToExecute((dynamic)@event);
                    await _commandPublisher.PublishAsync(commands);
                }
            }
        }

        public async Task DispatchIntegrationEventsAsync(IEnumerable<IEvent> events) =>
            await events.ForEachAsync(EventArgs => DispatchIntegrationEventAsync(EventArgs));
    }
}
