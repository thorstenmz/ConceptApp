using System.Threading.Tasks;

namespace TG.ConceptApp.Shared.Interfaces.Cqrs.Commands
{
    public interface ICommandHandler<in TCmd> where TCmd : ICommand
    {
        Task ExecuteAsync(TCmd command);
    }
}
