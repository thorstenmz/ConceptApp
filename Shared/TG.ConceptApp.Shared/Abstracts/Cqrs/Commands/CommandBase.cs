using TG.ConceptApp.Shared.Abstracts.Cqrs.Messages;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;

namespace TG.ConceptApp.Shared.Abstracts.Cqrs.Commands
{
    public abstract class CommandBase : MessageBase, ICommand
    {
        public bool PublishToServiceBus { get; set; }
    }
}
