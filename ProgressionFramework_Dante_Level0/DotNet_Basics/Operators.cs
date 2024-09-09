namespace ProgressionFramework_Dante_Level0.DotNet_Basics;

public abstract class Operators
{
    [TestFixture]
    public class OperatorTests
    {
        // Confirms that addition of two integers works correctly.
        [Test]
        public void TestOperator_Addition_ShouldReturnCorrectSum()
        {
            //Arrange
            int a = 5;
            int b = 10;
            int expectedSum = 15;

            //Act
            int actualSum = a + b;

            //Assert
            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }

        // Confirms that subtraction of two integers works correctly.
        [Test]
        public void TestOperator_Subtraction_ShouldReturnCorrectDifference()
        {
            //Arrange
            int a = 10;
            int b = 5;
            int expectedDifference = 5;

            //Act
            int actualDifference = a - b;

            //Assert
            Assert.That(actualDifference, Is.EqualTo(expectedDifference));
        }

        // Confirms that multiplication of two integers works correctly.
        [Test]
        public void TestOperator_Multiplication_ShouldReturnCorrectProduct()
        {
            //Arrange
            int a = 5;
            int b = 4;
            int expectedProduct = 20;

            //Act
            int actualProduct = a * b;

            //Assert
            Assert.That(actualProduct, Is.EqualTo(expectedProduct));
        }

        // Confirms that division of two integers works correctly.
        [Test]
        public void TestOperator_Division_ShouldReturnCorrectQuotient()
        {
            //Arrange
            int a = 10;
            int b = 2;
            int expectedQuotient = 5;

            //Act
            int actualQuotient = a / b;

            //Assert
            Assert.That(actualQuotient, Is.EqualTo(expectedQuotient));
        }

        // Confirms that modulus operator works correctly.
        [Test]
        public void TestOperator_Modulus_ShouldReturnCorrectRemainder()
        {
            //Arrange
            int a = 10;
            int b = 3;
            int expectedRemainder = 1;

            //Act
            int actualRemainder = a % b;

            //Assert
            Assert.That(actualRemainder, Is.EqualTo(expectedRemainder));
        }

        // Confirms that equality comparison works correctly.
        [Test]
        public void TestOperator_Equality_ShouldReturnTrueIfEqual()
        {
            //Arrange
            int a = 5;
            int b = 5;

            //Act
            bool areEqual = a == b;

            //Assert
            Assert.IsTrue(areEqual);
        }

        // Confirms that inequality comparison works correctly.
        [Test]
        public void TestOperator_Inequality_ShouldReturnTrueIfNotEqual()
        {
            //Arrange
            int a = 5;
            int b = 10;

            //Act
            bool areNotEqual = a != b;

            //Assert
            Assert.IsTrue(areNotEqual);
        }

        // Confirms that greater than comparison works correctly.
        [Test]
        public void TestOperator_GreaterThan_ShouldReturnTrueIfGreater()
        {
            //Arrange
            int a = 10;
            int b = 5;

            //Act
            bool isGreaterThan = a > b;

            //Assert
            Assert.IsTrue(isGreaterThan);
        }

        // Confirms that less than comparison works correctly.
        [Test]
        public void TestOperator_LessThan_ShouldReturnTrueIfLess()
        {
            //Arrange
            int a = 5;
            int b = 10;

            //Act
            bool isLessThan = a < b;

            //Assert
            Assert.IsTrue(isLessThan);
        }

        // Confirms that logical AND operation works correctly.
        [Test]
        public void TestOperator_LogicalAnd_ShouldReturnTrueIfBothTrue()
        {
            //Arrange
            bool a = true;
            bool b = true;

            //Act
            bool result = a && b;

            //Assert
            Assert.IsTrue(result);
        }

        // Confirms that logical OR operation works correctly.
        [Test]
        public void TestOperator_LogicalOr_ShouldReturnTrueIfEitherTrue()
        {
            //Arrange
            bool a = true;
            bool b = false;

            //Act
            bool resultTrue = a || b; // Results are true if any of the values are true regardless of the current
                                      // expression order.
            //Assert
            Assert.IsTrue(resultTrue);
        }

        // Confirms that increment operator works correctly.
        [Test]
        public void TestOperator_Increment_ShouldIncreaseValueByOne()
        {
            //Arrange
            int a = 5;
            int expectedValue = 6;

            //Act
            a++;

            //Assert
            Assert.That(a, Is.EqualTo(expectedValue));
        }

        // Confirms that decrement operator works correctly.
        [Test]
        public void TestOperator_Decrement_ShouldDecreaseValueByOne()
        {
            //Arrange
            int a = 5;
            int expectedValue = 4;

            //Act
            a--;

            //Assert
            Assert.That(a, Is.EqualTo(expectedValue));
        }

        // Confirms that negation operator works correctly.
        [Test]
        public void TestOperator_Negation_ShouldReturnCorrectNegativeValue()
        {
            //Arrange
            int a = 5;
            int expectedValue = -5;

            //Act
            int actualValue = -a;

            //Assert
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}