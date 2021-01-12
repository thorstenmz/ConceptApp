using System.Collections.Generic;
using System.Threading.Tasks;
using TG.ConceptApp.Application.Foundation.Interfaces.ServiceBus;
using TG.ConceptApp.Shared.Extensions;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Messages;

namespace TG.ConceptApp.Development.Application.Foundation.ServiceBus
{
    public class DevelopmentServiceBusMessagePublisher : IServiceBusMessagePublisher
    {
        public IServiceBusMessageDispatcher _serviceBusMessageDispatcher;

        public DevelopmentServiceBusMessagePublisher(IServiceBusMessageDispatcher serviceBusMessageDispatcher)
        {
            _serviceBusMessageDispatcher = serviceBusMessageDispatcher;
        }

        public Task PublishAsync(IMessage message)
            => Task.Run(async () =>
            {
                await Task.Delay(1000);
                await _serviceBusMessageDispatcher.DispatchAsync(message);
            });

        public async Task PublishAsync(IEnumerable<IMessage> messages) =>
            await messages.ForEachAsync(message => PublishAsync(message));
    }
}
