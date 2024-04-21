namespace GeoMathLib;

/// <summary>
///     Represents a triangle figure.
/// </summary>
public sealed class Triangle : Figure
{
    private readonly Lazy<bool> _isRight;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Triangle" /> class with the specified side lengths.
    /// </summary>
    /// <param name="sideA">The length of side A.</param>
    /// <param name="sideB">The length of side B.</param>
    /// <param name="sideC">The length of side C.</param>
    /// <exception cref="ArgumentException">Thrown when the side lengths cannot form a valid triangle.</exception>
    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            throw new ArgumentException("Side lengths must be positive non-zero values.");

        var sides = GetSortedSides(sideA, sideB, sideC);
        if (sides[0] + sides[1] <= sides[2])
            throw new ArgumentException(
                "Invalid triangle: The lengths of the sides provided do not allow for a valid triangle to be formed.");

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;

        _isRight = new Lazy<bool>(CalculateIsRight);
    }

    /// <summary>
    ///     Gets the length of side A of the triangle.
    /// </summary>
    public double SideA { get; }

    /// <summary>
    ///     Gets the length of side B of the triangle.
    /// </summary>
    public double SideB { get; }

    /// <summary>
    ///     Gets the length of side C of the triangle.
    /// </summary>
    public double SideC { get; }

    /// <summary>
    ///     Gets a value indicating whether the triangle is a right triangle.
    /// </summary>
    public bool IsRight => _isRight.Value;

    /// <summary>
    ///     Calculates and returns the square of the triangle using Heron's formula.
    /// </summary>
    /// <returns>The square of the triangle.</returns>
    protected override double GetSquare()
    {
        var semiPerimeter = (SideA + SideB + SideC) / 2;

        return Math.Sqrt(semiPerimeter
                         * (semiPerimeter - SideA)
                         * (semiPerimeter - SideB)
                         * (semiPerimeter - SideC));
    }

    /// <summary>
    ///     Helper method to sort the sides of a triangle in ascending order.
    /// </summary>
    /// <param name="sideA">The length of side A.</param>
    /// <param name="sideB">The length of side B.</param>
    /// <param name="sideC">The length of side C.</param>
    /// <returns>An array containing the side lengths sorted in ascending order.</returns>
    private static double[] GetSortedSides(double sideA, double sideB, double sideC)
    {
        var sides = new[] { sideA, sideB, sideC };
        Array.Sort(sides);
        return sides;
    }

    /// <summary>
    ///     Calculates whether a triangle with the specified side lengths is a right triangle using Pythagorean theorem.
    /// </summary>
    /// <returns>True if the triangle is a right triangle; otherwise, false.</returns>
    private bool CalculateIsRight()
    {
        var sides = GetSortedSides(SideA, SideB, SideC);

        // Pythagorean theorem
        return Math.Abs(sides[0] * sides[0] + sides[1] * sides[1] - sides[2] * sides[2]) < Constants.Accuracy;
    }
}