using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace ProgressionFramework_Dante_Level0.Katas;

public class ParseIntKata
{
    private static readonly Dictionary<string, int> Numbers = new()
    {
        {"zero", 0}, {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4},
        {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9},
        {"ten", 10}, {"eleven", 11}, {"twelve", 12}, {"thirteen", 13}, {"fourteen", 14},
        {"fifteen", 15}, {"sixteen", 16}, {"seventeen", 17}, {"eighteen", 18}, {"nineteen", 19},
        {"twenty", 20}, {"thirty", 30}, {"forty", 40}, {"fifty", 50}, {"sixty", 60},
        {"seventy", 70}, {"eighty", 80}, {"ninety", 90},
        {"hundred", 100}, {"thousand", 1000}, {"million", 1000000}
    };

    public static int ParseInt(string s)
    {
        s = s.Replace(" and ", " ");
        var words = s.Split(new[]
        {
            ' ', '-'
        }, StringSplitOptions.RemoveEmptyEntries);

        int total = 0, current = 0;
        foreach (var word in words)
        {
            if (Numbers.ContainsKey(word))
            {
                int num = Numbers[word];
                if (num == 100)
                {
                    current *= num;
                }
                else if (num >= 1000)
                {
                    total += current * num;
                    current = 0;
                }
                else
                {
                    current += num;
                }
            }
        }
        return total + current;
    }
}

public class TestsParseIntKata
{
    [TestCase("zero", 0)]
    [TestCase("one", 1)]
    [TestCase("twenty", 20)]
    [TestCase("one hundred", 100)]
    [TestCase("one hundred one", 101)]
    [TestCase("two hundred forty-six", 246)]
    [TestCase("ten thousand", 10000)]
    [TestCase("twenty-six thousand three hundred and fifty-nine", 26359)]
    [TestCase("twenty-nine thousand two hundred and forty-four", 29244)]
    [TestCase("six hundred sixty-six thousand six hundred sixty-six", 666666)]
    [TestCase("six hundred thirty-nine thousand eight hundred twenty-eight", 639828)]
    [TestCase("seven hundred thousand", 700000)]
    [TestCase("two hundred thousand three", 200003)]
    public void FixedTests(string number, int expectedResult)
    {
        Assert.That(ParseIntKata.ParseInt(number), Is.EqualTo(expectedResult));
    }
}
