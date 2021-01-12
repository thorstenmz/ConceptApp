using TG.ConceptApp.Application.ConsoleApp.Interfaces;
using static System.Console;

namespace TG.ConceptApp.Presentation.ConsoleUI
{
    public class ConsoleUserInterface : IUserInterface
    {
        public string GetInput()
        {
            Write("> ");
            return ReadLine();
        }

        public void DisplayOutput(string message)
        {
            if (!string.IsNullOrEmpty(message))
                WriteLine(message);
        }
    }
}
