using TG.ConceptApp.Shared.Abstracts.Cqrs.Events;

namespace TG.ConceptApp.Domain.Concept.Events
{
    public class ConceptUpdatedEvent : EventBase
    {
        public int ConceptId { get; private set; }

        public string Sub { get; private set; }

        public ConceptUpdatedEvent(int conceptId, string sub)
        {
            ConceptId = conceptId;
            Sub = sub;
        }
    }
}
