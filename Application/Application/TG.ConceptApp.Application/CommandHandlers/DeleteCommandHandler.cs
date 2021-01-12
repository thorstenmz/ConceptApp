using System.Threading.Tasks;
using TG.ConceptApp.Application.Commands;
using TG.ConceptApp.Application.Interfaces;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;

namespace TG.ConceptApp.Application.CommandHandlers
{
    public class DeleteCommandHandler : ICommandHandler<DeleteCommand>
    {
        private readonly IConceptRepository _conceptRepository;

        public DeleteCommandHandler(IConceptRepository conceptRepository) =>
            _conceptRepository = conceptRepository;

        public async Task ExecuteAsync(DeleteCommand command)
        {
            await _conceptRepository.DeleteAsync(command.ConceptId);
            await _conceptRepository.SaveChangesAsync();
        }
    }
}
