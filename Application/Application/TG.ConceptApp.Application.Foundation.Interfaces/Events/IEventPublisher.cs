using System.Collections.Generic;
using System.Threading.Tasks;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Events;

namespace TG.ConceptApp.Application.Foundation.Interfaces.Events
{
    public interface IEventPublisher
    {
        Task PublishDomainEventsAsync(IEnumerable<IEvent> events);

        Task PublishIntegrationEventsAsync(IEnumerable<IEvent> events);
    }
}
