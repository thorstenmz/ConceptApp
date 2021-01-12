using System.Threading.Tasks;
using TG.ConceptApp.Application.Commands;
using TG.ConceptApp.Application.ConsoleApp.Interfaces;
using TG.ConceptApp.Application.ConsoleApp.Services.Helpers;
using TG.ConceptApp.Application.Foundation.Interfaces.Commands;

namespace TG.ConceptApp.Application.ConsoleApp.Services
{
    public class DeleteService : ICrudService
    {
        private readonly ICommandPublisher _commandDispatcher;

        public DeleteService(ICommandPublisher commandDispatcher) =>
            _commandDispatcher = commandDispatcher;

        public async Task<IProcessResult> ProcessAsync(string[] input)
        {
            for (int i = 1; i < input.Length - 1; i++)
            {
                if (input[i] == "-i" || input[i] == "--id")
                {
                    DeleteCommand command = new DeleteCommand(int.Parse(input[i + 1]));
                    await _commandDispatcher.PublishAsync(command);

                    return ProcessResult.Success;
                }
            }

            return ProcessResult.Error("? Syntax Error");
        }
    }
}
