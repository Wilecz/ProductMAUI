using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace OadFigury
{
    public class Triangle : Figure
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public Triangle(double a, double b, double c) : base("Triangle") { A = a; B = b; C = c; }
        public override double Area() => Math.Sqrt(Perimeter() / 2 * (Perimeter() / 2 - A) * (Perimeter() / 2 - B) * (Perimeter() / 2 - C));
        public override double Perimeter() => A + B + C;
    }
}
