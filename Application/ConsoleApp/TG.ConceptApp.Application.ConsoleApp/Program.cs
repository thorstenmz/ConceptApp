using System.Threading.Tasks;
using TG.ConceptApp.Application.ConsoleApp.DependencyInjection;

namespace TG.ConceptApp.Application.ConsoleApp
{
    public static class Program
    {
        public static async Task Main() =>
            await new ConsoleAppDependencyInjection()
                .Build()
                .ApplicationController
                .RunAsync();
    }
}
