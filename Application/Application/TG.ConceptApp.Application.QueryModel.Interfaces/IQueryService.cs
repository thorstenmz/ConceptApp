using System.Collections.Generic;
using System.Threading.Tasks;
using TG.ConceptApp.Application.QueryModel.Entities;

namespace TG.ConceptApp.Application.QueryModel.Interfaces
{
    public interface IQueryService
    {
        Task<ReadonlyConcept> GetConceptById(int id);

        Task<IEnumerable<ReadonlyConcept>> GetAllConcepts();

        Task<IEnumerable<ReadonlyConcept>> GetConceptsBySuper(string super);
    }
}
