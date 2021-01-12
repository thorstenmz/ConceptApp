using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TG.ConceptApp.Application.Foundation.Interfaces.Events;
using TG.ConceptApp.Shared.Abstracts.Entities;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Events;

namespace TG.ConceptApp.Application.Foundation.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly IEventPublisher _eventPublisher;

        protected RepositoryBase(IEventPublisher eventPublisher) =>
            _eventPublisher = eventPublisher;

        protected abstract void Rollback();

        protected async Task SaveChangesAsync(List<EntityBase> entities,
                                              Func<Task> contextSaveChangesAsync)
        {
            List<IEvent> events = entities.SelectMany(entity => entity.Events).ToList();

            try
            {
                await _eventPublisher.PublishDomainEventsAsync(events);
                await contextSaveChangesAsync();
            }
            catch (Exception)
            {
                entities.ForEach(entity => entity.ClearEvents());
                Rollback();
                throw;
            }

            entities.ForEach(entity => entity
                .Events
                .OfType<INeedsGeneratedId>()
                .ToList()
                .ForEach(@event => @event.SetId(entity.Id)));

            await _eventPublisher.PublishIntegrationEventsAsync(events);

            entities.ForEach(entity => entity.ClearEvents());
        }
    }
}
