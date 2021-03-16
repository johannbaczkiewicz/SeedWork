using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace JBCode.SeedWork
{
    public class DomainException : Exception
    {
        private readonly ConcurrentDictionary<string, object> _additionalData = new();

        public DomainException(string type, string message)
            : base(message)
        {
            Type = type;
        }

        public string Type { get; }

        public IDictionary<string, object> AdditionalData
            => _additionalData;

        public DomainException IncludeAdditionalData(string key, object value)
        {
            _additionalData.AddOrUpdate(key,
                value,
                updateValueFactory: (_, _) => value);

            return this;
        }
    }
}