using System.Collections.Generic;
using TG.ConceptApp.Application.QueryModel.Commands;
using TG.ConceptApp.Domain.Concept.Events;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Events;

namespace TG.ConceptApp.Application.QueryModel.EventHandlers
{
    public class ConceptDeletedEventHandler : IIntegrationEventHandler<ConceptDeletedEvent>
    {
        public IEnumerable<ICommand> DetermineCommandsToExecute(ConceptDeletedEvent @event)
        {
            yield return new DeleteConceptAtQueryDatabaseCommand(@event.ConceptId);
        }
    }
}
