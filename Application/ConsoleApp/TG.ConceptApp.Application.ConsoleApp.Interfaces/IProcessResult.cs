namespace TG.ConceptApp.Application.ConsoleApp.Interfaces
{
    public interface IProcessResult
    {
        string Value { get; }

        string ErrorMessage { get; }

        bool IsError { get; }

        bool Continue { get; }

        bool HasValues { get; }
    }
}
