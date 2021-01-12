using System.Collections.Generic;
using System.Threading.Tasks;
using TG.ConceptApp.Application.Foundation.Interfaces.Events;
using TG.ConceptApp.Application.Foundation.Interfaces.ServiceBus;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Events;

namespace TG.ConceptApp.Application.Foundation.Events
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IServiceBusMessagePublisher _serviceBusMessagePublisher;

        public EventPublisher(IEventDispatcher eventDispatcher,
                              IServiceBusMessagePublisher serviceBusMessagePublisher)
        {
            _eventDispatcher = eventDispatcher;
            _serviceBusMessagePublisher = serviceBusMessagePublisher;
        }

        public Task PublishDomainEventsAsync(IEnumerable<IEvent> events) =>
            _eventDispatcher.DispatchDomainEventsAsync(events);

        public Task PublishIntegrationEventsAsync(IEnumerable<IEvent> events) =>
            _serviceBusMessagePublisher.PublishAsync(events);
    }
}
