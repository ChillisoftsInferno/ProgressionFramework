namespace ProgressionFramework_Dante_Level0.Katas;

using System.Collections;
public class SnailKata
{
    private static int skipRow = 0;
    private static int skipColumn = 0;
    private static int width = 0;
    private static int height = 0;
    private static int totalNumbers = 0;
    public static int[] Snail(int[][] numbers)
    {
        ResetValues();
        var numbersList = new List<int>();
        totalNumbers = GetNumbersTotal(numbers);
        LoopSequence(numbers, numbersList);
        return numbersList.ToArray();
    }

    private static void ResetValues()
    {
        skipRow = 0;
        skipColumn = 0;
        width = 0;
        height = 0;
        totalNumbers = 0;
    }

    private static void LoopSequence(int[][] numbers, List<int> numbersList)
    {
        width = GetTotalColumnsCount(numbers);
        height = GetTotalRowsCount(numbers);

        do
        {
            numbersList.AddRange(numbers.GetEntireFirstRow(skipRow, skipColumn, width));
            skipRow++;

            numbersList.AddRange(numbers.GetLastInEachRow(skipRow, skipColumn, width, height));
            width--;

            numbersList.AddRange(numbers.GetEntireRowInReverse(skipRow, skipColumn, width, height));
            height--;

            numbersList.AddRange(numbers.GetFirstInEachRow(skipRow, skipColumn, width, height));
            skipColumn++;
            width--;

        } while (numbersList.Count < totalNumbers);
    }

    public static int GetNumbersTotal(int[][] numbers)
    {
        return numbers.Length * numbers[0].Length;
    }

    private static int GetTotalColumnsCount(int[][] numbers)
    {
        return numbers.Length;
    }

    private static int GetTotalRowsCount(int[][] numbers)
    {
        return numbers[0].Length;
    }

    public int[] GetSequenceOfNumbers(int[][] numbers)
    {
        int x = numbers.Length;
        int sequenceLength = x * 2 - 1;
        int[] sequence = new int[sequenceLength];
        bool hasBeenAdded = false;
        int currentSequenceNumber = 1;
        for (int i = 0; i < sequenceLength; i++)
        {
            if (hasBeenAdded)
            {
                sequence[i] = currentSequenceNumber;
                hasBeenAdded = false;
                currentSequenceNumber++;
            }
            else
            {
                sequence[i] = currentSequenceNumber;
                hasBeenAdded = true;
            }
        }
        return sequence.Reverse().ToArray();
    }
}

public static class SnailKataExtensions
{
    public static IEnumerable<int> GetEntireFirstRow(this int[][] numbers2DArray, int skipRow, int skipColumn, int width)
    {
        var firstRow = numbers2DArray
            .Skip(skipRow)
            .ToArray()
            .Select(x => x
                .Skip(skipColumn)
                .Take(width))
            .ToArray().First();
        foreach (int number in firstRow)
        {
            yield return number;
        }
    }

    public static IEnumerable<int> GetLastInEachRow(this int[][] numbers2DArray, int skipRow, int skipColumn, int width, int height)
    {
        var lastColumn = numbers2DArray
            .Skip(skipRow)
            .Take(height - skipRow)
            .Select(x => x.Skip(skipColumn)
                .Take(width)
                .Last());
        
        foreach (int number in lastColumn)
        {
            yield return number;
        }
    }

    public static IEnumerable<int> GetEntireRowInReverse(this int[][] numbers2DArray, int skipRow, int skipColumn, int width, int height)
    {
        var reversedLastRow = numbers2DArray
            .Skip(height - 1)
            .First()
            .Skip(skipColumn)
            .Take(width)
            .Reverse();
        foreach (int number in reversedLastRow)
        {
            yield return number;
        }
    }
    
    public static IEnumerable<int> GetFirstInEachRow(this int[][] numbers2DArray, int skipRow, int skipColumn, int width, int height)
    {
        var firstColumn = numbers2DArray
            .Skip(skipRow)
            .Take(height - skipRow)
            .Select(x => x.Skip(skipColumn)
                .Take(width)
                .First())
            .Reverse();
        foreach (int number in firstColumn)
        {
            yield return number;
        }
    }
}

[TestFixture]
internal class TestSnailKata
{
    [TestCase(2, new int[] { 1, 2, 4, 3 } )]
    [TestCase(3, new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 } )]
    [TestCase(4, new int[] { 1, 2, 3, 4, 8, 12, 16, 15, 14, 13, 9, 5, 6, 7, 11, 10 } )]
    [TestCase(5, new int[] { 1, 2, 3, 4, 5, 10, 15, 20, 25, 24, 23, 22, 21, 16, 11, 6, 7, 8, 9, 14, 19, 18, 17, 12, 13 } )]
    [TestCase(6, new int[] { 1, 2, 3, 4, 5, 6, 12, 18, 24, 30, 36, 35, 34, 33, 32, 31, 25, 19, 13, 7, 8, 9, 10, 11, 17, 23, 29, 28, 27, 26, 20, 14, 15, 16, 22, 21 } )]
    public void GetNumbers_InNormalOrder_GivenTwoDimensionalArray(int size, int[] expectedNumbers)
    {
        //Arrange
        var sut = new SnailKata();
        var numbers2DArray = SnailKataNumbersBuilderBuilder(size);
        
        //Act
        var result = SnailKata.Snail(numbers2DArray);
        
        //Assert
        Assert.That(result, Is.EqualTo(expectedNumbers));
    }

    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9)]
    public void GivenTwoDimensionalArray_ShouldReturnTotalAmountOfNumbers(int[] numbers, int expectedTotalAmount)
    {
        //Arrange
        var sut = new SnailKata();
        var expected = 9;
        var numbers2DArray = SnailKataNumbersBuilderBuilder(3);
        
        //Act
        var result = SnailKata.GetNumbersTotal(numbers2DArray);
        
        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(2, new int[] { 2, 1, 1 })]
    [TestCase(3, new int[] { 3, 2, 2, 1, 1 })]
    [TestCase(4, new int[] { 4, 3, 3, 2, 2, 1, 1 })]
    [TestCase(5, new int[] { 5, 4, 4, 3, 3, 2, 2, 1, 1 })]
    public void GivenTwoDimensionalArrayOfCertainSize_ShouldReturnCorrectSequenceToFollow(int size, int[] expectedSequence)
    {
        //Arrange
        int[][] numbers2DArray = SnailKataNumbersBuilderBuilder(size);
        var sut = new SnailKata();
        
        //Act
        int[] result = sut.GetSequenceOfNumbers(numbers2DArray);
        
        //Assert
        Assert.That(result, Is.EqualTo(expectedSequence));
    }
    
    private int[][] SnailKataNumbersBuilderBuilder(int size)
    {
        switch (size)
        {
            case 3: 
                return new int[][] 
                { 
                    [1,2,3],
                    [4,5,6],
                    [7,8,9]
                };
            case 4:
                return new int[][] 
                { 
                    [1, 2, 3, 4 ],
                    [5, 6, 7, 8 ],
                    [9, 10,11,12],
                    [13,14,15,16]
                };
            case 5:
                return new int[][] 
                { 
                    [1, 2, 3, 4 , 5],
                    [6, 7, 8, 9 ,10],
                    [11,12,13,14,15],
                    [16,17,18,19,20],
                    [21,22,23,24,25]
                };
            case 6:
                return new int[][] 
                { 
                    [1 , 2, 3, 4, 5, 6],
                    [7 , 8, 9,10,11,12],
                    [13,14,15,16,17,18],
                    [19,20,21,22,23,24],
                    [25,26,27,28,29,30],
                    [31,32,33,34,35,36],
                };
            default:
                return new int[][] 
                { 
                    [1,2],
                    [3,4]
                };
        }
    }
}
