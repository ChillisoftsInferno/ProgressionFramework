using GlobalHelpers;

namespace ProgressionFramework_Dante_Level0.DotNet_Basics;

[TestFixture]
public class Variables
{
    [TestFixture]
    public class StringTests
    {
        [Test]
        public void TestString_IsNullOrEmpty_ShouldReturnFalse()
        {
            //Arrange
            string testString = "Hello world!";
            //Act
            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(testString));
        }
        
        [Test]
        public void TestString_IsNullOrEmpty_ShouldReturnTrue()
        {
            //Arrange
            string testString = "";
            string? testString2 = null;
            //Act
            //Assert
            Assert.IsTrue(string.IsNullOrEmpty(testString));
            Assert.IsTrue(string.IsNullOrEmpty(testString2));
        }
        
        [Test]
        public void TestString_GivenLength_ShouldBeEqual()
        {
            //Arrange
            string testString = "Supercalifragilisticexpialidocious";
            int expected = 34;
            //Act
            //Assert
            Assert.That(testString.Length, Is.EqualTo(expected));
        }

        [Test]
        public void TestString_ContainsSubString_ShouldReturnTrue()
        {
            //Arrange
            string testString = "Good day mate";
            string expected = "day";
            //Act
            //Assert
            Assert.IsTrue(testString.Contains(expected));
        }
        
        [Test]
        public void TestString_StartsWith_ShouldReturnTrue()
        {
            //Arrange
            string testString = "Downtown";
            //Act
            //Assert
            Assert.IsTrue(testString.StartsWith("Down"));
        }
        
        [Test]
        public void TestString_EndsWith_ShouldReturnTrue()
        {
            //Arrange
            string testString = "Downtown";
            //Act
            //Assert
            Assert.IsTrue(testString.EndsWith("town"));
        }

        [Test]
        public void TestString_Equality_ShouldReturnEquivalent()
        {
            //Arrange
            string testString = "Hello, World!";
            string expected = "Hello, World!";
            //Act
            //Assert
            Assert.That(testString, Is.EqualTo(expected));
        }

        [Test]
        public void TestString_EqualityIgnoreCase_ShouldReturnEquivalent()
        {
            //Arrange
            string testString = "Hello, World!";
            string expected = "hello, world!";
            //Act
            //Assert
            Assert.IsTrue(testString.Equals(expected, StringComparison.OrdinalIgnoreCase));
        }

        [Test]
        public void TestString_Split_ShouldReturnEquivalent()
        {
            //Arrange
            string testString = "Hello, World!";
            int expectedLength = 2;
            string expectedFirstHalf = "Hello";
            string expectedSecondHalf = "World!";
            //Act
            string[] splitString = testString.Split(',');
            //Assert
            Assert.That(expectedLength, Is.EqualTo(splitString.Length));
            Assert.That(expectedFirstHalf, Is.EqualTo(splitString[0].Trim()));
            Assert.That(expectedSecondHalf, Is.EqualTo(splitString[1].Trim()));
        }

        [Test]
        public void TestString_Replace_ShouldReturnEquivalent()
        {
            //Arrange
            string testString = "Hello, World!";
            string expected = "Hello, Universe!";
            //Act
            string replacedString = testString.Replace("World", "Universe");
            //Assert
            Assert.That(replacedString, Is.EqualTo(expected));
        }
        
        [Test]
        public void TestString_CustomerDetails_ShouldReturnCustomerWithDetails()
        {
            //Arrange
            string name = "John";
            string surname = "Doe";
            Customer sut = new Customer();
            Customer expected = new Customer("John", "Doe");
            //Act
            sut.Name = name;
            sut.Surname = surname;
            //Assert
            Assert.That(sut.Name, Is.EqualTo(expected.Name));
            Assert.That(sut.Surname, Is.EqualTo(expected.Surname));
        }
    }
    
    [TestFixture]
    public class IntegerTests
    {
        [Test]
        public void TestInt_Equality()
        {
            //Arrange
            int testInt = 50;
            int expected = 50;
            //Act
            //Assert
            Assert.That(testInt, Is.EqualTo(expected));
        }

        [Test]
        public void TestInt_Inequality()
        {
            //Arrange
            int testInt = 50;
            int expected = 100;
            //Act
            //Assert
            Assert.That(testInt, !Is.EqualTo(expected));
        }

        [Test]
        public void TestIntGreaterThan()
        {
            //Arrange
            int testInt = 125;
            int expected = 100;
            //Act
            //Assert
            Assert.Greater(testInt, expected);
        }

        [Test]
        public void TestIntGreaterThanOrEqual()
        {
            //Arrange
            int testInt = 125;
            int expected1 = 100;
            int expected2 = 125;
            //Act
            //Assert
            Assert.Greater(testInt, expected1);
            Assert.GreaterOrEqual(testInt, expected2);
        }

        [Test]
        public void TestIntLessThan()
        {
            //Arrange
            int testInt = 100;
            int expected = 125;
            //Act
            //Assert
            Assert.Less(testInt, expected);
        }

        [Test]
        public void TestIntLessThanOrEqual()
        {
            //Arrange
            int testInt = 100;
            int expected1 = 125;
            int expected2 = 100;
            //Act
            //Assert
            Assert.Less(testInt, expected1);
            Assert.LessOrEqual(testInt, expected2);
        }

        [Test]
        public void TestIntWithinRange()
        {
            //Arrange
            int testInt = 25;
            //Act
            //Assert
            Assert.That(testInt, Is.InRange(15, 30));
        }
        
        [Test]
        public void TestIntAddition()
        {
            //Arrange
            int testInt = 10;
            int addition = 5;
            int expected = 15;
            //Act
            testInt += addition;
            //Assert
            Assert.That(testInt, Is.EqualTo(expected));
        }
        
        [Test]
        public void TestIntSubtraction()
        {
            //Arrange
            int testInt = 10;
            int addition = 5;
            int expected = 5;
            //Act
            testInt -= addition;
            //Assert
            Assert.That(testInt, Is.EqualTo(expected));
        }
        
        [Test]
        public void TestIntMultiplication()
        {
            //Arrange
            int testInt = 10;
            int addition = 5;
            int expected = 50;
            //Act
            testInt *= addition;
            //Assert
            Assert.That(testInt, Is.EqualTo(expected));
        }
        
        [Test]
        public void TestIntDivision()
        {
            //Arrange
            int testInt = 10;
            int addition = 5;
            int expected = 2;
            //Act
            testInt /= addition;
            //Assert
            Assert.That(testInt, Is.EqualTo(expected));
        }

        [Test]
        public void TestIntIsPositive()
        {
            //Arrange
            int testInt = 10;
            //Act
            testInt += 5;
            //Assert
            Assert.That(testInt, Is.Positive);

        }

        [Test]
        public void TestIntIsNegative()
        {
            //Arrange
            int testInt = 10;
            //Act
            testInt -= 25;
            //Assert
            Assert.That(testInt, Is.Negative);
        }

        [Test]
        public void TestIntIsZero()
        {
            //Arrange
            int testInt = 10;
            //Act
            testInt -= 10;
            //Assert
            Assert.That(testInt, Is.Zero);
        }
    }

    [TestFixture]
    public class CharTests
    {
        [Test]
        public void TestChar_IsLetter_ShouldReturnTrue()
        {
            //Arrange
            char testChar = 'A';
            //Act
            bool result = char.IsLetter(testChar);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestChar_IsDigit_ShouldReturnTrue()
        {
            //Arrange
            char testChar = '5';
            //Act
            bool result = char.IsDigit(testChar);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestChar_IsWhiteSpace_ShouldReturnTrue()
        {
            //Arrange
            char testChar = ' ';
            //Act
            bool result = char.IsWhiteSpace(testChar);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestChar_IsUpper_ShouldReturnTrue()
        {
            //Arrange
            char testChar = 'Z';
            //Act
            bool result = char.IsUpper(testChar);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestChar_IsLower_ShouldReturnTrue()
        {
            //Arrange
            char testChar = 'z';
            //Act
            bool result = char.IsLower(testChar);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestChar_ToUpper_ShouldConvertToUpper()
        {
            //Arrange
            char testChar = 'a';
            char expected = 'A';
            //Act
            char result = char.ToUpper(testChar);
            //Assert
            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void TestChar_ToLower_ShouldConvertToLower()
        {
            //Arrange
            char testChar = 'A';
            char expected = 'a';
            //Act
            char result = char.ToLower(testChar);
            //Assert
            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void TestChar_IsPunctuation_ShouldReturnTrue()
        {
            //Arrange
            char testChar = '!';
            //Act
            bool result = char.IsPunctuation(testChar);
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestChar_ConvertFromInt_ShouldReturnChar()
        {
            //Arrange
            int testInt = 65;
            char expected = 'A';
            //Act
            char result = (char)testInt;
            //Assert
            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void TestChar_ConvertToInt_ShouldReturnInt()
        {
            //Arrange
            char testChar = 'A';
            int expected = 65;
            //Act
            int result = testChar;
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class BooleanTests
    {
        [Test]
        public void TestBool_True_ShouldBeTrue()
        {
            //Arrange
            bool testBool = true;
            //Act
            //Assert
            Assert.IsTrue(testBool);
        }

        [Test]
        public void TestBool_False_ShouldBeFalse()
        {
            //Arrange
            bool testBool = false;
            //Act
            //Assert
            Assert.IsFalse(testBool);
        }

        [Test]
        public void TestBool_Equality_ShouldBeEqual()
        {
            //Arrange
            bool testBool1 = true;
            bool testBool2 = true;
            //Act
            //Assert
            Assert.That(testBool2, Is.EqualTo(testBool1));
        }

        [Test]
        public void TestBool_Inequality_ShouldNotBeEqual()
        {
            //Arrange
            bool testBool1 = true;
            bool testBool2 = false;
            //Act
            //Assert
            Assert.That(testBool2, Is.Not.EqualTo(testBool1));
        }

        [Test]
        public void TestBool_NotOperation_ShouldReturnFalse()
        {
            //Arrange
            bool testBool = true;
            //Act
            bool result = !testBool;
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestBool_AndOperation_ShouldReturnTrue()
        {
            //Arrange
            bool testBool1 = true;
            bool testBool2 = true;
            //Act
            bool result = testBool1 && testBool2;
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestBool_AndOperation_ShouldReturnFalse()
        {
            //Arrange
            bool testBool1 = true;
            bool testBool2 = false;
            //Act
            bool result = testBool1 && testBool2;
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestBool_OrOperation_ShouldReturnTrue()
        {
            //Arrange
            bool testBool1 = true;
            bool testBool2 = false;
            //Act
            bool result = testBool1 || testBool2;
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestBool_OrOperation_ShouldReturnFalse()
        {
            //Arrange
            bool testBool1 = false;
            bool testBool2 = false;
            //Act
            bool result = testBool1 || testBool2;
            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void TestBool_XorOperation_ShouldReturnTrue()
        {
            //Arrange
            bool testBool1 = true;
            bool testBool2 = false;
            //Act
            bool result = testBool1 ^ testBool2;
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestBool_XorOperation_ShouldReturnFalse()
        {
            //Arrange
            bool testBool1 = true;
            bool testBool2 = true;
            //Act
            bool result = testBool1 ^ testBool2;
            //Assert
            Assert.IsFalse(result);
        }
    }

    [TestFixture]
    public class DecimalTests
    {
        [Test]
        public void TestDecimal_Equality_ShouldBeEqual()
        {
            //Arrange
            decimal testDecimal = 17.99m;
            decimal expected = 17.99m;
            //Act
            //Assert
            Assert.That(testDecimal, Is.EqualTo(expected));
        }

        [Test]
        public void TestDecimal_Inequality_ShouldNotBeEqual()
        {
            //Arrange
            decimal testDecimal = 17.99m;
            decimal expected = 26.99m;
            //Act
            //Assert
            Assert.That(testDecimal, !Is.EqualTo(expected));
        }

        [Test]
        public void TestDecimal_GreaterThan_ShouldReturnTrue()
        {
            //Arrange
            decimal testDecimal = 46.58m;
            decimal expected = 21.87m;
            //Act
            //Assert
            Assert.Greater(testDecimal, expected);
        }

        [Test]
        public void TestDecimal_LessThan_ShouldReturnTrue()
        {
            //Arrange
            decimal testDecimal = 46.58m;
            decimal expected = 58.35m;
            //Act
            //Assert
            Assert.Less(testDecimal, expected);
        }

        [Test]
        public void TestDecimal_Addition_ShouldBeCorrect()
        {
            //Arrange
            decimal testDecimal = 34.55m;
            decimal expected = 60.03m;
            //Act
            testDecimal += 25.48m;
            //Assert
            Assert.That(testDecimal, Is.EqualTo(expected));
        }

        [Test]
        public void TestDecimal_Subtraction_ShouldBeCorrect()
        {
            //Arrange
            decimal testDecimal = 34.55m;
            decimal expected = 11.24m;
            //Act
            testDecimal -= 23.31m;
            //Assert
            Assert.That(testDecimal, Is.EqualTo(expected));
        }

        [Test]
        public void TestDecimal_Multiplication_ShouldBeCorrect()
        {
            //Arrange
            decimal testDecimal = 13.96m;
            decimal expected = 69.8m;
            //Act
            testDecimal *= 5;
            //Assert
            Assert.That(testDecimal, Is.EqualTo(expected));
        }

        [Test]
        public void TestDecimal_Division_ShouldBeCorrect()
        {
            //Arrange
            decimal testDecimal = 48.95m;
            decimal expected = 6.11875m;
            //Act
            testDecimal /= 8;
            //Assert
            Assert.That(testDecimal, Is.EqualTo(expected));
        }

        [Test]
        public void TestDecimal_Remainder_ShouldBeCorrect()
        {
            //Arrange
            decimal testDecimal1 = 22.5m;
            decimal testDecimal2 = 10m;
            decimal expected = 2.5m;
            //Act
            decimal result = testDecimal1 % testDecimal2;
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestDecimal_NegativeValue_ShouldReturnTrue()
        {
            //Arrange
            decimal testDecimal = -10.5m;
            //Act
            bool result = testDecimal < 0;
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestDecimal_PositiveValue_ShouldReturnTrue()
        {
            //Arrange
            decimal testDecimal = 10.5m;
            //Act
            bool result = testDecimal > 0;
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestDecimal_Round_ShouldBeCorrect()
        {
            //Arrange
            decimal testDecimal = 10.56789m;
            decimal expected = 10.57m;
            //Act
            decimal result = Math.Round(testDecimal, 2);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class DoubleTests
    {
        [Test]
        public void TestDouble_Equality_ShouldBeEqual()
        {
            //Arrange
            double testDouble1 = 10.5;
            double testDouble2 = 10.5;
            //Act
            //Assert
            Assert.That(testDouble2, Is.EqualTo(testDouble1));
        }

        [Test]
        public void TestDouble_Inequality_ShouldNotBeEqual()
        {
            //Arrange
            double testDouble1 = 10.5;
            double testDouble2 = 20.5;
            //Act
            //Assert
            Assert.That(testDouble2, Is.Not.EqualTo(testDouble1));
        }

        [Test]
        public void TestDouble_GreaterThan_ShouldReturnTrue()
        {
            //Arrange
            double testDouble1 = 20.5;
            double testDouble2 = 10.5;
            //Act
            bool result = testDouble1 > testDouble2;
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestDouble_LessThan_ShouldReturnTrue()
        {
            //Arrange
            double testDouble1 = 10.5;
            double testDouble2 = 20.5;
            //Act
            bool result = testDouble1 < testDouble2;
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestDouble_Addition_ShouldBeCorrect()
        {
            //Arrange
            double testDouble1 = 10.5;
            double testDouble2 = 20.5;
            double expected = 31.0;
            //Act
            double result = testDouble1 + testDouble2;
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestDouble_Subtraction_ShouldBeCorrect()
        {
            //Arrange
            double testDouble1 = 20.5;
            double testDouble2 = 10.5;
            double expected = 10.0;
            //Act
            double result = testDouble1 - testDouble2;
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestDouble_Multiplication_ShouldBeCorrect()
        {
            //Arrange
            double testDouble1 = 10.5;
            double testDouble2 = 2.0;
            double expected = 21.0;
            //Act
            double result = testDouble1 * testDouble2;
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestDouble_Division_ShouldBeCorrect()
        {
            //Arrange
            double testDouble1 = 21.0;
            double testDouble2 = 2.0;
            double expected = 10.5;
            //Act
            double result = testDouble1 / testDouble2;
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestDouble_Remainder_ShouldBeCorrect()
        {
            //Arrange
            double testDouble1 = 22.5;
            double testDouble2 = 10.0;
            double expected = 2.5;
            //Act
            double result = testDouble1 % testDouble2;
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestDouble_NegativeValue_ShouldReturnTrue()
        {
            //Arrange
            double testDouble = -10.5;
            //Act
            bool result = testDouble < 0;
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestDouble_PositiveValue_ShouldReturnTrue()
        {
            //Arrange
            double testDouble = 10.5;
            //Act
            bool result = testDouble > 0;
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TestDouble_Round_ShouldBeCorrect()
        {
            //Arrange
            double testDouble = 10.56789;
            double expected = 10.57;
            //Act
            double result = Math.Round(testDouble, 2);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

    }

    [TestFixture]
    public class ByteTests
    {
        [Test]
        public void TestByte_Equality_ShouldBeEqual()
        {
            //Arrange
            byte testByte1 = 10;
            byte testByte2 = 10;
            //Act
            //Assert
            Assert.That(testByte2, Is.EqualTo(testByte1));
        }

        [Test]
        public void TestByte_Inequality_ShouldNotBeEqual()
        {
            //Arrange
            byte testByte1 = 10;
            byte testByte2 = 20;
            //Act
            //Assert
            Assert.That(testByte2, Is.Not.EqualTo(testByte1));
        }

        [Test]
        public void TestByte_Addition_ShouldBeCorrect()
        {
            //Arrange
            byte testByte1 = 10;
            byte testByte2 = 20;
            byte expected = 30;
            //Act
            byte result = (byte)(testByte1 + testByte2);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestByte_Subtraction_ShouldBeCorrect()
        {
            //Arrange
            byte testByte1 = 20;
            byte testByte2 = 10;
            byte expected = 10;
            //Act
            byte result = (byte)(testByte1 - testByte2);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestByte_Multiplication_ShouldBeCorrect()
        {
            //Arrange
            byte testByte1 = 10;
            byte testByte2 = 2;
            byte expected = 20;
            //Act
            byte result = (byte)(testByte1 * testByte2);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestByte_Division_ShouldBeCorrect()
        {
            //Arrange
            byte testByte1 = 20;
            byte testByte2 = 2;
            byte expected = 10;
            //Act
            byte result = (byte)(testByte1 / testByte2);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestByte_Remainder_ShouldBeCorrect()
        {
            //Arrange
            byte testByte1 = 22;
            byte testByte2 = 10;
            byte expected = 2;
            //Act
            byte result = (byte)(testByte1 % testByte2);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestByte_ConvertFromInt_ShouldReturnByte()
        {
            //Arrange
            int testInt = 65;
            byte expected = 65;
            //Act
            byte result = (byte)testInt;
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestByte_ConvertToInt_ShouldReturnInt()
        {
            //Arrange
            byte testByte = 65;
            int expected = 65;
            //Act
            int result = testByte;
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class DynamicTests
    {
        [Test]
        public void TestDynamic_AssignString_ShouldBeString()
        {
            //Arrange
            dynamic testDynamic = "Hello World";
            //Act
            string result = testDynamic;
            //Assert
            Assert.That(result, Is.EqualTo("Hello World"));
        }

        [Test]
        public void TestDynamic_AssignInt_ShouldBeInt()
        {
            //Arrange
            dynamic testDynamic = 123;
            //Act
            int result = testDynamic;
            //Assert
            Assert.That(result, Is.EqualTo(123));
        }

        [Test]
        public void TestDynamic_AssignDouble_ShouldBeDouble()
        {
            //Arrange
            dynamic testDynamic = 123.45;
            //Act
            double result = testDynamic;
            //Assert
            Assert.That(result, Is.EqualTo(123.45));
        }

        [Test]
        public void TestDynamic_AssignBoolean_ShouldBeBoolean()
        {
            //Arrange
            dynamic testDynamic = true;
            //Act
            bool result = testDynamic;
            //Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TestDynamic_AssignObject_ShouldBeObject()
        {
            //Arrange
            dynamic testDynamic = new { Name = "John", Age = 30 };
            //Act
            string name = testDynamic.Name;
            int age = testDynamic.Age;
            //Assert
            Assert.That(name, Is.EqualTo("John"));
            Assert.That(age, Is.EqualTo(30));
        }

        [Test]
        public void TestDynamic_AssignAndAddIntegers_ShouldBeCorrect()
        {
            //Arrange
            dynamic testDynamic1 = 10;
            dynamic testDynamic2 = 20;
            //Act
            dynamic result = testDynamic1 + testDynamic2;
            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void TestDynamic_AssignAndConcatenateStrings_ShouldBeCorrect()
        {
            //Arrange
            dynamic testDynamic1 = "Hello";
            dynamic testDynamic2 = " World";
            //Act
            dynamic result = testDynamic1 + testDynamic2;
            //Assert
            Assert.AreEqual("Hello World", result);
        }

        [Test]
        public void TestDynamic_AssignAndInvokeMethod_ShouldBeCorrect()
        {
            //Arrange
            dynamic testDynamic = "Hello World";
            //Act
            dynamic result = testDynamic.Substring(0, 5);
            //Assert
            Assert.AreEqual("Hello", result);
        }

        [Test]
        public void TestDynamic_AssignAndCastToDifferentType_ShouldBeCorrect()
        {
            //Arrange
            dynamic testDynamic = 123.45;
            //Act
            int result = (int)testDynamic;
            //Assert
            Assert.That(result, Is.EqualTo(123));
        }

        [Test]
        public void TestDynamic_AssignAndUseInLambda_ShouldBeCorrect()
        {
            //Arrange
            dynamic testDynamic = 5;
            Func<dynamic, dynamic> multiplyByTwo = x => x * 2;
            //Act
            dynamic result = multiplyByTwo(testDynamic);
            //Assert
            Assert.AreEqual(10, result);
        }
    }
}