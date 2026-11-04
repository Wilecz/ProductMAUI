using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Purchase
    {
        private readonly List<PurchasePosition> positions = new List<PurchasePosition>();
        public IReadOnlyList<PurchasePosition> Position => positions;
        public void AddPosition(ProductInterface product, int quantity)
        {
            if(quantity <= 0)
                throw new ArgumentException("Quantity cannot be negative", nameof(quantity));
            var existingPosition = positions.FirstOrDefault(p => p.Product == product);
            if (existingPosition != null)
                existingPosition.AddTotalPrice(quantity);
            else
                positions.Add(new PurchasePosition(product, quantity));
        }
        public double TotalPurchasePrice => positions.Sum(p => p.TotalPrice);
    }
}
