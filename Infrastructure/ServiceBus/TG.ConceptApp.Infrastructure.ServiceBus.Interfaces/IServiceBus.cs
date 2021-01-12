using System;
using System.Threading.Tasks;

namespace TG.ConceptApp.Infrastructure.ServiceBus.Interfaces
{
    public interface IServiceBus
    {
        Task PublishAsync(object message);

        Task PublishScheduledAsync(object message, TimeSpan delay);

        void Subscribe(IMessageReceiver messageReceiver);

        void Unsubscribe(IMessageReceiver messageReceiver);
    }
}
