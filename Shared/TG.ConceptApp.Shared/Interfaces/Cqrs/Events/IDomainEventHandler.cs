using System.Threading.Tasks;

namespace TG.ConceptApp.Shared.Interfaces.Cqrs.Events
{
    public interface IDomainEventHandler<in TEvt> where TEvt : IEvent
    {
        Task HandleAsync(TEvt @event);
    }
}
