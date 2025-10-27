using System;

class Rectangle
{
    public virtual double Height { get; set; }
    public virtual double Width { get; set; }
    public double Area()
    {
        return Height * Width;
    }
}
class Square : Rectangle
{
    public override double Width
    {
        set { base.Width = base.Height = value; }
    }
    public override double Height 
    {
        set { base.Width = base.Height = value; }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Square();
        rectangle.Width = 4;
        rectangle.Height = 5;
        Console.WriteLine($"Area: {rectangle.Area()}");
    }
}