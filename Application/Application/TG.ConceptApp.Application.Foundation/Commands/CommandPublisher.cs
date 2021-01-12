using System.Collections.Generic;
using System.Threading.Tasks;
using TG.ConceptApp.Application.Foundation.Interfaces.Commands;
using TG.ConceptApp.Application.Foundation.Interfaces.ServiceBus;
using TG.ConceptApp.Shared.Extensions;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;

namespace TG.ConceptApp.Application.Foundation.Commands
{
    public class CommandPublisher : ICommandPublisher
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IServiceBusMessagePublisher _serviceBusMessagePublisher;

        public CommandPublisher(ICommandDispatcher commandDispatcher,
                                IServiceBusMessagePublisher serviceBusMessagePublisher)
        {
            _commandDispatcher = commandDispatcher;
            _serviceBusMessagePublisher = serviceBusMessagePublisher;
        }

        public Task PublishAsync(ICommand command) =>
            command.PublishToServiceBus
                ? _serviceBusMessagePublisher.PublishAsync(command)
                : _commandDispatcher.DispatchAsync(command);

        public Task PublishAsync(IEnumerable<ICommand> commands)
            => commands.ForEachAsync(command => PublishAsync(command));
    }
}
