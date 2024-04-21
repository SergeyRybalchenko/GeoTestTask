using GeoMathLib;

namespace GeoMathTests.FigureTests;

public class CircleTests
{
    [Fact]
    public void Circle_WithPositiveRadius_CreatesInstance()
    {
        // Arrange
        const double radius = 5;

        // Act
        var circle = new Circle(radius);

        // Assert
        Assert.NotNull(circle);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_InvalidRadius_ThrowsArgumentException(double radius)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void GetSquare_ReturnsCorrectValue(double radius)
    {
        // Arrange
        var circle = new Circle(radius);
        var expectedSquare = Math.PI * radius * radius;

        // Act
        var actualSquare = circle.Square;

        // Assert
        Assert.Equal(expectedSquare, actualSquare, 10);
    }
}