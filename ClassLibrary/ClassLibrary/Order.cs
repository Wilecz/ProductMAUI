using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Order : ProductInterface
    {
        private readonly List<ProductInterface> _products;
        public string Name { get; private set; }
        public double Cost => _products.Sum(p => p.Cost);
        public Order(string name, List<ProductInterface> products)
        {
            Name = name;
            _products = products;
        }
    }
}
