using TG.ConceptApp.Shared.Abstracts.Cqrs.Events;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Events;

namespace TG.ConceptApp.Domain.Concept.Events
{
    public class ConceptCreatedEvent : EventBase, INeedsGeneratedId
    {
        public int ConceptId { get; private set; }

        public string Super { get; private set; }

        public string Sub { get; private set; }

        public ConceptCreatedEvent(string super, string sub)
        {
            Super = super;
            Sub = sub;
        }

        public void SetId(int id) =>
            ConceptId = id;
    }
}
