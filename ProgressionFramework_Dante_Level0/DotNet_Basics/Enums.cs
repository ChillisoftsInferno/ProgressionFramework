namespace ProgressionFramework_Dante_Level0.DotNet_Basics;

[TestFixture]
public class Enums
{
    [TestFixture]
    public class EnumTests
    {
        // Validates that an enum value can be assigned correctly.
        [Test]
        public void TestEnum_AssignEnumValue_ShouldBeCorrect()
        {
            //Arrange
            Status status = Status.InProgress;

            //Act

            //Assert
            Assert.That(status, Is.EqualTo(Status.InProgress));
        }

        // Ensures that two identical enum values are considered equal.
        [Test]
        public void TestEnum_CompareEnumValues_ShouldReturnTrue()
        {
            //Arrange
            var status1 = Status.Completed;
            var status2 = Status.Completed;

            //Act
            bool areEqual = status1 == status2;

            //Assert
            Assert.IsTrue(areEqual);
        }

        // Confirms that two different enum values are not equal.
        [Test]
        public void TestEnum_CompareDifferentEnumValues_ShouldReturnFalse()
        {
            //Arrange
            var status1 = Status.Pending;
            var status2 = Status.Failed;

            //Act
            bool areEqual = status1 == status2;

            //Assert
            Assert.IsFalse(areEqual);
        }

        // Tests that the underlying integer value of an enum is correct.
        [Test]
        public void TestEnum_GetEnumUnderlyingValue_ShouldBeCorrect()
        {
            //Arrange
            var status = Status.Completed;
            var expected = 2; // Underlying value of Status.Completed

            //Act
            var actual = (int)status;

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        // Validates that a string can be parsed into the correct enum value.
        [Test]
        public void TestEnum_ParseStringToEnum_ShouldReturnCorrectEnum()
        {
            //Arrange
            var statusString = "Failed";
            Status expected = Status.Failed;

            //Act
            var actual = (Status)Enum.Parse(typeof(Status), statusString);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        // Ensures that parsing an invalid string into an enum throws an ArgumentException.
        [Test]
        public void TestEnum_ParseInvalidStringToEnum_ShouldThrowException()
        {
            //Arrange
            var invalidString = "InvalidStatus";

            //Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var status = (Status)Enum.Parse(typeof(Status), invalidString);
            });
        }

        // Confirms that a valid enum value is defined within the enum.
        [Test]
        public void TestEnum_CheckIfValueDefinedInEnum_ShouldReturnTrue()
        {
            //Arrange
            var status = Status.InProgress;

            //Act
            bool isDefined = Enum.IsDefined(typeof(Status), status);

            //Assert
            Assert.IsTrue(isDefined);
        }

        // Ensures that an invalid integer is not defined within the enum.
        [Test]
        public void TestEnum_CheckIfValueNotDefinedInEnum_ShouldReturnFalse()
        {
            //Arrange
            var invalidValue = 10;

            //Act
            bool isDefined = Enum.IsDefined(typeof(Status), invalidValue);

            //Assert
            Assert.IsFalse(isDefined);
        }

        // Tests that the enum names returned are as expected.
        [Test]
        public void TestEnum_GetEnumNames_ShouldContainExpectedNames()
        {
            //Arrange
            var expectedNames = new[] { "Pending", "InProgress", "Completed", "Failed" };

            //Act
            var actualNames = Enum.GetNames(typeof(Status));

            //Assert
            CollectionAssert.AreEquivalent(expectedNames, actualNames);
        }

        // Confirms that the enum values returned are as expected.
        [Test]
        public void TestEnum_GetEnumValues_ShouldContainExpectedValues()
        {
            //Arrange
            var expectedValues = new Status[] { Status.Pending, Status.InProgress, Status.Completed, Status.Failed };

            //Act
            var actualValues = Enum.GetValues(typeof(Status));

            //Assert
            CollectionAssert.AreEquivalent(expectedValues, actualValues);
        }
    }
    
    private enum Status
    {
        Pending,
        InProgress,
        Completed,
        Failed
    }
}


