using System.Collections.Generic;
using TG.ConceptApp.Application.QueryModel.Commands;
using TG.ConceptApp.Domain.Concept.Events;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Events;

namespace TG.ConceptApp.Application.QueryModel.EventHandlers
{
    public class ConceptCreatedEventHandler : IIntegrationEventHandler<ConceptCreatedEvent>
    {
        public IEnumerable<ICommand> DetermineCommandsToExecute(ConceptCreatedEvent @event)
        {
            yield return new CreateConceptAtQueryDatabaseCommand(@event.ConceptId, @event.Super, @event.Sub);
        }
    }
}
