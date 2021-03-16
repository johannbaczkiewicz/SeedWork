using System;

namespace JBCode.SeedWork
{
    public interface IDomainEvent
    {
        Guid Id { get; }
        DateTimeOffset Created { get; }
        DateTimeOffset Timestamp { get; }

        void OverwriteTimestampWithUtcNow();
    }
}