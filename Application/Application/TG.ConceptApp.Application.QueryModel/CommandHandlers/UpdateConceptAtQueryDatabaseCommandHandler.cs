using System.Threading.Tasks;
using TG.ConceptApp.Application.QueryModel.Commands;
using TG.ConceptApp.Application.QueryModel.Interfaces;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;

namespace TG.ConceptApp.Application.QueryModel.CommandHandlers
{
    public class UpdateConceptAtQueryDatabaseCommandHandler : ICommandHandler<UpdateConceptAtQueryDatabaseCommand>
    {
        private readonly ISyncService _syncService;

        public UpdateConceptAtQueryDatabaseCommandHandler(ISyncService syncService) =>
            _syncService = syncService;

        public async Task ExecuteAsync(UpdateConceptAtQueryDatabaseCommand command)
        {
            await _syncService.UpdateConcept(command.ConceptId, command.Sub);
            await _syncService.SaveChangesAsync();
        }
    }
}
