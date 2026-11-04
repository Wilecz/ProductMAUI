using System;
using System.Collections.Generic;
using System.Text;

namespace OadFigury
{
    public class Circle : Figure
    {
        public double R { get; }
        public Circle(double r) : base("Circle") { R = r; }
        public override double Area() => Math.PI * R * R;
        public override double Perimeter() => 2 * Math.PI * R;
    }
}
