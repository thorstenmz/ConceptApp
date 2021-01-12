using System;
using TG.ConceptApp.Shared.Interfaces.Cqrs.Messages;

namespace TG.ConceptApp.Shared.Abstracts.Cqrs.Messages
{
    public abstract class MessageBase : IMessage
    {
        public Guid Id { get; }

        public string Topic { get; }
    }
}
