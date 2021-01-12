using TG.ConceptApp.Shared.Abstracts.Cqrs.Commands;

namespace TG.ConceptApp.Application.Commands
{
    public class DeleteCommand : CommandBase
    {
        public int ConceptId { get; }

        public DeleteCommand(int conceptId) =>
            ConceptId = conceptId;
    }
}
