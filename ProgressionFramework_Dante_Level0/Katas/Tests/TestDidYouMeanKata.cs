namespace ProgressionFramework_Dante_Level0.Katas.Tests;

[TestFixture]
public class TestDidYouMeanKata
{
    [Test, Order(1)]
    public void TestDictionary1()
    {
        DidYouMeanKata kata = new DidYouMeanKata(new List<string> { "cherry", "pineapple", "melon", "strawberry", "raspberry" });
        Assert.That(kata.FindMostSimilar("strawbery"), Is.EqualTo("strawberry"));
        Assert.That(kata.FindMostSimilar("berry"), Is.EqualTo("cherry"));
    }
    
    [Test, Order(2)]
    public void TestDictionary2()
    {
        DidYouMeanKata kata = new DidYouMeanKata(new List<string> { "javascript", "java", "ruby", "php", "python", "coffeescript" });
        Assert.That(kata.FindMostSimilar("heaven"), Is.EqualTo("java"));
        Assert.That(kata.FindMostSimilar("javascript"), Is.EqualTo("javascript"));
        Assert.That(kata.FindMostSimilar("script"), Is.EqualTo("javascript"));
    }
}