using System.Threading.Tasks;
using TG.ConceptApp.Application.Commands;
using TG.ConceptApp.Application.Interfaces;
using TG.ConceptApp.Domain.Concept.Entities;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;

namespace TG.ConceptApp.Application.CommandHandlers
{
    public class UpdateCommandHandler : ICommandHandler<UpdateCommand>
    {
        private readonly IConceptRepository _conceptRepository;

        public UpdateCommandHandler(IConceptRepository conceptRepository) =>
            _conceptRepository = conceptRepository;

        public async Task ExecuteAsync(UpdateCommand command)
        {
            Concept concept = await _conceptRepository.GetByIdAsync(command.ConceptId);
            concept.UpdateSub(command.Sub);
            await _conceptRepository.SaveChangesAsync();
        }
    }
}
