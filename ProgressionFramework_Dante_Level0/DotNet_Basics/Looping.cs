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
            int[] values = new int[] { 5, 10, 15, 20, 25 };
            int total = 0;
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
                if (values[i].StartsWith("se", StringComparison.CurrentCultureIgnoreCase)) results.Add(values[i]);
            }
            //Assert
            Assert.That(results, Is.EquivalentTo(new List<string>() { "Sean", "Sedrick", "Selena" }));
        }
        
        [Test]
        public void GivenAWord_TestHowManySpecificCharactersAreInWord_ReturnNewStringContainingOnlyCharacters()
        {
            //Arrange
            string vowels = "aeiou";
            string testString = "Albany";

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
            string vowels = "aeiou";
            string testString = "The fox jumped over the hill and ran from the farmer";

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
            string vowels = "aeiou";
            string testString = "The fox jumped over the hill and ran from the farmer";

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

    [TestFixture]
    public class ForEachLoopTests
    {
        // Validates that a foreach loop correctly sums the elements of a list of integers.
        [Test]
        public void TestForEachLoop_SumElements_ShouldBeCorrect()
        {
            //Arrange
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            int expectedSum = 15;
            int actualSum = 0;
            //Act
            foreach (int number in numbers)
            {
                actualSum += number;
            }
            //Assert
            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }

        // Ensures that a foreach loop can concatenate strings from a list.
        [Test]
        public void TestForEachLoop_ConcatenateStrings_ShouldBeCorrect()
        {
            //Arrange
            var words = new List<string> { "Hello", "World", "!" };
            string expected = "HelloWorld!";
            string actual = string.Empty;
            //Act
            foreach (string word in words)
            {
                actual += word;
            }
            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        // Confirms that iterating over an empty collection does not modify the result (sum remains 0).
        [Test]
        public void TestForEachLoop_IterateOverEmptyCollection_ShouldDoNothing()
        {
            //Arrange
            // ReSharper disable once CollectionNeverUpdated.Local
            var emptyList = new List<int>();
            int sum = 0;
            //Act
            foreach (int item in emptyList)
            {
                sum += item;
            }
            //Assert
            Assert.That(sum, Is.EqualTo(0));
        }

        // Demonstrates that modifying elements within a list using a for loop is possible, but not directly with foreach.
        [Test]
        public void TestForEachLoop_ModifyElements_ShouldBeCorrect()
        {
            //Arrange
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var expected = new List<int> { 2, 4, 6, 8, 10 };
            //Act
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] *= 2;
            }
            //Assert
            CollectionAssert.AreEqual(expected, numbers);
        }

        // Verifies that a foreach loop correctly counts the elements in a collection.
        [Test]
        public void TestForEachLoop_CountElements_ShouldBeCorrect()
        {
            //Arrange
            var numbers = new List<int> { 10, 20, 30, 40, 50 };
            int expectedCount = 150;
            int actualCount = 0;
            //Act
            foreach (int number in numbers)
            {
                actualCount += number;
            }
            //Assert
            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }

        // Checks if all elements in a collection satisfy a condition (e.g., all numbers are even).
        [Test]
        public void TestForEachLoop_CheckConditionOnElements_ShouldReturnTrue()
        {
            //Arrange
            var numbers = new List<int> { 2, 4, 6, 8, 10 };
            bool allEven = true;
            //Act
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    continue;
                }

                allEven = false;
                break;
            }
            //Assert
            Assert.IsTrue(allEven);
        }

        // Tests a nested foreach loop by summing the elements in a matrix (list of lists).
        [Test]
        public void TestForEachLoop_WithNestedLoop_ShouldBeCorrect()
        {
            //Arrange
            var matrix = new List<List<int>>
            {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 },
                new List<int> { 7, 8, 9 }
            };
            int expectedSum = 45;
            int actualSum = 0;
            //Act
            foreach (var row in matrix)
            {
                foreach (int number in row)
                {
                    actualSum += number;
                }
            }
            //Assert
            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }

        // Validates that modifying a collection inside a foreach loop throws an InvalidOperationException.
        [Test]
        public void TestForEachLoop_ModifyCollectionInsideLoop_ShouldThrowException()
        {
            //Arrange
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            //Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (int number in numbers)
                {
                    if (number == 3)
                    {
                        numbers.Remove(number);
                    }
                }
            });
        }

        // Confirms that a foreach loop correctly iterates over an array.
        [Test]
        public void TestForEachLoop_IterateOverArray_ShouldBeCorrect()
        {
            //Arrange
            int[] numbers = new int[] { 10, 20, 30 };
            int[] expected = new int[] { 10, 20, 30 };
            var actual = new List<int>();
            //Act
            foreach (int number in numbers)
            {
                actual.Add(number);
            }
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        // Verifies that a foreach loop correctly iterates over a dictionary, retrieving both keys and values.
        [Test]
        public void TestForEachLoop_IterateOverDictionary_ShouldBeCorrect()
        {
            //Arrange
            var dictionary = new Dictionary<string, int>
            {
                { "A", 1 },
                { "B", 2 },
                { "C", 3 }
            };
            var expectedKeys = new List<string> { "A", "B", "C" };
            var expectedValues = new List<int> { 1, 2, 3 };
            var actualKeys = new List<string>();
            var actualValues = new List<int>();
            //Act
            foreach (var kvp in dictionary)
            {
                actualKeys.Add(kvp.Key);
                actualValues.Add(kvp.Value);
            }
            //Assert
            CollectionAssert.AreEqual(expectedKeys, actualKeys);
            CollectionAssert.AreEqual(expectedValues, actualValues);
        }
    }
    
    [TestFixture]
    public class WhileLoopTests
    {
        // Validates that a while loop correctly sums numbers until a condition is met.
        [Test]
        public void TestWhileLoop_SumUntilConditionMet_ShouldBeCorrect()
        {
            //Arrange
            int number = 1;
            int sum = 0;
            int limit = 5;
            int expectedSum = 15; // 1 + 2 + 3 + 4 + 5

            //Act
            while (number <= limit)
            {
                sum += number;
                number++;
            }

            //Assert
            Assert.That(sum, Is.EqualTo(expectedSum));
        }

        // Ensures that a while loop does not execute if the initial condition is false.
        [Test]
        public void TestWhileLoop_ConditionFalseInitially_ShouldNotExecute()
        {
            //Arrange
            int number = 10;
            int sum = 0;

            //Act
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            while (number < 5)
            {
                sum += number;
                number++;
            }

            //Assert
            Assert.That(sum, Is.EqualTo(0));
        }

        // Tests that a while loop exits when a specific condition is met using break.
        [Test]
        public void TestWhileLoop_ExitCondition_ShouldStopAtCorrectValue()
        {
            //Arrange
            int number = 1;
            int limit = 5;

            //Act
            while (number < 10)
            {
                if (number == limit)
                    break;
                number++;
            }

            //Assert
            Assert.That(number, Is.EqualTo(limit));
        }

        // Checks if a while loop correctly removes elements from a list until it is empty.
        [Test]
        public void TestWhileLoop_ModifyListUntilEmpty_ShouldBeCorrect()
        {
            //Arrange
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            //Act
            while (numbers.Count > 0)
            {
                numbers.RemoveAt(0);
            }

            //Assert
            Assert.That(numbers.Count, Is.EqualTo(0));
        }

        // Ensures that a while loop correctly iterates over an array and sums only even numbers.
        [Test]
        public void TestWhileLoop_IterateOverArrayWithCondition_ShouldSumEvenNumbers()
        {
            //Arrange
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            int sum = 0;
            int i = 0;
            int expectedSum = 12; // 2 + 4 + 6

            //Act
            while (i < numbers.Length)
            {
                if (numbers[i] % 2 == 0)
                {
                    sum += numbers[i];
                }
                i++;
            }

            //Assert
            Assert.That(sum, Is.EqualTo(expectedSum));
        }

        // Validates that a while loop skips a specific iteration using continue.
        [Test]
        public void TestWhileLoop_WithContinue_ShouldSkipSpecificIteration()
        {
            //Arrange
            int number = 0;
            int limit = 5;
            int expectedSum = 10; // 1 + 2 + 3 + 4

            int sum = 0;

            //Act
            while (number < limit)
            {
                number++;
                if (number == 3)
                    continue;
                sum += number;
            }

            //Assert
            Assert.That(sum, Is.EqualTo(expectedSum));
        }

        // Tests that the while loop counts iterations correctly.
        [Test]
        public void TestWhileLoop_CountIterations_ShouldBeCorrect()
        {
            //Arrange
            int number = 0;
            int limit = 5;
            int expectedIterations = 5;
            int actualIterations = 0;

            //Act
            while (number < limit)
            {
                actualIterations++;
                number++;
            }

            //Assert
            Assert.That(actualIterations, Is.EqualTo(expectedIterations));
        }

        // Ensures that a potentially endless while loop exits correctly when a condition is met.
        [Test]
        public void TestWhileLoop_EndlessLoopWithBreak_ShouldExit()
        {
            //Arrange
            int count = 0;
            int limit = 100;

            //Act
            while (true)
            {
                count++;
                if (count == limit)
                    break;
            }

            //Assert
            Assert.That(count, Is.EqualTo(limit));
        }

        // Verifies that nested while loops correctly sum the elements of a 2D array.
        [Test]
        public void TestWhileLoop_NestedWhileLoops_ShouldSumMatrixCorrectly()
        {
            //Arrange
            int[,] matrix = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int expectedSum = 45; // 1+2+3+4+5+6+7+8+9
            int actualSum = 0;

            int i = 0;
            //Act
            while (i < rows)
            {
                int j = 0;
                while (j < columns)
                {
                    actualSum += matrix[i, j];
                    j++;
                }
                i++;
            }

            //Assert
            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }

        // Confirms that a while loop can correctly iterate over a list and collect elements in a new list.
        [Test]
        public void TestWhileLoop_IterateOverListUsingWhile_ShouldBeCorrect()
        {
            //Arrange
            var list = new List<int> { 1, 2, 3, 4, 5 };
            int index = 0;
            var expectedList = new List<int> { 1, 2, 3, 4, 5 };
            var actualList = new List<int>();

            //Act
            while (index < list.Count)
            {
                actualList.Add(list[index]);
                index++;
            }

            //Assert
            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }

    [TestFixture]
    public class DoWhileLoopTests
    {
        // Validates that a do-while loop correctly sums numbers until a condition is met.
        [Test]
        public void TestDoWhileLoop_SumUntilConditionMet_ShouldBeCorrect()
        {
            //Arrange
            int number = 1;
            int sum = 0;
            int limit = 5;
            int expectedSum = 15; // 1 + 2 + 3 + 4 + 5

            //Act
            do
            {
                sum += number;
                number++;
            } while (number <= limit);

            //Assert
            Assert.That(sum, Is.EqualTo(expectedSum));
        }

        // Ensures that a do-while loop executes at least once, even if the condition is initially false.
        [Test]
        public void TestDoWhileLoop_ConditionFalseInitially_ShouldExecuteOnce()
        {
            //Arrange
            int number = 10;
            int sum = 0;

            //Act
            do
            {
                sum += number;
                number++;
            } while (number < 5);

            //Assert
            Assert.That(sum, Is.EqualTo(10));
        }

        // Tests that a do-while loop exits correctly when a specific condition is met using break.
        [Test]
        public void TestDoWhileLoop_ExitCondition_ShouldStopAtCorrectValue()
        {
            //Arrange
            int number = 1;
            int limit = 5;

            //Act
            do
            {
                if (number == limit)
                    break;
                number++;
            } while (number < 10);

            //Assert
            Assert.That(number, Is.EqualTo(limit));
        }

        // Checks if a do-while loop correctly removes elements from a list until it is empty.
        [Test]
        public void TestDoWhileLoop_ModifyListUntilEmpty_ShouldBeCorrect()
        {
            //Arrange
            var numbers = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };

            //Act
            do
            {
                numbers.RemoveAt(0);
            } while (numbers.Count > 0);

            //Assert
            Assert.That(numbers, Is.Empty);
        }

        // Ensures that a do-while loop correctly iterates over an array and sums only even numbers.
        [Test]
        public void TestDoWhileLoop_IterateOverArrayWithCondition_ShouldSumEvenNumbers()
        {
            //Arrange
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            int sum = 0;
            int i = 0;
            int expectedSum = 12; // 2 + 4 + 6

            //Act
            do
            {
                if (numbers[i] % 2 == 0)
                {
                    sum += numbers[i];
                }

                i++;
            } while (i < numbers.Length);

            //Assert
            Assert.That(sum, Is.EqualTo(expectedSum));
        }

        // Validates that a do-while loop skips a specific iteration using continue.
        [Test]
        public void TestDoWhileLoop_WithContinue_ShouldSkipSpecificIteration()
        {
            //Arrange
            int number = 0;
            int limit = 5;
            int expectedSum = 10; // 1 + 2 + 4 + 5
            int sum = 0;

            //Act
            do
            {
                number++;
                if (number == 3)
                    continue;
                sum += number;
            } while (number < limit);

            //Assert
            Assert.That(sum, Is.EqualTo(expectedSum));
        }
        
        // Tests that the do-while loop correctly counts the iterations.
        [Test]
        public void TestDoWhileLoop_CountIterations_ShouldBeCorrect()
        {
            //Arrange
            int number = 0;
            int limit = 5;
            int expectedIterations = 5;
            int actualIterations = 0;

            //Act
            do
            {
                actualIterations++;
                number++;
            } while (number < limit);

            //Assert
            Assert.That(actualIterations, Is.EqualTo(expectedIterations));
        }

        // Ensures that a potentially endless do-while loop exits correctly when a condition is met.
        [Test]
        public void TestDoWhileLoop_EndlessLoopWithBreak_ShouldExit()
        {
            //Arrange
            int count = 0;
            int limit = 100;

            //Act
            do
            {
                count++;
                if (count == limit)
                    break;
            } while (true);

            //Assert
            Assert.That(count, Is.EqualTo(limit));
        }

        // Verifies that nested do-while loops correctly sum the elements of a 2D array.
        [Test]
        public void TestDoWhileLoop_NestedLoops_ShouldSumMatrixCorrectly()
        {
            //Arrange
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int expectedSum = 45; // 1+2+3+4+5+6+7+8+9
            int actualSum = 0;

            int i = 0;

            //Act
            do
            {
                int j = 0;
                do
                {
                    actualSum += matrix[i, j];
                    j++;
                } while (j < columns);

                i++;
            } while (i < rows);

            //Assert
            Assert.That(actualSum, Is.EqualTo(expectedSum));
        }

        // Confirms that a do-while loop can correctly iterate over a list and collect elements in a new list.
        [Test]
        public void TestDoWhileLoop_IterateOverListUsingDoWhile_ShouldBeCorrect()
        {
            //Arrange
            var list = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };
            int index = 0;
            var expectedList = new List<int>
            {
                1,
                2,
                3,
                4,
                5
            };
            var actualList = new List<int>();

            //Act
            do
            {
                actualList.Add(list[index]);
                index++;
            } while (index < list.Count);

            //Assert
            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}