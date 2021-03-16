using System.Collections.Generic;

namespace JBCode.SeedWork
{
    internal interface IDomainEventSupervisor
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        bool AddDomainEvent(IDomainEvent domainEvent);
        bool RemoveDomainEvent(IDomainEvent domainEvent);
        void ClearDomainEvents();
    }
}