using FluentAssertions;

namespace ProgressionFramework_Dante_Level0.DataStructures;

public class TestStringDataStructure
{
    [TestFixture]
    public class TestTree
    {
        [TestFixture]
        public class InsertAndSearch
        {
            [Test]
            public void ShouldReturnTrue_WhenInsertedWordIsSearched()
            {
                //Arrange
                var tree = new Tree();

                //Act
                tree.Insert("apple");
                var result = tree.Search("apple");

                //Assert
                result.Should().BeTrue();
            }

            [Test]
            public void ShouldReturnFalse_WhenWordIsNotInserted()
            {
                //Arrange
                var tree = new Tree();

                //Act
                tree.Insert("apple");
                var result = tree.Search("banana");

                //Assert
                result.Should().BeFalse();
            }

            [Test]
            public void ShouldReturnFalse_WhenOnlyPrefixExists()
            {
                //Arrange
                var tree = new Tree();

                //Act
                tree.Insert("apple");
                var result = tree.Search("app");

                //Assert
                result.Should().BeFalse();
            }

            [Test]
            public void ShouldHandleMultipleInsertions()
            {
                //Arrange
                var tree = new Tree();

                //Act
                tree.Insert("apple");
                tree.Insert("app");
                tree.Insert("bat");
                var appleFound = tree.Search("apple");
                var appFound = tree.Search("app");
                var batFound = tree.Search("bat");

                //Assert
                appleFound.Should().BeTrue();
                appFound.Should().BeTrue();
                batFound.Should().BeTrue();
            }
        }

        [TestFixture]
        public class StartsWith
        {
            [Test]
            public void ShouldReturnTrue_WhenPrefixExists()
            {
                //Arrange
                var tree = new Tree();

                //Act
                tree.Insert("apple");
                var result = tree.StartsWith("ap");

                //Assert
                result.Should().BeTrue();
            }

            [Test]
            public void ShouldReturnFalse_WhenPrefixDoesNotExist()
            {
                //Arrange
                var tree = new Tree();

                //Act
                tree.Insert("apple");
                var result = tree.StartsWith("ba");

                //Assert
                result.Should().BeFalse();
            }
        }
    }
}
