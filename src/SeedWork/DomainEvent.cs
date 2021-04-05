using System;

namespace JBCode.SeedWork
{
    public class DomainEvent : IDomainEvent
    {
        public DomainEvent()
        {
            Id = Guid.NewGuid();
            Timestamp = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; }
        public DateTimeOffset Timestamp { get; }
    }
}