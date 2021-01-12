using System.Threading.Tasks;
using TG.ConceptApp.Application.Commands;
using TG.ConceptApp.Application.Interfaces;
using TG.ConceptApp.Domain.Concept.Entities;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;

namespace TG.ConceptApp.Application.CommandHandlers
{
    public class CreateCommandHandler : ICommandHandler<CreateCommand>
    {
        private readonly IConceptRepository _conceptRepository;

        public CreateCommandHandler(IConceptRepository conceptRepository) =>
            _conceptRepository = conceptRepository;

        public async Task ExecuteAsync(CreateCommand command)
        {
            Concept concept = Concept.Create(command.Super, command.Sub);
            await _conceptRepository.AddAsync(concept);
            await _conceptRepository.SaveChangesAsync();
        }
    }
}
