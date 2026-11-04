using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class PurchasePosition
    {
        public ProductInterface Product { get; set; }
        public int Quantity { get; private set; }
        public PurchasePosition(ProductInterface product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public double TotalPrice => Product.Cost * Quantity;
        public void AddTotalPrice(int quantity) => Quantity += quantity;
    }
}
