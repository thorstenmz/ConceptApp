using TG.ConceptApp.Application.ConsoleApp.Controllers;
using TG.ConceptApp.Application.ConsoleApp.Interfaces;
using TG.ConceptApp.Application.ConsoleApp.Services;
using TG.ConceptApp.Application.Foundation.Interfaces.Commands;
using TG.ConceptApp.Application.QueryModel.Interfaces;
using TG.ConceptApp.DependencyInjection;

namespace TG.ConceptApp.Application.ConsoleApp.DependencyInjection
{
    public class ConsoleAppDependencyInjection : DependencyInjectionContainer
    {
        public override DependencyInjectionContainer Build()
        {
            base.Build().WithConsoleUI();

            ApplicationController =
                new ApplicationController(
                    Resolve<IUserInterface>(),
                    new CreateService(
                        Resolve<ICommandPublisher>()),
                    new ReadService(
                        Resolve<IQueryService>()),
                    new UpdateService(
                        Resolve<ICommandPublisher>()),
                    new DeleteService(
                        Resolve<ICommandPublisher>()));

            return this;
        }
    }
}
