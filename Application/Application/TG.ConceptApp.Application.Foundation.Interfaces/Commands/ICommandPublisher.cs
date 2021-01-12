using System.Collections.Generic;
using System.Threading.Tasks;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;

namespace TG.ConceptApp.Application.Foundation.Interfaces.Commands
{
    public interface ICommandPublisher
    {
        Task PublishAsync(ICommand command);

        Task PublishAsync(IEnumerable<ICommand> commands);
    }
}
