namespace ProgressionFramework_Dante_Level0.DotNet_Basics;

[TestFixture]
public class TypeConversion
{
    [Test]
    public void TestTypeConversion_ImplicitConversionFromIntToDouble_ShouldConvertCorrectly()
    {
        //Arrange
        int intValue = 5;
        double expectedValue = 5.0;

        //Act
        double actualValue = intValue;

        //Assert
        Assert.That(actualValue, Is.EqualTo(expectedValue));
    }

    // Confirms that explicit conversion from double to int works correctly.
    [Test]
    public void TestTypeConversion_ExplicitConversionFromDoubleToInt_ShouldConvertCorrectly()
    {
        //Arrange
        double doubleValue = 5.9;
        int expectedValue = 5;

        //Act
        int actualValue = (int)doubleValue;

        //Assert
        Assert.That(actualValue, Is.EqualTo(expectedValue));
    }

    // Confirms that string to int conversion using int.Parse works correctly.
    [Test]
    public void TestTypeConversion_StringToIntConversion_ShouldConvertCorrectly()
    {
        //Arrange
        string stringValue = "123";
        int expectedValue = 123;

        //Act
        int actualValue = int.Parse(stringValue);

        //Assert
        Assert.That(actualValue, Is.EqualTo(expectedValue));
    }

    // Confirms that string to int conversion using int.TryParse works correctly.
    [Test]
    public void TestTypeConversion_StringToIntConversionUsingTryParse_ShouldConvertCorrectly()
    {
        //Arrange
        string stringValue = "456";
        int expectedValue = 456;
        bool parseSuccess;

        //Act
        parseSuccess = int.TryParse(stringValue, out int actualValue);

        //Assert
        Assert.IsTrue(parseSuccess);
        Assert.That(actualValue, Is.EqualTo(expectedValue));
    }

    // Confirms that object to string conversion using ToString works correctly.
    [Test]
    public void TestTypeConversion_ObjectToStringConversion_ShouldConvertCorrectly()
    {
        //Arrange
        object intValue = 789;
        string expectedValue = "789";

        //Act
        string? actualValue = intValue.ToString();

        //Assert
        Assert.That(actualValue, Is.EqualTo(expectedValue));
    }
    
    // Confirms that object and properties to string conversion using overriden ToString works correctly.
    [TestCase("", "No movie name entered. Please try again.")]
    [TestCase("Suicide Squad", "Movie: Suicide Squad not found in database, in other words... It failed.")]
    [TestCase("Finding Nemo", "Movie: Finding Nemo, Renowned Phrase: Sharkbait huhaha - Times Repeated: 5, BoxOffice Failed: False, Chlorine Levels in Tank: 7.8")]
    public void TestTypeConversion_ObjectToStringConversion_ShouldNotThrow(string movieName, string expectedValue)
    {
        //Arrange
        MovieStats movieStats = new MovieStats(movieName);

        //Act
        string actualValue = movieStats.ToString();

        //Assert
        Assert.That(actualValue, Is.EqualTo(expectedValue));
    }

    private class MovieStats
    {
        private string _movieName = "";
        private string _phrase = "Sharkbait huhaha";
        private int _timesPhraseWasRepeated = 5;
        private double _tankChlorineLevels = 7.8;
        private bool _wasBoxOfficeFailure = false;

        public MovieStats(string movieName = "")
        {
            _movieName = movieName;
        }
        
        public override string ToString()
        {
            if (string.IsNullOrEmpty(_movieName)) return "No movie name entered. Please try again.";
            
            if(_movieName != "Finding Nemo") return $"Movie: {_movieName} not found in database, in other words... It failed.";
            
            return $"Movie: {_movieName}, Renowned Phrase: {_phrase} - Times Repeated: {_timesPhraseWasRepeated}, " +
                   $"BoxOffice Failed: {_wasBoxOfficeFailure}, Chlorine Levels in Tank: {_tankChlorineLevels}";
        }
    }
}