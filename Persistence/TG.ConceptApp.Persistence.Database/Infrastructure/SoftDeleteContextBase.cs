using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TG.ConceptApp.Shared.Interfaces.Entities;

namespace TG.ConceptApp.Persistence.Database.Infrastructure
{
    public abstract class SoftDeleteContextBase<T> : DbContext where T : class, ISoftDeletable
    {
        public async Task SoftDelete(int id)
        {
            T entity = await FindAsync<T>(id);
            entity.Delete();
        }
    }
}
