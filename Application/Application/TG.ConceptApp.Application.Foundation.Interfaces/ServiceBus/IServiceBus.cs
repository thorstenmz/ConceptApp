using System;
using System.Threading.Tasks;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Messages;

namespace TG.ConceptApp.Application.Foundation.Interfaces.ServiceBus
{
    public interface IServiceBus
    {
        Task PublishAsync(IMessage message);

        Task PublishScheduledAsync(IMessage message, TimeSpan delay);

        void Subscribe(IServiceBusMessageDispatcher messageDispatcher);

        void Unsubscribe(IServiceBusMessageDispatcher messageDispatcher);
    }
}
