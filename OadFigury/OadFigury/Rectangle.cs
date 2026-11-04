using System;
using System.Collections.Generic;
using System.Text;

namespace OadFigury
{
    public class Rectangle : Figure
    {
        public double A { get; }
        public double B { get; }
        public Rectangle(double a, double b) : base("Rectangle") { A = a; B = b; }
        public override double Area() => A * B;
        public override double Perimeter() => 2 * (A + B);
    }
}
