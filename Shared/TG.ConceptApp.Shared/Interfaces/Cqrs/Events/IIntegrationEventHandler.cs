using System.Collections.Generic;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;

namespace TG.ConceptApp.Shared.Interfaces.Cqrs.Events
{
    public interface IIntegrationEventHandler<in TEvt> where TEvt : IEvent
    {
        IEnumerable<ICommand> DetermineCommandsToExecute(TEvt @event);
    }
}
