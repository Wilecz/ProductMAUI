using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public static class Browser
    {
        public static IEnumerable<ProductInterface> Search(IEnumerable<ProductInterface> products, string? searchTerm)
        {
            if(string.IsNullOrWhiteSpace(searchTerm))
            {
                return products;
            }
            string Term = searchTerm.Trim();
            return products.Where(p => p.Name.Contains(Term, StringComparison.OrdinalIgnoreCase));
        }
    }
}
