using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class Products : ProductInterface, IComparable<Products>, INotifyPropertyChanged
    {
        private string name { get; set; }
        public string Name 
        {
            get { return name; }
            set
            {
                if(name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        private double cost { get; set; }
        public double Cost 
        {
            get { return cost; }
            set
            {
                if(cost != value)
                {
                    cost = value;
                    OnPropertyChanged(nameof(Cost));
                }
            }
        }
        private char category { get; set; }
        public char Category {
            get { return category; }
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }
        private uint quantity { get; set; }
        public uint Quantity {
            get { return quantity; }
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }
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
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
