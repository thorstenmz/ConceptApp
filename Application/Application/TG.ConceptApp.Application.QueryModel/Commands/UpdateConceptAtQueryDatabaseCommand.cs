using TG.ConceptApp.Shared.Abstracts.Cqrs.Commands;

namespace TG.ConceptApp.Application.QueryModel.Commands
{
    public class UpdateConceptAtQueryDatabaseCommand : CommandBase
    {
        public int ConceptId { get; }

        public string Sub { get; }

        public UpdateConceptAtQueryDatabaseCommand(int conceptId, string sub) =>
            (ConceptId, Sub) = (conceptId, sub);
    }
}
