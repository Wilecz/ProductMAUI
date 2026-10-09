using System;
using System.Collections.Generic;
using System.Text;

namespace Product
{
    public class Products
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public char Category { get; set; }
        public uint Quantity { get; set; }

        public static void DisplayProductInfo(Products product)
        {
            Console.WriteLine($"Product Name: {product.Name}");
            Console.WriteLine($"Cost: {product.Cost}");
            Console.WriteLine($"Category: {product.Category}");
            Console.WriteLine($"Quantity: {product.Quantity}");
        }
        public override string ToString()
        {
            return $"Product Name: {Name}, Cost: {Cost}, Category: {Category}, Quantity: {Quantity}";
        }
        public virtual string Description()
        {
            return "Description";
        }
    }

}
