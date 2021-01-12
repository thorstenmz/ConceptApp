using TG.ConceptApp.Shared.Abstracts.Cqrs.Messages;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Events;

namespace TG.ConceptApp.Shared.Abstracts.Cqrs.Events
{
    public abstract class EventBase : MessageBase, IEvent
    {
        public bool PublishToServiceBus { get; set; }
    }
}
