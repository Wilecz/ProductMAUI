using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Warehouse
    {
        public static double CalculateTotalWarehouseValue(List<Products> products)
        {
            return products.Sum(product => product.StockPrice);
        }
    }
}
