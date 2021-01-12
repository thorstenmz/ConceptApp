using System.Collections.Generic;
using System.Threading.Tasks;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Messages;

namespace TG.ConceptApp.Application.Foundation.Interfaces.ServiceBus
{
    public interface IServiceBusMessagePublisher
    {
        Task PublishAsync(IMessage message);

        Task PublishAsync(IEnumerable<IMessage> messages);
    }
}
