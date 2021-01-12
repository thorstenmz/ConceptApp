using System.Collections.Generic;
using System.Threading.Tasks;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Events;

namespace TG.ConceptApp.Application.Foundation.Interfaces.Events
{
    public interface IEventDispatcher
    {
        Task DispatchDomainEventAsync(IEvent @event);

        Task DispatchDomainEventsAsync(IEnumerable<IEvent> events);

        Task DispatchIntegrationEventAsync(IEvent @event);

        Task DispatchIntegrationEventsAsync(IEnumerable<IEvent> events);
    }
}
