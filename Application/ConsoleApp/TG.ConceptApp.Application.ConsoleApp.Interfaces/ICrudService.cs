using System.Threading.Tasks;

namespace TG.ConceptApp.Application.ConsoleApp.Interfaces
{
    public interface ICrudService
    {
        Task<IProcessResult> ProcessAsync(string[] input);
    }
}
