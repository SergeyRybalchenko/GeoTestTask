namespace GeoMathLib;

/// <summary>
///     Represents a circle figure.
/// </summary>
public sealed class Circle : Figure
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Circle" /> class with the specified radius.
    /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    /// <exception cref="ArgumentException">Thrown when the radius is negative.</exception>
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("The radius of the circle cannot be negative or zeo.", nameof(radius));

        Radius = radius;
    }

    /// <summary>
    ///     Gets the radius of the circle.
    /// </summary>
    public double Radius { get; }

    /// <summary>
    ///     Calculates and returns the square of the circle.
    /// </summary>
    /// <returns>The square of the circle.</returns>
    protected override double GetSquare()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}