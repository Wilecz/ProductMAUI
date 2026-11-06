using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Products : ProductInterface, IComparable<Products>
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public char Category { get; set; }
        public uint Quantity { get; set; }
        public virtual double StockPrice { get { return Cost * Quantity; } }

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
            return $"Product Name: {Name}, Cost: {Cost}, Category: {Category}, Quantity: {Quantity}";
        }
        public int CompareTo(Products? other)
        {
            if (other == null) return 1;
            return this.Cost.CompareTo(other.Cost);
        }
        public static List<Products> Search(List<Products> products, string name)
        {
            List<Products> FoundProducts = new List<Products>();
            foreach (var product in products)
            {
                if (product.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    FoundProducts.Add(product);
                }
            }
            FoundProducts.Clear();
            FoundProducts = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            return FoundProducts;
        }
    }
}
