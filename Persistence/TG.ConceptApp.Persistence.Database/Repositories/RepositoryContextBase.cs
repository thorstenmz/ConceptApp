using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TG.ConceptApp.Application.Foundation.Interfaces.Events;
using TG.ConceptApp.Application.Foundation.Repositories;
using TG.ConceptApp.Persistence.Database.Infrastructure;
using TG.ConceptApp.Shared.Abstracts.Entities;
using TG.ConceptApp.Shared.Interfaces.Entities;

namespace TG.ConceptApp.Persistence.Database.Repositories
{
    public abstract class RepositoryContextBase<T> : RepositoryBase where T : class, ISoftDeletable
    {
        protected readonly SoftDeleteContextBase<T> _dbContext;

        public RepositoryContextBase(SoftDeleteContextBase<T> dbContext, IEventPublisher eventPublisher)
            : base(eventPublisher) =>
            _dbContext = dbContext;

        public async Task SaveChangesAsync()
        {
            List<EntityBase> entities = _dbContext
                .ChangeTracker
                .Entries<EntityBase>()
                .Where(e =>
                    e.State == EntityState.Added ||
                    e.State == EntityState.Modified ||
                    e.State == EntityState.Deleted)
                .Select(e => e.Entity)
                .ToList();

            await SaveChangesAsync(
                entities,
                () => _dbContext.SaveChangesAsync());
        }

        protected override void Rollback()
        {
            _dbContext
                .ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added)
                .ToList()
                .ForEach(entry => entry.State = EntityState.Detached);

            _dbContext
                .ChangeTracker
                .Entries()
                .Where(e =>
                    e.State != EntityState.Unchanged &&
                    e.State != EntityState.Detached)
                .ToList()
                .ForEach(entry => entry.State = EntityState.Unchanged);
        }
    }
}
