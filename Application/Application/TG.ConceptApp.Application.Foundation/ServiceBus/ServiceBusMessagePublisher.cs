using System.Collections.Generic;
using System.Threading.Tasks;
using TG.ConceptApp.Application.Foundation.Interfaces.ServiceBus;
using TG.ConceptApp.Shared.Extensions;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Messages;

namespace TG.ConceptApp.Application.Foundation.ServiceBus
{
    public class ServiceBusMessagePublisher : IServiceBusMessagePublisher
    {
        private readonly IServiceBus _serviceBus;

        public ServiceBusMessagePublisher(IServiceBus serviceBus)
            => _serviceBus = serviceBus;

        public Task PublishAsync(IMessage message)
            => _serviceBus.PublishAsync(message);

        public Task PublishAsync(IEnumerable<IMessage> messages)
            => messages.ForEachAsync(message => _serviceBus.PublishAsync(message));
    }
}
