using System.Threading.Tasks;
using TG.ConceptApp.Application.Commands;
using TG.ConceptApp.Application.ConsoleApp.Interfaces;
using TG.ConceptApp.Application.ConsoleApp.Services.Helpers;
using TG.ConceptApp.Application.Foundation.Interfaces.Commands;

namespace TG.ConceptApp.Application.ConsoleApp.Services
{
    public class UpdateService : ICrudService
    {
        private readonly ICommandPublisher _commandDispatcher;

        public UpdateService(ICommandPublisher commandDispatcher) =>
            _commandDispatcher = commandDispatcher;

        public async Task<IProcessResult> ProcessAsync(string[] input)
        {
            int? id = null;
            string sub = null;

            for (int i = 1; i < input.Length - 1; i++)
            {
                if (input[i] == "-i" || input[i] == "--id")
                {
                    id = int.Parse(input[i + 1]);
                }

                if (input[i] == "-b" || input[i] == "--sub")
                {
                    sub = input[i + 1];
                }
            }

            UpdateCommand command = new UpdateCommand(id.Value, sub);
            await _commandDispatcher.PublishAsync(command);

            return ProcessResult.Success;
        }
    }
}
