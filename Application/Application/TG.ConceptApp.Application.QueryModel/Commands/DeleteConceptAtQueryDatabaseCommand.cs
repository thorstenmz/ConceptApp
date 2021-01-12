using TG.ConceptApp.Shared.Abstracts.Cqrs.Commands;

namespace TG.ConceptApp.Application.QueryModel.Commands
{
    public class DeleteConceptAtQueryDatabaseCommand : CommandBase
    {
        public int ConceptId { get; }

        public DeleteConceptAtQueryDatabaseCommand(int conceptId) =>
            ConceptId = conceptId;
    }
}
