using System.Threading.Tasks;
using TG.ConceptApp.Application.QueryModel.Interfaces;
using TG.ConceptApp.Persistence.QueryDatabase.Infrastructure;
using TG.ConceptApp.Application.QueryModel.Entities;

namespace TG.ConceptApp.Persistence.QueryDatabase.Services
{
    public class SyncService : ISyncService
    {
        private readonly ConceptQueryContext _queryDatabase;

        public SyncService(ConceptQueryContext queryDatabase) =>
            _queryDatabase = queryDatabase;

        public async Task CreateConcept(int id, string super, string sub) =>
            await _queryDatabase.AddAsync(new ReadonlyConcept(id, super, sub));

        public async Task UpdateConcept(int id, string sub)
        {
            ReadonlyConcept readonlyConcept = await _queryDatabase.FindAsync<ReadonlyConcept>(id);
            readonlyConcept.Sub = sub;
            _queryDatabase.Update(readonlyConcept);
        }

        public async Task DeleteConcept(int id)
        {
            ReadonlyConcept readonlyConcept = await _queryDatabase.FindAsync<ReadonlyConcept>(id);
            _queryDatabase.Remove(readonlyConcept);
        }

        public async Task SaveChangesAsync() =>
            await _queryDatabase.SaveChangesAsync();
    }
}
