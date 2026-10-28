using System;
using System.Collections.Generic;
using System.Text;

namespace OadFigury

public class BrowseTests
{
    private static List<Product> Info() => new()
    {
        new Product { Name = "Mysz bezprzewodowa", Cost = 80 },
        new Product { Name = "Klawiatura", Cost = 150 },
        new Product { Name = "Mysz przewodowa", Cost = 40 },
    };
    [TestMethod]
    public void Search_Fraze_OutputAlike()
    {
        var output = Browser.Search(Info(), "mysz").ToList();
        Assert.AreEqual(2, output.Count);
    }
    [TestMethod]
    public void Search_EmptyFraze_OutputAll()
    {
        var output = Browser.Search(Info(), "").ToList();
        Assert.AreEqual(3, output.Count);
    }
    [TestMethod]
    public void Search_NoneFitting_OutputNull()
    {
        var output = Browser.Search(Info(), "monitor").ToList();
        Assert.AreEqual(0, output.Count);
    }
}
