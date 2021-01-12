using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TG.ConceptApp.Application.QueryModel.Entities;
using TG.ConceptApp.Persistence.QueryDatabase.Infrastructure;

namespace TG.ConceptApp.Persistence.QueryDatabase.Repositories
{
    public class ConceptQueryRepository
    {
        private readonly ConceptQueryContext _database;

        public ConceptQueryRepository(ConceptQueryContext database)
        {
            //DbContextExtensions.WipeCreateSeed(true);
            _database = database;
        }

        public async Task TestConnection()
            => await _database.TestConnection();

        public async Task<ReadonlyConcept> GetConceptById(int id) =>
            await _database
                .ReadonlyConcepts
                .SingleOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<ReadonlyConcept>> GetAllConcepts() =>
            await _database
                .ReadonlyConcepts
                .ToListAsync();

        public async Task<IEnumerable<ReadonlyConcept>> GetConceptsBySuper(string super) =>
            await _database
                .ReadonlyConcepts
                .Where(c => c.Super == super)
                .ToListAsync();
    }
}
