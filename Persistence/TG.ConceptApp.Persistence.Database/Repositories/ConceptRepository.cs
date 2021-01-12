using System.Threading.Tasks;
using TG.ConceptApp.Application.Foundation.Interfaces.Events;
using TG.ConceptApp.Application.Interfaces;
using TG.ConceptApp.Domain.Concept.Entities;
using TG.ConceptApp.Persistence.Database.Infrastructure;

namespace TG.ConceptApp.Persistence.Database.Repositories
{
    public class ConceptRepository : RepositoryContextBase<Concept>, IConceptRepository
    {
        public ConceptRepository(ConceptContext conceptContext, IEventPublisher eventPublisher)
            : base(conceptContext, eventPublisher) { }

        public async Task<Concept> GetByIdAsync(int id) =>
            await _dbContext.FindAsync<Concept>(id);

        public async Task AddAsync(Concept concept) =>
            await _dbContext.AddAsync(concept);

        public async Task DeleteAsync(int id) =>
            await _dbContext.SoftDelete(id);
    }
}
