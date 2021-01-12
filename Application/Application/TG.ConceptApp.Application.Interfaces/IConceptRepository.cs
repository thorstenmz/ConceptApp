using System.Threading.Tasks;
using TG.ConceptApp.Domain.Concept.Entities;

namespace TG.ConceptApp.Application.Interfaces
{
    public interface IConceptRepository
    {
        Task<Concept> GetByIdAsync(int id);

        Task AddAsync(Concept concept);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}
