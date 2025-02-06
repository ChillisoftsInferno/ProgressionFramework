namespace ProgressionFramework_Dante_Level0.Katas;

public class StringKata
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers) || string.IsNullOrEmpty(numbers)) return 0;
        var result = numbers.Select(x => int.Parse(numbers));
        
        return int.Parse(numbers);
    }
    
    
    [TestFixture]
    public class TestStringCalculatorKata
    {
        [TestCase("1", 1)]
        [TestCase("15", 15)]
        [TestCase("999", 999)]
        public void Add_GivenOneNumber_ShouldReturnThatNumber(string numbers, int expectedResult)
        {
            // Arrange
            var sut = new StringKata();

            // Act
            var actual = sut.Add(numbers);

            // Assert
            Assert.That(actual, Is.EqualTo(expectedResult));
        }
        
        [TestCase(null, 0)]
        [TestCase("", 0)]
        [TestCase(" ", 0)]
        [TestCase("   ", 0)]
        public void Add_GivenNoNumbers_ShouldReturnZero(string numbers, int expectedResult)
        {
            // Arrange
            var sut = new StringKata();

            // Act
            var actual = sut.Add(numbers);

            // Assert
            Assert.That(actual, Is.EqualTo(expectedResult));
        }
        
        [TestCase("1,2", 3)]
        [TestCase("5,15,20", 40)]
        [TestCase("999,1,11,2", 1013)]
        public void Add_GiveManyNumbers_ShouldReturnTheSumOfThoseNumbers(string numbers, int expectedResult)
        {
            // Arrange
            var sut = new StringKata();

            // Act
            var actual = sut.Add(numbers);

            // Assert
            Assert.That(actual, Is.EqualTo(expectedResult));
        }
    }
}