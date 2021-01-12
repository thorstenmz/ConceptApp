using TG.ConceptApp.Domain.Concept.Events;
using TG.ConceptApp.Shared.Abstracts.Entities;

namespace TG.ConceptApp.Domain.Concept.Entities
{
    public class Concept : EntityBase
    {
        public string Super { get; private set; }

        public string Sub { get; private set; }

        // Needed by EF Core.
        private Concept() // ???
        {
        }

        private Concept(string super, string sub) // ???
        {
            Super = super;
            Sub = sub;
        }

        public static Concept Create(string super, string sub) // ???
        {
            Concept concept = new Concept(super, sub);
            concept.ApplyChange(new ConceptCreatedEvent(super, sub));
            return concept;
        }

        public void UpdateSub(string sub)
        {
            if (Sub != sub)
            {
                Sub = sub;
                ApplyChange(new ConceptUpdatedEvent(Id, sub));
            }
        }

        protected override void OnDeleted() =>
            ApplyChange(new ConceptDeletedEvent(Id));
    }
}
