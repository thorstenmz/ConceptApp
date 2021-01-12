using TG.ConceptApp.Application.ConsoleApp.Interfaces;

namespace TG.ConceptApp.Application.ConsoleApp.Services.Helpers
{
    public class ProcessResult : IProcessResult
    {
        public static ProcessResult Success { get; } = new ProcessResult();

        public static ProcessResult Exit { get; } = new ProcessResult { Continue = false };

        public string Value { get; private set; }

        public string ErrorMessage { get; }

        public bool IsError { get; }

        public bool Continue { get; private set; } = true;

        public bool HasValues { get; private set; }

        private ProcessResult()
        {
        }

        private ProcessResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
            IsError = true;
        }

        public static ProcessResult Result(string value)
            => new ProcessResult { Value = value, HasValues = true };

        public static ProcessResult Error(string errorMessage)
            => new ProcessResult(errorMessage);
    }
}
