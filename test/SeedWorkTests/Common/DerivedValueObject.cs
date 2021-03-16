using System.Diagnostics.CodeAnalysis;

namespace JBCode.SeedWorkTests.Common
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
    internal class DerivedValueObject : TestValueObject
    {
        internal DerivedValueObject(string? property1,
            int property2,
            double? property3)
            : base(property1, property2)
        {
            Property3 = property3;
        }

        private double? Property3 { get; }
    }
}