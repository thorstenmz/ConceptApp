using System;

namespace TG.ConceptApp.Shared.Interfaces.Entities
{
    public interface IAuditable
    {
        DateTimeOffset CreatedOn { get; }

        string CreatedBy { get; }

        DateTimeOffset UpdatedOn { get; }

        string UpdatedBy { get; }
    }
}
