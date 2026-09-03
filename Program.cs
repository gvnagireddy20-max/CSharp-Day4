
// Day 4 - Inheritance and Abstraction
using System;
using System.Collections.Generic;

abstract class Shape
{
    public abstract double Area();

    public virtual void Describe()
    {
        Console.WriteLine("This is a shape.");
    }
}

interface IPrintable
{
    void Print();
}

class Circle : Shape, IPrintable
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public override void Describe()
    {
        Console.WriteLine("This is a circle.");
    }

    public void Print()
    {
        Console.WriteLine($"Circle - Radius: {Radius}");
    }
}

class Rectangle : Shape, IPrintable
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public override double Area()
    {
        return Length * Width;
    }

    public override void Describe()
    {
        Console.WriteLine("This is a rectangle.");
    }

    public void Print()
    {
        Console.WriteLine($"Rectangle - Length: {Length}, Width: {Width}");
    }
}

class Triangle : Shape, IPrintable
{
    public double Base { get; set; }
    public double Height { get; set; }

    public Triangle(double baseLength, double height)
    {
        Base = baseLength;
        Height = height;
    }

    public override double Area()
    {
        return 0.5 * Base * Height;
    }

    public override void Describe()
    {
        Console.WriteLine("This is a triangle.");
    }

    public void Print()
    {
        Console.WriteLine($"Triangle - Base: {Base}, Height: {Height}");
    }
}

class Program
{
    // This method accepts Shape objects,
    // but does not care what specific shape they are.
    static void CalculateAreas(List<Shape> shapes)
    {
        foreach (Shape shape in shapes)
        {
            Console.WriteLine(
                $"{shape.GetType().Name} Area = {shape.Area():F2}"
            );
        }
    }

    static void Main()
    {
        Circle circle = new Circle(5);
        Rectangle rectangle = new Rectangle(10, 4);
        Triangle triangle = new Triangle(6, 8);

        // Each class implements IPrintable
        circle.Print();
        rectangle.Print();
        triangle.Print();

        Console.WriteLine();

        // Polymorphic List
        List<Shape> shapes = new List<Shape>
        {
            circle,
            rectangle,
            triangle
        };

        // Runtime polymorphism / late binding
        CalculateAreas(shapes);

        Console.WriteLine();

        // Virtual method overriding
        foreach (Shape shape in shapes)
        {
            shape.Describe();
        }
    }
}