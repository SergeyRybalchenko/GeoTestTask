using GeoMathLib;

// circle initialization
const double circleRadius = 5;
var circle = new Circle(circleRadius);

// triangle initialization
const double sideA = 3;
const double sideB = 4;
const double sideC = 5;
var triangle = new Triangle(sideA, sideB, sideC);

// figures list initialization
var figures = new List<Figure>
{
    circle,
    triangle
};

Console.WriteLine($"My circle square: {circle.Square}");
Console.WriteLine("----------------------------------");
Console.WriteLine($"My triangle square: {triangle.Square}");
Console.WriteLine($"Is my triangle right: {triangle.IsRight}");
Console.WriteLine("----------------------------------");
figures.ForEach(x => Console.WriteLine($"Figure in list square: {x.Square}"));