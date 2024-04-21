namespace GeoMathLib;

/// <summary>
///     Represents a geometric figure with a calculable square.
/// </summary>
public abstract class Figure
{
    private readonly Lazy<double> _square;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Figure" /> class.
    /// </summary>
    protected Figure()
    {
        _square = new Lazy<double>(GetSquare);
    }

    /// <summary>
    ///     Gets the square of the figure.
    /// </summary>
    public double Square => _square.Value;

    /// <summary>
    ///     Calculates and returns the square of the figure.
    /// </summary>
    /// <returns>The square of the figure.</returns>
    protected abstract double GetSquare();
}