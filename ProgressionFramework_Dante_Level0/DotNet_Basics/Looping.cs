namespace ProgressionFramework_Dante_Level0.DotNet_Basics;

[TestFixture]
public class Looping
{
    [TestFixture]
    public class ForLoops
    {
        [Test]
        public void GivenIntValuesInArray_ShouldLoopAndAddTotalValuesInArray_ReturnSum()
        {
            //Arrange
            var values = new int[] { 5, 10, 15, 20, 25 };
            var total = 0;
            //Act
            for (int i = 0; i < values.Length; i++)
            {
                total += values[i];
            }
            //Assert
            Assert.That(total, Is.EqualTo(75));
        }
        
        [Test]
        public void GivenIntValuesInList_ShouldLoopThroughList_ReturnListContainingValuesDivisibleBy2()
        {
            //Arrange
            var values = new List<int> { 1, 2, 3, 4, 5, 10, 15, 20, 22, 24, 25, 26, 28, 30, 45, 60 };
            var results = new List<int>();
            //Act
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] % 2 == 0) results.Add(values[i]);
            }
            //Assert
            Assert.That(results, Is.EquivalentTo(new List<int>() { 2, 4, 10, 20, 22, 24, 26, 28, 30, 60 }));
        }
        
        [Test]
        public void GivenIntValuesInList_ShouldLoopThroughList_ReturnContainingValuesDivisibleBy5()
        {
            //Arrange
            var values = new List<int> { 1, 2, 3, 4, 5, 10, 15, 20, 22, 24, 25, 26, 28, 30, 45, 60 };
            var results = new List<int>();
            //Act
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] % 5 == 0) results.Add(values[i]);
            }
            //Assert
            Assert.That(results, Is.EquivalentTo(new List<int>() { 5, 10, 15, 20, 25, 30, 45, 60 }));
        }

        [Test]
        public void GivenStringValues_ShouldLoopThroughList_ReturnContainingValuesStartingWithSE()
        {
            //Arrange
            var values = new List<string> { "Sean", "Jason", "Pete", "Sedrick", "Selena", "Shaun", "George" };
            var results = new List<string>();
            //Act
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].ToLower().StartsWith("se")) results.Add(values[i]);
            }
            //Assert
            Assert.That(results, Is.EquivalentTo(new List<string>() { "Sean", "Sedrick", "Selena" }));
        }
        
        [Test]
        public void GivenAWord_TestHowManySpecificCharactersAreInWord_ReturnNewStringContainingOnlyCharacters()
        {
            //Arrange
            var vowels = "aeiou";
            var testString = "Albany";

            //Act
            string result = "";
            for (int i = 0; i < testString.Length; i++)
            {
                if (vowels.Any(v => char.ToLower(v) == char.ToLower(testString[i])))
                {
                    result += testString[i];
                }
            }

            //Assert
            Assert.That(result, Is.EqualTo("Aa"));
        }
        
        [Test]
        public void GivenASentence_TestVowelsInSentence_ReturnNewStringContainingVowelsInOrderIncludingSpaces()
        {
            //Arrange
            var vowels = "aeiou";
            var testString = "The fox jumped over the hill and ran from the farmer";

            //Act
            string result = "";
            for (int i = 0; i < testString.Length; i++)
            {
                if (testString[i] == ' ')
                {
                    result += testString[i];
                    continue;
                }
                if (vowels.Any(v => char.ToLower(v) == char.ToLower(testString[i])))
                {
                    result += testString[i];
                }
            }

            //Assert
            Assert.That(result, Is.EqualTo("e o ue oe e i a a o e ae"));
        }
        
        [Test]
        public void GivenASentence_TestVowelsInSentence_ReturnNewStringContainingNoVowelsInOrderIncludingSpaces()
        {
            //Arrange
            var vowels = "aeiou";
            var testString = "The fox jumped over the hill and ran from the farmer";

            //Act
            string result = "";
            for (int i = 0; i < testString.Length; i++)
            {
                if (testString[i] == ' ')
                {
                    result += testString[i];
                    continue;
                }
                if (vowels.All(v => char.ToLower(v) != char.ToLower(testString[i])))
                {
                    result += testString[i];
                }
            }

            //Assert
            Assert.That(result, Is.EqualTo("Th fx jmpd vr th hll nd rn frm th frmr"));
        }
    }
    
    //Fluent Assertions
}