using System.Threading.Tasks;
using TG.ConceptApp.Application.QueryModel.Commands;
using TG.ConceptApp.Application.QueryModel.Interfaces;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;

namespace TG.ConceptApp.Application.QueryModel.CommandHandlers
{
    public class CreateConceptAtQueryDatabaseCommandHandler : ICommandHandler<CreateConceptAtQueryDatabaseCommand>
    {
        private readonly ISyncService _syncService;

        public CreateConceptAtQueryDatabaseCommandHandler(ISyncService syncService) =>
            _syncService = syncService;

        public async Task ExecuteAsync(CreateConceptAtQueryDatabaseCommand command)
        {
            await _syncService.CreateConcept(command.ConceptId, command.Super, command.Sub);
            await _syncService.SaveChangesAsync();
        }
    }
}
