using System.Linq;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        Random random = new Random();
        List<Products> ReadyTestProducts()
        {
            return new List<Products>
            {
                new Products { Name = "Product 1", Cost = random.NextDouble() * 100, Category = 'A', Quantity = 5 },
                new Products { Name = "Product 2", Cost = random.NextDouble() * 100, Category = 'B', Quantity = 3 },
                new Products { Name = "Product 3", Cost = random.NextDouble() * 100, Category = 'A', Quantity = 10 },
                new Products { Name = "Product 4", Cost = random.NextDouble() * 100, Category = 'C', Quantity = 2 },
                new Products { Name = "Product 5", Cost = random.NextDouble() * 100, Category = 'B', Quantity = 8 }
            };
        }
        Products PrepareProduct()
        {
            Random r = new Random();
            Products product = new Products
            {
                Name = "Test Product",
                Cost = r.NextDouble() * 100,
                Category = 'A',
                Quantity = (uint)r.Next(1, 20)
            };
            return product;
        }
        [TestMethod]
        public void TestStockValue()
        {
            var product = PrepareProduct();
            double Value = product.Cost * product.Quantity;
            Assert.AreEqual(50, 0, Value, "");
        }
        [TestMethod]
        public void TestNegativeCostValue()
        {
            var product = PrepareProduct();
            product.Cost = -10.0;
            bool isValid = product.Cost >= 0;
            Assert.IsFalse(isValid, "Cost should not be negative.");
        }
        [TestMethod]
        public void CountAllProducts()
        {
            var products = ReadyTestProducts();
            int expectedCount = 5;
            Assert.AreEqual(expectedCount, products.Count, $"Expected {expectedCount} products, but found {products.Count}.");
        }
        [TestMethod]
        public void CheckCost()
        {
            var products = ReadyTestProducts();
            int counter = 0;
            foreach (var product in products)
            {
                if (product.Cost > 0)
                {
                    counter++;
                }
            }
            Assert.AreEqual(products.Count, counter, $"Expected all products to have non-negative cost, but found {counter} products with negative cost.");
        }
        [TestMethod]
        public void IfDescriptionHaveProduct()
        {
            var Part = new Parts
            {
                Name = "Part 1",
                Cost = 20.5,
                Category = 'A',
                Quantity = 10,
                Producer = "Producer 1"
            };
        }
        [TestMethod]
        public void IfDescriptionHaveProducer()
        {
            string producerName = "Producer 1";
            var part = new Parts
            {
                Name = "Part 1",
                Cost = 20.5,
                Category = 'A',
                Quantity = 10,
                Producer = producerName
            };
            var description = part.Description();
            StringAssert.Contains(description, producerName, $"Description should contain the producer name '{producerName}', but it does not.");
        }
        [TestMethod]
        public void IfAccessoryDescriptionHaveColor()
        {
            string color = "Red";
            var accessory = new Accessory
            {
                Name = "Accessory 1",
                Cost = 15.0,
                Category = 'B',
                Quantity = 5,
                Color = color
            };
            var description = accessory.Description();
            StringAssert.Contains(description, color, $"Description should contain the color '{color}', but it does not.");
        }
        [TestMethod]
        public void AddNegativeQuantity()
        {
            var purchase = new Purchase();
            var product = PrepareProduct();
            var exception = Assert.ThrowsExactly<ArgumentException>(() => purchase.AddPosition(product, -5));
            StringAssert.Contains(exception.Message, "Quantity cannot be negative", $"Expected exception message to contain 'Quantity cannot be negative', but got '{exception.Message}'.");
        }
        [TestMethod]
        public void SearchProductByName()
        {
            var products = ReadyTestProducts();
            var searchName = "Product 1";
            int expectedCountOfFoundProducts = 1;
            var foundProducts = Products.Search(products, searchName);
            Assert.AreEqual(expectedCountOfFoundProducts, foundProducts.Count, $"Expected {expectedCountOfFoundProducts} products with name '{searchName}', but found {foundProducts.Count}.");
        }
        [TestMethod]
        public void SearchProductByName_QuantityOfSearchedProducts()
        {
            var products = ReadyTestProducts();
            var searchName = "Product 1";
            uint expectedQuantity = 5;
            var foundProducts = Products.Search(products, searchName);
            Assert.AreEqual(expectedQuantity, foundProducts[0].Quantity, $"Expected quantity {expectedQuantity} for product '{searchName}', but found {foundProducts[0].Quantity}.");
        }
        [TestMethod]
        public void SearchProductByName_CostOfSearchedProducts()
        {
            var products = ReadyTestProducts();
            var searchName = "Product 1";
            double expectedCost = products[0].Cost;
            var foundProducts = Products.Search(products, searchName);
            Assert.AreEqual(expectedCost, foundProducts[0].Cost, $"Expected cost {expectedCost} for product '{searchName}', but found {foundProducts[0].Cost}.");
        }
    }
}
