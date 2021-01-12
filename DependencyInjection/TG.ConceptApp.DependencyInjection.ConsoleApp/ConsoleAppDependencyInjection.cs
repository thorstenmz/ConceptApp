using TG.Application.QueryModel.Interfaces;
using TG.Common.Interfaces.Cqrs.Commands;
using TG.ConsoleApp.Interfaces;
using TG.ConsoleApp.Services;
using TG.DependencyInjection;

namespace TG.ConceptApp.DependencyInjection.ConsoleApp
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
