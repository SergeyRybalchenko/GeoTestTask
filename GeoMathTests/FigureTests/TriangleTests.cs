using GeoMathLib;

namespace GeoMathTests.FigureTests;

public class TriangleTests
{
    [Theory]
    [InlineData(3, 4, 5, true)] // right triangle
    [InlineData(5, 12, 13, true)] // right triangle
    [InlineData(6, 8, 10, true)] // right triangle
    [InlineData(3, 3, 3, false)] // equilateral triangle
    [InlineData(5, 5, 8, false)] // isosceles triangle
    [InlineData(7, 8, 9, false)] // scalene triangle
    public void Triangle_WithValidSides_CreatesInstance(double sideA, double sideB, double sideC, bool isRight)
    {
        // Arrange & Act
        var triangle = new Triangle(sideA, sideB, sideC);

        // Assert
        Assert.NotNull(triangle);
        Assert.Equal(sideA, triangle.SideA, 10);
        Assert.Equal(sideB, triangle.SideB, 10);
        Assert.Equal(sideC, triangle.SideC, 10);
        Assert.Equal(isRight, triangle.IsRight);
    }

    [Theory]
    [InlineData(0, 4, 5)] // sideA is zero
    [InlineData(3, 0, 5)] // sideB is zero
    [InlineData(3, 4, 0)] // sideC is zero
    [InlineData(-3, 4, 5)] // sideA is negative
    [InlineData(3, -4, 5)] // sideB is negative
    [InlineData(3, 4, -5)] // sideC is negative
    [InlineData(1, 2, 3)] // invalid sides for a triangle
    [InlineData(1, 1, 2)] // invalid sides for a triangle
    [InlineData(2, 3, 7)] // invalid sides for a triangle
    public void Triangle_WithInvalidSides_ThrowsArgumentException(double sideA, double sideB, double sideC)
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }

    [Theory]
    [InlineData(3, 4, 5, 6)] // valid sides
    [InlineData(5, 12, 13, 30)] // valid sides
    [InlineData(6, 8, 10, 24)] // valid sides
    [InlineData(3, 3, 3, 3.8971143170299753)] // equilateral triangle
    [InlineData(5, 5, 8, 12)] // isosceles triangle
    [InlineData(7, 8, 9, 26.832815729997478)] // scalene triangle
    public void GetSquare_ReturnsCorrectValue(double sideA, double sideB, double sideC, double expectedSquare)
    {
        // Arrange
        var triangle = new Triangle(sideA, sideB, sideC);

        // Act
        var actualSquare = triangle.Square;

        // Assert
        Assert.Equal(expectedSquare, actualSquare, 10);
    }
}