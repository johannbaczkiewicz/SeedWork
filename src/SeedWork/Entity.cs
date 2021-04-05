using System.Collections.Generic;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace JBCode.SeedWork
{
    public abstract class Entity<TIdentifier> : IDomainEventSupervisor
        where TIdentifier : notnull
    {
        private readonly HashSet<IDomainEvent> _domainEvents = new();

        private int? _hashCode;

        public TIdentifier Id { get; protected init; } = default!;

        public IReadOnlyCollection<IDomainEvent> DomainEvents
            => _domainEvents;

        public bool AddDomainEvent(IDomainEvent domainEvent)
            => _domainEvents.Add(domainEvent);

        public bool RemoveDomainEvent(IDomainEvent domainEvent)
            => _domainEvents.Remove(domainEvent);

        public void ClearDomainEvents()
            => _domainEvents.Clear();

        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TIdentifier> other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id!.Equals(default(TIdentifier)!))
                return false;

            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (other.Id!.Equals(default(TIdentifier)!))
                return false;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            _hashCode ??= (GetType().ToString() + Id).GetHashCode();
            return _hashCode.Value;
        }

        public static bool operator ==(Entity<TIdentifier>? left, Entity<TIdentifier>? right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(Entity<TIdentifier>? left, Entity<TIdentifier>? right)
            => !(left == right);
    }
}