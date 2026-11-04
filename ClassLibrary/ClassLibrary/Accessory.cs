using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Accessory : Products
    {
        public string Color { get; set; }
        public override string Description()
        {
            return $"Color: {Color}, Product Name: {Name}, Cost: {Cost}, Category: {Category}, Quantity: {Quantity}";
        }
    }
}
