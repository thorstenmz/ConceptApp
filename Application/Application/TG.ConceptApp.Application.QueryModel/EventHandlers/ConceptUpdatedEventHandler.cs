using System.Collections.Generic;
using TG.ConceptApp.Application.QueryModel.Commands;
using TG.ConceptApp.Domain.Concept.Events;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Events;

namespace TG.ConceptApp.Application.QueryModel.EventHandlers
{
    public class ConceptUpdatedEventHandler : IIntegrationEventHandler<ConceptUpdatedEvent>
    {
        public IEnumerable<ICommand> DetermineCommandsToExecute(ConceptUpdatedEvent @event)
        {
            yield return new UpdateConceptAtQueryDatabaseCommand(@event.ConceptId, @event.Sub);
        }
    }
}
