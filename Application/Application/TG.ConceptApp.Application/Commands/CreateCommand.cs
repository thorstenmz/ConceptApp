using TG.ConceptApp.Shared.Abstracts.Cqrs.Commands;

namespace TG.ConceptApp.Application.Commands
{
    public class CreateCommand : CommandBase
    {
        public string Super { get; }

        public string Sub { get; }

        public CreateCommand(string super, string sub) =>
            (Super, Sub) = (super, sub);
    }
}
