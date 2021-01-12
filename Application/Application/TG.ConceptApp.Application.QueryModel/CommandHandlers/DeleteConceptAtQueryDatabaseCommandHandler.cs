using System.Threading.Tasks;
using TG.ConceptApp.Application.QueryModel.Commands;
using TG.ConceptApp.Application.QueryModel.Interfaces;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;

namespace TG.ConceptApp.Application.QueryModel.CommandHandlers
{
    public class DeleteConceptAtQueryDatabaseCommandHandler : ICommandHandler<DeleteConceptAtQueryDatabaseCommand>
    {
        private readonly ISyncService _syncService;

        public DeleteConceptAtQueryDatabaseCommandHandler(ISyncService syncService) =>
            _syncService = syncService;

        public async Task ExecuteAsync(DeleteConceptAtQueryDatabaseCommand command)
        {
            await _syncService.DeleteConcept(command.ConceptId);
            await _syncService.SaveChangesAsync();
        }
    }
}
