using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hangfire;
using TG.ConceptApp.Application.Foundation.Interfaces.ServiceBus;
using TG.ConceptApp.Shared.Extensions;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Messages;

namespace TG.ConceptApp.Infrastructure.ServiceBus
{
    public class HangfireServiceBus : IServiceBus
    {
        private readonly List<IServiceBusMessageDispatcher> _messageDispatchers
            = new List<IServiceBusMessageDispatcher>();

        public async Task PublishAsync(IMessage message)
            => BackgroundJob.Enqueue(() => DispatchAsync(message));

        public async Task PublishScheduledAsync(IMessage message, TimeSpan delay)
            => BackgroundJob.Schedule(() => DispatchAsync(message), delay);

        public void Subscribe(IServiceBusMessageDispatcher messageDispatcher)
            => _messageDispatchers.Add(messageDispatcher);

        public void Unsubscribe(IServiceBusMessageDispatcher messageDispatcher)
            => _messageDispatchers.Remove(messageDispatcher);

        private async Task DispatchAsync(IMessage message)
            => await _messageDispatchers.ForEachAsync(messageDispatcher => messageDispatcher.DispatchAsync(message));
    }
}
