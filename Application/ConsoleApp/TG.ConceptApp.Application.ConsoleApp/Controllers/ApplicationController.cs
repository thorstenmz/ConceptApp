using System;
using System.Threading.Tasks;
using TG.ConceptApp.Application.ConsoleApp.Interfaces;
using TG.ConceptApp.Application.ConsoleApp.Services.Helpers;

namespace TG.ConceptApp.Application.ConsoleApp.Controllers
{
    public class ApplicationController : IApplicationController
    {
        private IUserInterface _userInterface;
        private ICrudService _createService;
        private ICrudService _readService;
        private ICrudService _updateService;
        private ICrudService _deleteService;

        public ApplicationController(IUserInterface userInterface,
                                     ICrudService createService,
                                     ICrudService readService,
                                     ICrudService updateService,
                                     ICrudService deleteService)
        {
            _userInterface = userInterface;
            _createService = createService;
            _readService = readService;
            _updateService = updateService;
            _deleteService = deleteService;
        }

        public async Task RunAsync()
        {
            IProcessResult processResult;

            do
            {
                string input = _userInterface.GetInput();
                processResult = await ProcessAsync(input);

                if (processResult.IsError)
                {
                    _userInterface.DisplayOutput(processResult.ErrorMessage);
                }
                else if (processResult.HasValues)
                {
                    _userInterface.DisplayOutput(processResult.Value);
                }
            }
            while (processResult.Continue);
        }

        private async Task<IProcessResult> ProcessAsync(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return ProcessResult.Success;

            try
            {
                string[] parts = input.Trim().Split(' ');

                return (parts[0]) switch
                {
                    "c" or "create" => await _createService.ProcessAsync(parts),
                    "r" or "read" => await _readService.ProcessAsync(parts),
                    "u" or "update" => await _updateService.ProcessAsync(parts),
                    "d" or "delete" => await _deleteService.ProcessAsync(parts),
                    "e" or "x" or "exit" or "q" or "quit" => ProcessResult.Exit,
                    _ => ProcessResult.Error("? Syntax Error"),
                };
            }
            catch (Exception exception)
            {
                string message = exception.Message;
                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                    message = $"{message} {exception.Message}";
                }
                return ProcessResult.Error($"? Error: {message}");
            }
        }
    }
}
