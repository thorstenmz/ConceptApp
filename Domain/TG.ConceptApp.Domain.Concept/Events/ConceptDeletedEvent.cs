using TG.ConceptApp.Shared.Abstracts.Cqrs.Events;

namespace TG.ConceptApp.Domain.Concept.Events
{
    public class ConceptDeletedEvent : EventBase
    {
        public int ConceptId { get; private set; }

        public ConceptDeletedEvent(int conceptId)
        {
            ConceptId = conceptId;
        }
    }
}
