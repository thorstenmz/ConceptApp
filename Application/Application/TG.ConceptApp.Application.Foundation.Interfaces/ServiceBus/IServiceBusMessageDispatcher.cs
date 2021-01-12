using System.Threading.Tasks;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Messages;

namespace TG.ConceptApp.Application.Foundation.Interfaces.ServiceBus
{
    public interface IServiceBusMessageDispatcher
    {
        Task DispatchAsync(IMessage message);
    }
}
