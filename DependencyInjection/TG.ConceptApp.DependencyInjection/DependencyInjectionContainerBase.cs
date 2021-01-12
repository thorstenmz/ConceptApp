using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Commands;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Events;

namespace TG.ConceptApp.DependencyInjection
{
    // TODO: Replace singletons to enable multithreading.
    // Use factory pattern!
    public abstract class DependencyInjectionContainerBase
    {
        private readonly Dictionary<Type, object> _implementations =
            new Dictionary<Type, object>();

        private readonly Dictionary<Type, object> _commandHandlers =
            new Dictionary<Type, object>();

        private readonly Dictionary<Type, List<object>> _domainEventHandlers =
            new Dictionary<Type, List<object>>();

        private readonly Dictionary<Type, List<object>> _integrationEventHandlers =
            new Dictionary<Type, List<object>>();

        protected ReadOnlyDictionary<Type, object> CommandHandlers =>
            new ReadOnlyDictionary<Type, object>(_commandHandlers);

        protected ReadOnlyDictionary<Type, IReadOnlyCollection<object>> DomainEventHandlers =>
            new ReadOnlyDictionary<Type, IReadOnlyCollection<object>>(
                _domainEventHandlers
                    .Select(kvp => new KeyValuePair<Type, IReadOnlyCollection<object>>(kvp.Key, new ReadOnlyCollection<object>(kvp.Value)))
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value));

        protected ReadOnlyDictionary<Type, IReadOnlyCollection<object>> IntegrationEventHandlers =>
            new ReadOnlyDictionary<Type, IReadOnlyCollection<object>>(
                _integrationEventHandlers
                    .Select(kvp => new KeyValuePair<Type, IReadOnlyCollection<object>>(kvp.Key, new ReadOnlyCollection<object>(kvp.Value)))
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value));

        public T Resolve<T>() =>
            _implementations.TryGetValue(typeof(T), out object implementation)
                ? (T)implementation
                : throw new InvalidOperationException($"Type {typeof(T)} not found.");

        protected void Register<T>(T instance) =>
            _implementations.Add(typeof(T), instance);

        protected void RegisterCommandHandler<TCmd, TCmdHndlr>(TCmdHndlr instance)
            where TCmd : ICommand
            where TCmdHndlr : ICommandHandler<TCmd> =>
            _commandHandlers.Add(typeof(TCmd), instance);

        protected void RegisterDomainEventHandler<TEvt, TEvtHndlr>(TEvtHndlr instance)
            where TEvt : IEvent
            where TEvtHndlr : IDomainEventHandler<TEvt>
        {
            if (!_domainEventHandlers.ContainsKey(typeof(TEvt)))
            {
                _domainEventHandlers[typeof(TEvt)] = new List<object>();
            }
            _domainEventHandlers[typeof(TEvt)].Add(instance);
        }

        protected void RegisterIntegrationEventHandler<TEvt, TEvtHndlr>(TEvtHndlr instance)
            where TEvt : IEvent
            where TEvtHndlr : IIntegrationEventHandler<TEvt>
        {
            if (!_integrationEventHandlers.ContainsKey(typeof(TEvt)))
            {
                _integrationEventHandlers[typeof(TEvt)] = new List<object>();
            }
            _integrationEventHandlers[typeof(TEvt)].Add(instance);
        }
    }
}
