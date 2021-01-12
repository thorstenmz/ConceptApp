using TG.ConceptApp.Application.CommandHandlers;
using TG.ConceptApp.Application.Commands;
using TG.ConceptApp.Application.ConsoleApp.Interfaces;
using TG.ConceptApp.Application.Foundation.Commands;
using TG.ConceptApp.Application.Foundation.Events;
using TG.ConceptApp.Application.Foundation.Interfaces.Commands;
using TG.ConceptApp.Application.Foundation.Interfaces.Events;
using TG.ConceptApp.Application.Foundation.Interfaces.ServiceBus;
using TG.ConceptApp.Application.Foundation.ServiceBus;
using TG.ConceptApp.Application.Interfaces;
using TG.ConceptApp.Application.QueryModel.CommandHandlers;
using TG.ConceptApp.Application.QueryModel.Commands;
using TG.ConceptApp.Application.QueryModel.EventHandlers;
using TG.ConceptApp.Application.QueryModel.Interfaces;
using TG.ConceptApp.Development.Application.Foundation.ServiceBus;
using TG.ConceptApp.Domain.Concept.Events;
using TG.ConceptApp.Persistence.Database.Infrastructure;
using TG.ConceptApp.Persistence.Database.Repositories;
using TG.ConceptApp.Persistence.QueryDatabase.Infrastructure;
using TG.ConceptApp.Persistence.QueryDatabase.Repositories;
using TG.ConceptApp.Persistence.QueryDatabase.Services;
using TG.ConceptApp.Presentation.ConsoleUI;

namespace TG.ConceptApp.DependencyInjection
{
    public class DependencyInjectionContainer : DependencyInjectionContainerBase
    {
        public IApplicationController ApplicationController { get; protected set; }

        public virtual DependencyInjectionContainer Build()
        {
            RegisterContexts();

            RegisterDomainServices();

            RegisterEventHandlers();

            RegisterCommonObjects();

            RegisterRepositories();

            RegisterCommandHandlers();

            return this;
        }

        public virtual void WithConsoleUI()
        {
            Register<IUserInterface>(
                new ConsoleUserInterface());
        }

        private void RegisterContexts()
        {
            Register(new ConceptContext());

            Register(new ConceptQueryContext());
        }

        private void RegisterDomainServices()
        {
            Register<ISyncService>(
                new SyncService(
                    Resolve<ConceptQueryContext>()));

            Register<IQueryService>(
                new QueryService(
                    Resolve<ConceptQueryContext>()));
        }

        private void RegisterEventHandlers()
        {
            RegisterIntegrationEventHandler<ConceptCreatedEvent, ConceptCreatedEventHandler>(
                new ConceptCreatedEventHandler());

            RegisterIntegrationEventHandler<ConceptUpdatedEvent, ConceptUpdatedEventHandler>(
                new ConceptUpdatedEventHandler());

            RegisterIntegrationEventHandler<ConceptDeletedEvent, ConceptDeletedEventHandler>(
                new ConceptDeletedEventHandler());
        }

        private void RegisterCommonObjects()
        {
            DevelopmentServiceBusMessagePublisher dev = new DevelopmentServiceBusMessagePublisher(null);

            Register<IServiceBusMessagePublisher>(dev);

            Register<ICommandDispatcher>(
                new CommandDispatcher(CommandHandlers));

            Register<ICommandPublisher>(
                new CommandPublisher(
                    Resolve<ICommandDispatcher>(),
                    Resolve<IServiceBusMessagePublisher>()));

            Register<IEventDispatcher>(
                new EventDispatcher(
                    DomainEventHandlers,
                    IntegrationEventHandlers,
                    Resolve<ICommandPublisher>()));

            Register<IServiceBusMessageDispatcher>(
                new ServiceBusMessageDispatcher(
                    Resolve<ICommandDispatcher>(),
                    Resolve<IEventDispatcher>()));

            Register<IEventPublisher>(
                new EventPublisher(
                    Resolve<IEventDispatcher>(),
                    Resolve<IServiceBusMessagePublisher>()));

            dev._serviceBusMessageDispatcher = Resolve<IServiceBusMessageDispatcher>();
        }

        private void RegisterRepositories()
        {
            Register<IConceptRepository>(
                new ConceptRepository(
                    Resolve<ConceptContext>(),
                    Resolve<IEventPublisher>()));

            Register(
                new ConceptQueryRepository(
                    Resolve<ConceptQueryContext>()));
        }

        private void RegisterCommandHandlers()
        {
            RegisterCommandHandler<CreateCommand, CreateCommandHandler>(
                new CreateCommandHandler(
                    Resolve<IConceptRepository>()));

            RegisterCommandHandler<UpdateCommand, UpdateCommandHandler>(
                new UpdateCommandHandler(
                    Resolve<IConceptRepository>()));

            RegisterCommandHandler<DeleteCommand, DeleteCommandHandler>(
                new DeleteCommandHandler(
                    Resolve<IConceptRepository>()));

            RegisterCommandHandler<CreateConceptAtQueryDatabaseCommand, CreateConceptAtQueryDatabaseCommandHandler>(
                new CreateConceptAtQueryDatabaseCommandHandler(
                    Resolve<ISyncService>()));

            RegisterCommandHandler<UpdateConceptAtQueryDatabaseCommand, UpdateConceptAtQueryDatabaseCommandHandler>(
                new UpdateConceptAtQueryDatabaseCommandHandler(
                    Resolve<ISyncService>()));

            RegisterCommandHandler<DeleteConceptAtQueryDatabaseCommand, DeleteConceptAtQueryDatabaseCommandHandler>(
                new DeleteConceptAtQueryDatabaseCommandHandler(
                    Resolve<ISyncService>()));
        }
    }
}
