using JBCode.SeedWorkTests.Common;
using Xunit;

namespace JBCode.SeedWorkTests
{
    public class ValueObjectWithDerivedTypesEqualityTests
    {
        [Fact]
        public void SameValues_Equal()
        {
            // Arrange
            DerivedValueObject derivedValueObject1 = new("test", 2, 1.0);
            DerivedValueObject derivedValueObject2 = new("test", 2, 1.0);

            // Act
            var areEqual = derivedValueObject1.Equals(derivedValueObject2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void DifferentBasePropertyValue_NotEqual()
        {
            // Arrange
            DerivedValueObject derivedValueObject1 = new("test", 2, 1.0);
            DerivedValueObject derivedValueObject2 = new("test_2", 2, 1.0);

            // Act
            var areEqual = derivedValueObject1.Equals(derivedValueObject2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void AtLeastOneDifferentValue_NotEqual()
        {
            // Arrange
            DerivedValueObject derivedValueObject1 = new("test", 2, 1.0);
            DerivedValueObject derivedValueObject2 = new("test", 2, -1.0);

            // Act
            var areEqual = derivedValueObject1.Equals(derivedValueObject2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void DerivedTypeComparedWithBaseType_NotEqual()
        {
            // Arrange
            TestValueObject testValueObject1 = new("test", 2);
            DerivedValueObject derivedValueObject2 = new("test", 2, 1.0);

            // Act
            var areEqual = testValueObject1.Equals(derivedValueObject2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void EqualValueObjects_SameHashCode()
        {
            // Arrange
            DerivedValueObject derivedValueObject1 = new("test", 2, 1.0);
            DerivedValueObject derivedValueObject2 = new("test", 2, 1.0);

            // Act
            var hashCode1 = derivedValueObject1.GetHashCode();
            var hashCode2 = derivedValueObject2.GetHashCode();

            // Assert
            Assert.Equal(hashCode1, hashCode2);
        }

        [Fact]
        public void UnequalValueObjects_DifferentHashCodes()
        {
            // Arrange
            DerivedValueObject derivedValueObject1 = new("test", 2, 1.0);
            DerivedValueObject derivedValueObject2 = new("test", 2, -1.0);

            // Act
            var hashCode1 = derivedValueObject1.GetHashCode();
            var hashCode2 = derivedValueObject2.GetHashCode();

            // Assert
            Assert.NotEqual(hashCode1, hashCode2);
        }

        [Fact]
        public void ObjectEqualsWorksWithNulls()
        {
            // Arrange
            DerivedValueObject derivedValueObject1 = new("test", 2, 1.0);
            DerivedValueObject derivedValueObject2 = new("test", 2, null);

            // Act
            var areEqual = derivedValueObject1.Equals(derivedValueObject2);

            // Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void ObjectOperatorsWork()
        {
            // Arrange
            DerivedValueObject derivedValueObject1 = new("test", 2, 1.0);
            DerivedValueObject derivedValueObject2 = new("test", 2, 1.0);
            DerivedValueObject derivedValueObject3 = new("test", 2, -1.0);

            // Act
            var areEqual = derivedValueObject1 == derivedValueObject2;
            var areNotEqual = derivedValueObject2 != derivedValueObject3;

            // Assert
            Assert.True(derivedValueObject1 == derivedValueObject2);
            Assert.True(derivedValueObject2 != derivedValueObject3);
        }
    }
}