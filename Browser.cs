using System;
using System.Collections.Generic;
using System.Text;

namespace OadFigury
public static class Browser
{
    public static IEnumerable<Product> Search(IEnumerable<Product> produkt, string? fraze)
    {
        if (string.IsNullOrWhiteSpace(fraze))
        {
            return product;
        }
        string f = fraze.Trim();
        return product.Where(p => p.Name.Contains(f, String(Comparison.OrdinalIgnoreCase)));
    }
}
