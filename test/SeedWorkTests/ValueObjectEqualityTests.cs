using JBCode.SeedWorkTests.Common;
using Xunit;

namespace JBCode.SeedWorkTests
{
    public class ValueObjectEqualityTests
    {
        [Fact]
        public void SameValuesButDifferentReferences_Equal()
        {
            // Arrange
            TestValueObject testValueObject1 = new("test", 2);
            TestValueObject testValueObject2 = new("test", 2);

            // Act
            var areEqual = testValueObject1.Equals(testValueObject2);
            var areTheSameInstance = ReferenceEquals(testValueObject1, testValueObject2);

            // Assert
            Assert.True(areEqual);
            Assert.False(areTheSameInstance);
        }

        [Fact]
        public void SameValuesAndSameReferences_Equal()
        {
            // Arrange
            TestValueObject testValueObject1 = new("test", 2);
            var testValueObject2 = testValueObject1;

            // Act
            var areEqual = testValueObject1.Equals(testValueObject2);
            var areTheSameInstance = ReferenceEquals(testValueObject1, testValueObject2);

            // Assert
            Assert.True(areEqual);
            Assert.True(areTheSameInstance);
        }

        [Fact]
        public void AtLeastOneDifferentValue_NotEqual()
        {
            // Arrange
            TestValueObject testValueObject1 = new("test", 2);
            TestValueObject testValueObject2 = new("test_2", 2);

            // Act
            var areEqual = testValueObject1.Equals(testValueObject2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void EqualValueObjects_SameHashCode()
        {
            // Arrange
            TestValueObject testValueObject1 = new("test", 2);
            TestValueObject testValueObject2 = new("test", 2);

            // Act
            var hashCode1 = testValueObject1.GetHashCode();
            var hashCode2 = testValueObject2.GetHashCode();

            // Assert
            Assert.Equal(hashCode1, hashCode2);
        }

        [Fact]
        public void UnequalValueObjects_DifferentHashCodes()
        {
            // Arrange
            TestValueObject testValueObject1 = new("test", 2);
            TestValueObject testValueObject2 = new("test_2", -2);

            // Act
            var hashCode1 = testValueObject1.GetHashCode();
            var hashCode2 = testValueObject2.GetHashCode();

            // Assert
            Assert.NotEqual(hashCode1, hashCode2);
        }

        [Fact]
        public void ObjectEqualsWorksWithNulls()
        {
            // Arrange
            TestValueObject testValueObject1 = new("test", 2);
            TestValueObject testValueObject2 = new(null, 2);

            // Act
            var areEqual = testValueObject1.Equals(testValueObject2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void ObjectOperatorsWork()
        {
            // Arrange
            TestValueObject testValueObject1 = new("test", 2);
            TestValueObject testValueObject2 = new("test", 2);
            TestValueObject testValueObject3 = new("test_2", 2);

            // Act
            var areEqual = testValueObject1 == testValueObject2;
            var areNotEqual = testValueObject2 != testValueObject3;

            // Assert
            Assert.True(areEqual);
            Assert.True(areNotEqual);
        }
    }
}