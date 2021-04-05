using System;

namespace JBCode.SeedWork
{
    public class DomainException : Exception
    {
        private const string UNSPECIFIED_RESOURCE_GROUP = "Unspecified";

        public DomainException(string resourceGroup,
            string type,
            string message)
            : base(message)
        {
            ResourceGroup = resourceGroup;
            Type = type;
        }

        public DomainException(string type,
            string message)
            : base(message)
        {
            ResourceGroup = UNSPECIFIED_RESOURCE_GROUP;
            Type = type;
        }

        public string ResourceGroup { get; }
        public string Type { get; }

        public DomainException IncludeAdditionalData(string key, object value)
        {
            if (!Data.Contains(key))
                Data.Add(key, value);

            return this;
        }
    }
}