using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TG.ConceptApp.Application.QueryModel.Entities;
using TG.ConceptApp.Application.QueryModel.Interfaces;
using TG.ConceptApp.Persistence.QueryDatabase.Infrastructure;

namespace TG.ConceptApp.Persistence.QueryDatabase.Services
{
    public class QueryService : IQueryService
    {
        private readonly ConceptQueryContext _queryDatabase;

        public QueryService(ConceptQueryContext queryDatabase) =>
            _queryDatabase = queryDatabase;

        public async Task<ReadonlyConcept> GetConceptById(int id) =>
            (await _queryDatabase
                .ReadonlyConcepts
                .FindAsync(id));

        public async Task<IEnumerable<ReadonlyConcept>> GetAllConcepts() =>
            await _queryDatabase
                .ReadonlyConcepts
                .Select(readonlyConcept => readonlyConcept)
                .ToListAsync();

        public async Task<IEnumerable<ReadonlyConcept>> GetConceptsBySuper(string super) =>
            await _queryDatabase
                .ReadonlyConcepts
                .Where(c => c.Super == super)
                .Select(readonlyConcept => readonlyConcept)
                .ToListAsync();
    }
}
