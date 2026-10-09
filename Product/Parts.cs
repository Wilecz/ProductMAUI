using System;
using System.Collections.Generic;
using System.Text;

namespace Product
{
    public class Parts : Products
    {
        public string Producer { get; set; }

        public override string ToString()
        {
            return $"Product Name: {Name}, Cost: {Cost}, Category: {Category}, Quantity: {Quantity}, Producer: {Producer}";
        }
    }
}
