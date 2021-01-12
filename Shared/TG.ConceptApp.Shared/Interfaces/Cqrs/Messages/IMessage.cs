using System;

namespace TG.ConceptApp.Shared.Interfaces.Cqrs.Messages
{
    public interface IMessage
    {
        Guid Id { get; }

        string Topic { get; }
    }
}
