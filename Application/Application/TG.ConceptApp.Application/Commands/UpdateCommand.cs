using TG.ConceptApp.Shared.Abstracts.Cqrs.Commands;

namespace TG.ConceptApp.Application.Commands
{
    public class UpdateCommand : CommandBase
    {
        public int ConceptId { get; }

        public string Sub { get; }

        public UpdateCommand(int conceptId, string sub) =>
            (ConceptId, Sub) = (conceptId, sub);
    }
}
