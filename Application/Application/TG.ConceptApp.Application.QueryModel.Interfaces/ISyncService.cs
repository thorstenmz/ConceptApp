using System.Threading.Tasks;

namespace TG.ConceptApp.Application.QueryModel.Interfaces
{
    public interface ISyncService
    {
        Task CreateConcept(int id, string super, string sub);

        Task UpdateConcept(int id, string sub);

        Task DeleteConcept(int id);

        Task SaveChangesAsync();
    }
}
