using System;
using System.Collections.Generic;
using System.Text;

namespace OadFigury
{
    public class Drawing
    {
        private readonly List<Figure> figure = new();
        public void Adder(Figure f) => figure.Add(f);
        public double SumArea()
        {
            return figure.Sum(f => f.Area());
        }
        public Figure? Highest()
        {
            return figure.Aggregate((f1, f2) => f1.Area() > f2.Area() ? f1 : f2);
        }

    }
}
