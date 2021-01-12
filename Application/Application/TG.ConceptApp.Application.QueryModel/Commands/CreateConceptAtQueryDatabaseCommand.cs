using TG.ConceptApp.Shared.Abstracts.Cqrs.Commands;

namespace TG.ConceptApp.Application.QueryModel.Commands
{
    public class CreateConceptAtQueryDatabaseCommand : CommandBase
    {
        public int ConceptId { get; }

        public string Super { get; }

        public string Sub { get; }

        public CreateConceptAtQueryDatabaseCommand(int conceptId, string super, string sub) =>
            (ConceptId, Super, Sub) = (conceptId, super, sub);
    }
}
