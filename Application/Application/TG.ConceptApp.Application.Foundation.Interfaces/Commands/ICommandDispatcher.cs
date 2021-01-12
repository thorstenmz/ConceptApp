using System.Threading.Tasks;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;

namespace TG.ConceptApp.Application.Foundation.Interfaces.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync(ICommand command);
    }
}
