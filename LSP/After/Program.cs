using System;
abstract class Shape
{
    public abstract double Area();
}
class Rectangle : Shape
{
    public double Height { get; set; }
    public double Width { get; set; }
    public override double Area()
    {
        return Height * Width;
    }
}
class Square : Shape
{
    public double SideLength { get; set; }
    public override double Area()
    {
        return SideLength * SideLength;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Shape rectangle = new Rectangle
        {
            Height = 5,
            Width = 4
        };
        Shape square = new Square
        {
            SideLength = 5
        };
        Console.WriteLine($"Area of the rectangle: {rectangle.Area()}");
        Console.WriteLine($"Area of the square: {square.Area()}");
    }
}