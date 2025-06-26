namespace ProgressionFramework_Dante_Level0.Katas.Tests;

[TestFixture]
public class TestStringsMixKata
{
    [TestFixture]
    public class CodeWarsTests
    {
        [Test]
        public void Test1()
        {
            //Arrange
            var sut = new StringMixKata();
            //Act
            //Assert
            Assert.That(sut.Mix("Are they here", "yes, they are here"),
                Is.EqualTo("2:eeeee/2:yy/=:hh/=:rr"));
        }

        [Test]
        public void Test2()
        {
            //Arrange
            var sut = new StringMixKata();
            //Act
            //Assert
            Assert.That(sut.Mix("looping is fun but dangerous", "less dangerous than coding"),
                Is.EqualTo("1:ooo/1:uuu/2:sss/=:nnn/1:ii/2:aa/2:dd/2:ee/=:gg"));
        }
        
        [Test]
        public void Test3()
        {
            //Arrange
            var sut = new StringMixKata();
            //Act
            //Assert
            Assert.That(sut.Mix(" In many languages", " there's a pair of functions"),
                Is.EqualTo("1:aaa/1:nnn/1:gg/2:ee/2:ff/2:ii/2:oo/2:rr/2:ss/2:tt"));
        }
        
        [Test]
        public void Test4()
        {
            //Arrange
            var sut = new StringMixKata();
            //Act
            //Assert
            Assert.That(sut.Mix("Lords of the Fallen", "gamekult"),
                Is.EqualTo("1:ee/1:ll/1:oo"));
        }
        
        [Test]
        public void Test5()
        {
            //Arrange
            var sut = new StringMixKata();
            //Act
            //Assert
            Assert.That(sut.Mix("codewars", "codewars"),
                Is.EqualTo(""));
        }
        
        [Test]
        public void Test6()
        {
            //Arrange
            var sut = new StringMixKata();
            //Act
            //Assert
            Assert.That(sut.Mix("A generation must confront the looming ", "codewarrs"),
                Is.EqualTo("1:nnnnn/1:ooooo/1:tttt/1:eee/1:gg/1:ii/1:mm/=:rr"));
        }
    }
    
    [TestFixture]
    public class Mix
    {
        [Test]
        public void GivenEmptyString1_ShouldThrowException()
        {
            //Arrange
            var sut = new StringMixKata();
            var string1 = "";
            var string2 = "Almost empty";
            
            //Act

            //Assert    
        }
    }
    
    [TestFixture]
    public class SplitString
    {
        
    }
}
