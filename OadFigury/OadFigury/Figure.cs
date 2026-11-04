using System;
using System.Collections.Generic;
using System.Text;

namespace OadFigury
{
    public abstract class Figure
    {
        public string Name { get; }
        protected Figure(string name) { Name = name; }
        public abstract double Area();
        public abstract double Perimeter();
        public virtual string Description() => $"{Name}: Area {Area():F2}, Perimeter {Perimeter():F2}";
    }
}
