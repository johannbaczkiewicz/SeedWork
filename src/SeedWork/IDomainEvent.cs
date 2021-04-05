using System;

namespace JBCode.SeedWork
{
    public interface IDomainEvent
    {
        Guid Id { get; }
        DateTimeOffset Timestamp { get; }
    }
}