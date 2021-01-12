using System.Threading.Tasks;

namespace TG.ConceptApp.Infrastructure.ServiceBus.Interfaces
{
    public interface IMessageReceiver
    {
        Task ReceiveAsync(object message);
    }
}