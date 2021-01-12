using System;
using System.Collections.Generic;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Events;
using TG.ConceptApp.Shared.Interfaces.Entities;

namespace TG.ConceptApp.Shared.Abstracts.Entities
{
    public abstract class EntityBase : IAuditable, ISoftDeletable
    {
        private readonly List<IEvent> _events = new List<IEvent>();

        protected EntityBase()
        {
            DateTimeOffset timestamp = DateTimeOffset.Now;
            CreatedOn = timestamp;
            UpdatedOn = timestamp;
        }

        public int Id { get; protected set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset CreatedOn { get; protected set; }

        public string CreatedBy { get; protected set; }
            = "Test";

        public DateTimeOffset UpdatedOn { get; protected set; }

        public string UpdatedBy { get; protected set; }

        public IEnumerable<IEvent> Events =>
            _events;

        public void ClearEvents() =>
            _events.Clear();

        public void Delete()
        {
            if (!IsDeleted)
            {
                IsDeleted = true;
                OnDeleted();
            }
        }

        protected abstract void OnDeleted();

        protected void ApplyChange(IEvent @event) =>
            _events.Add(@event);
    }
}
