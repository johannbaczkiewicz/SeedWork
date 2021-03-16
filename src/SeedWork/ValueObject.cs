using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JBCode.SeedWork
{
    // This code is based on the Māris Krivtežs sample
    // https://gist.github.com/marisks/f9938777ba590b1645376e783f5980ff
    // It originally comes from Jimmy Bogard, but with support of inheritance
    // http://grabbagoft.blogspot.com/2007/06/generic-value-object-equality.html
    public abstract class ValueObject<TValueObject> : IEquatable<TValueObject>
        where TValueObject : ValueObject<TValueObject>
    {
        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            var other = obj as TValueObject;

            return Equals(other);
        }

        public virtual bool Equals(TValueObject? other)
        {
            if (other is null)
                return false;

            var type = GetType();
            var otherType = other.GetType();

            if (type != otherType)
                return false;

            var fields = GetFields(this);

            foreach (var field in fields)
            {
                var value1 = field.GetValue(other);
                var value2 = field.GetValue(this);

                if (value1 is null)
                {
                    if (value2 is not null)
                        return false;
                }
                else if (!value1.Equals(value2))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var fields = GetFields(this);

            const int startValue = 17;
            const int multiplier = 59;

            return fields
                .Select(field => field.GetValue(this))
                .Where(value => value is not null)
                .Aggregate(startValue,
                    (current, value) => current * multiplier + value!.GetHashCode());
        }

        public static bool operator ==(ValueObject<TValueObject>? left, ValueObject<TValueObject>? right)
        {
            if ((object?) left is null || (object?) right is null)
                return false;

            return ReferenceEquals(left, right) || left.Equals(right);
        }

        public static bool operator !=(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
            => !(left == right);

        private static IEnumerable<FieldInfo> GetFields(object obj)
        {
            var type = obj.GetType();
            var fields = new List<FieldInfo>();

            while (type != typeof(object))
            {
                if (type is null)
                    continue;

                fields.AddRange(type
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));

                type = type.BaseType;
            }

            return fields;
        }
    }
}