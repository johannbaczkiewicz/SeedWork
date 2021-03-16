using JBCode.SeedWorkTests.Common;
using Xunit;

namespace JBCode.SeedWorkTests
{
    public class EntityEqualityTests
    {
        [Fact]
        public void SameIdentifierValuesAndSameReference_Equal()
        {
            // Arrange
            TestEntity testEntity1 = new(111, "test");
            TestEntity testEntity2 = testEntity1;

            // Act
            var areEqual = testEntity1.Equals(testEntity2);
            var areTheSameInstance = ReferenceEquals(testEntity1, testEntity2);

            // Assert
            Assert.True(areEqual);
            Assert.True(areTheSameInstance);
        }

        [Fact]
        public void SameIdentifierValuesButDifferentReference_Equal()
        {
            // Arrange
            TestEntity testEntity1 = new(111, "test");
            TestEntity testEntity2 = new(111, "test");

            // Act
            var areEqual = testEntity1.Equals(testEntity2);
            var areTheSameInstance = ReferenceEquals(testEntity1, testEntity2);

            // Assert
            Assert.True(areEqual);
            Assert.False(areTheSameInstance);
        }

        [Fact]
        public void SameIdentifierValuesButDifferentOtherPropertyValues_Equal()
        {
            // Arrange
            TestEntity testEntity1 = new(111, "test");
            TestEntity testEntity2 = new(111, "test_2");

            // Act
            var areEqual = testEntity1.Equals(testEntity2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void DifferentIdentifierValues_NotEqual()
        {
            // Arrange
            TestEntity testEntity1 = new(111, "test");
            TestEntity testEntity2 = new(222, "test");

            // Act
            var areEqual = testEntity1.Equals(testEntity2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void EqualIdentifiers_SameHashCode()
        {
            // Arrange
            TestEntity testEntity1 = new(111, "test");
            TestEntity testEntity2 = new(111, "test_2");

            // Act
            var hashCode1 = testEntity1.GetHashCode();
            var hashCode2 = testEntity2.GetHashCode();

            // Assert
            Assert.Equal(hashCode1, hashCode2);
        }

        [Fact]
        public void UnequalIdentifiers_DifferentHashCodes()
        {
            // Arrange
            TestEntity testEntity1 = new(111, "test");
            TestEntity testEntity2 = new(222, "test_2");

            // Act
            var hashCode1 = testEntity1.GetHashCode();
            var hashCode2 = testEntity2.GetHashCode();

            // Assert
            Assert.NotEqual(hashCode1, hashCode2);
        }

        [Fact]
        public void ObjectEqualsWorksWithNulls()
        {
            // Arrange
            TestEntity testEntity1 = new(111, "test");
            TestEntity testEntity2 = new(111, null);

            // Act
            var areEqual = testEntity1.Equals(testEntity2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void ObjectOperatorsWork()
        {
            // Arrange
            TestEntity testEntity1 = new(111, "test");
            TestEntity testEntity2 = new(111, "test_2");
            TestEntity testEntity3 = new(222, "test_3");

            // Act
            var areEqual = testEntity1 == testEntity2;
            var areNotEqual = testEntity2 != testEntity3;

            // Assert
            Assert.True(areEqual);
            Assert.True(areNotEqual);
        }
    }
}