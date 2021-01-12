using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TG.ConceptApp.Application.Foundation.Interfaces.Commands;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;

namespace TG.ConceptApp.Application.Foundation.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ReadOnlyDictionary<Type, object> _commandHandlers;

        public CommandDispatcher(ReadOnlyDictionary<Type, object> commandHandlers) =>
            _commandHandlers = commandHandlers;

        public async Task DispatchAsync(ICommand command)
        {
            if (_commandHandlers.TryGetValue(command.GetType(), out object commandHandler))
            {
                await ((dynamic)commandHandler).ExecuteAsync((dynamic)command);
            }
            else
            {
                throw new InvalidOperationException($"CommandHandler for {command.GetType()} not found.");
            }
        }
    }
}
