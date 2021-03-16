using System;

namespace JBCode.SeedWork
{
    public class DomainEvent : IDomainEvent
    {
        public DomainEvent()
        {
            Id = Guid.NewGuid();
            Created = DateTimeOffset.UtcNow;
            Timestamp = Created;
        }

        public Guid Id { get; }
        public DateTimeOffset Created { get; }
        public DateTimeOffset Timestamp { get; private set; }


        public void OverwriteTimestampWithUtcNow()
            => Timestamp = DateTimeOffset.UtcNow;
    }
}