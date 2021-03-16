using System.Diagnostics.CodeAnalysis;
using JBCode.SeedWork;

namespace JBCode.SeedWorkTests.Common
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    internal class TestEntity : Entity<int>
    {
        internal TestEntity(int id, string? property1)
        {
            Id = id;
            Property1 = property1;
        }

        private string? Property1 { get; }
    }
}