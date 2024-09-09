namespace ProgressionFramework_Dante_Level0.DotNet_Basics;

[TestFixture]
public class StructTests
{
    // Confirms that the struct can be instantiated with correct values.
    [Test]
    public void TestStruct_CanBeInstantiatedWithValues_ShouldHaveCorrectValues()
    {
        //Arrange
        int expectedX = 5;
        int expectedY = 10;

        //Act
        var point = new Point(expectedX, expectedY);

        //Assert
        Assert.That(point.X, Is.EqualTo(expectedX));
        Assert.That(point.Y, Is.EqualTo(expectedY));
    }

    // Confirms that the DistanceFromOrigin method calculates the correct distance.
    [Test]
    public void TestStruct_DistanceFromOrigin_ShouldBeCorrect()
    {
        //Arrange
        var point = new Point(3, 4);
        double expectedDistance = 5.0; // sqrt(3^2 + 4^2) = 5

        //Act
        double actualDistance = point.DistanceFromOrigin();

        //Assert
        Assert.That(actualDistance, Is.EqualTo(expectedDistance));
    }

    // Confirms that the Move method updates the point's coordinates correctly.
    [Test]
    public void TestStruct_Move_ShouldUpdateCoordinates()
    {
        //Arrange
        var point = new Point(1, 1);
        int deltaX = 3;
        int deltaY = 4;
        int expectedX = 4;
        int expectedY = 5;

        //Act
        point.Move(deltaX, deltaY);

        //Assert
        Assert.That(point.X, Is.EqualTo(expectedX));
        Assert.That(point.Y, Is.EqualTo(expectedY));
    }

    // Confirms that a default struct has default values for its fields.
    [Test]
    public void TestStruct_DefaultConstructor_ShouldHaveDefaultValues()
    {
        //Arrange
        var point = new Point();

        //Act
        int defaultX = point.X;
        int defaultY = point.Y;

        //Assert
        Assert.That(defaultX, Is.EqualTo(0));
        Assert.That(defaultY, Is.EqualTo(0));
    }

    // Confirms that struct equality works as expected.
    [Test]
    public void TestStruct_Equality_ShouldBeCorrect()
    {
        //Arrange
        var point1 = new Point(2, 3);
        var point2 = new Point(2, 3);

        //Act
        bool areEqual = point1.Equals(point2);

        //Assert
        Assert.IsTrue(areEqual);
    }

    // Confirms that struct inequality works as expected.
    [Test]
    public void TestStruct_Inequality_ShouldBeCorrect()
    {
        //Arrange
        var point1 = new Point(2, 3);
        var point2 = new Point(3, 4);

        //Act
        bool areNotEqual = !point1.Equals(point2);

        //Assert
        Assert.IsTrue(areNotEqual);
    }
    
    private struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double DistanceFromOrigin()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public void Move(int deltaX, int deltaY)
        {
            X += deltaX;
            Y += deltaY;
        }
    }
}

