namespace ProgressionFramework_Dante_Level0.Katas;

public class StringKata
{
    private List<string> delimiters = new List<string>()
    {
        ",", "\n"
    };
    public int Add(string input)
    {
        if (string.IsNullOrEmpty(input)) return 0;
        input = CheckForCustomDelimiter(input);
        var numbersStrings = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
        var numbersList = new List<int>();
        var negatives = new List<int>();
        bool containsNegatives = false;
        foreach (var number in numbersStrings)
        {
            var canParse = int.TryParse(number, out int result);
            if(!canParse) continue;
            if (result < 0)
            {
                negatives.Add(result);
                containsNegatives = true;
                continue;
            }
            numbersList.Add(result);
        }
        if (containsNegatives)
        {
            var negativeNumbersString = string.Join(",", negatives);
            throw new Exception(negativeNumbersString);
        }
        
        return numbersList.Sum();
    }

    public string CheckForCustomDelimiter(string input)
    {
        if (!input.StartsWith("//")) return input;

        input = input.Remove(0, 2);
        string customDelimiter = input.Split("\n")[0];
        delimiters.Add(customDelimiter);
        return input;
    }


    [TestFixture]
    public class StringKataTests
    {
        [TestCase("", 0)]
            public void Add_GivenEmptyString_ShouldReturnZero(string input, int expectedSum)
            {
                //Arrange
                var sut = new StringKata();
                //Act
                var result = sut.Add(input);
                //Assert
                Assert.That(result, Is.EqualTo(expectedSum));
            }
            
            [TestCase("1", 1)]
            [TestCase("25", 25)]
            [TestCase("999", 999)]
            public void Add_GivenOneNumber_ShouldReturnThatNumber(string input, int expectedSum)
            {
                //Arrange
                var sut = new StringKata();
                //Act
                var result = sut.Add(input);
                //Assert
                Assert.That(result, Is.EqualTo(expectedSum));
            }
            
            [TestCase("1, 2, 3", 6)]
            [TestCase("25, 25, 50", 100)]
            [TestCase("999, 1, 250", 1250)]
            public void Add_GivenMultipleNumbers_ShouldReturnSumOfNumbers(string input, int expectedSum)
            {
                //Arrange
                var sut = new StringKata();
                //Act
                var result = sut.Add(input);
                //Assert
                Assert.That(result, Is.EqualTo(expectedSum));
            }
            
            [TestCase("//;\n1; 2; 3", 6)]
            [TestCase("//[]\n25[] 25, 50", 100)]
            [TestCase("//{}\n999, 1{} 250", 1250)]
            public void Add_GivenCustomDelimiter_ShouldReturnSumOfNumbers(string input, int expectedSum)
            {
                //Arrange
                var sut = new StringKata();
                //Act
                var result = sut.Add(input);
                //Assert
                Assert.That(result, Is.EqualTo(expectedSum));
            }
            
            [TestCase("//;\n1; -2; 3", "-2")]
            [TestCase("//[]\n25[] 25, -50", "-50")]
            [TestCase("//{}\n999, -1{} -250", "-1,-250")]
            public void Add_GivenNegativeNumber_ShouldThrowExceptionContainingNegativeNumbers(string input, string expectedExceptionText)
            {
                //Arrange
                var sut = new StringKata();
                //Act
                var ex = Assert.Throws<Exception>(() => sut.Add(input));
                //Assert
                Assert.That(ex.Message, Is.EqualTo(expectedExceptionText));
            }
    }
}