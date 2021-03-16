using System.Diagnostics.CodeAnalysis;
using JBCode.SeedWork;

namespace JBCode.SeedWorkTests.Common
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    internal class TestValueObject : ValueObject<TestValueObject>
    {
        protected internal TestValueObject(string? property1, int property2)
        {
            Property1 = property1;
            Property2 = property2;
        }

        private string? Property1 { get; }
        private int Property2 { get; }
    }
}