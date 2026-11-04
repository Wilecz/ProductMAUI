using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Parts : Products
    {
        public string Producer { get; set; }

        public override string ToString()
        {
            return $"Product Name: {Name}, Cost: {Cost}, Category: {Category}, Quantity: {Quantity}, Producer: {Producer}";
        }
        public override string Description()
        {
            return $"Producer: {Producer}, Product Name: {Name}, Cost: {Cost}, Category: {Category}, Quantity: {Quantity}";
        }
    }
}
