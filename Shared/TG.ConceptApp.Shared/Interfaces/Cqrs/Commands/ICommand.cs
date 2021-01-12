using TG.ConceptApp.Shared.Interfaces.Cqrs.Messages;

namespace TG.ConceptApp.Shared.Interfaces.Cqrs.Commands
{
    public interface ICommand : IMessage
    {
        bool PublishToServiceBus { get; }
    }
}
