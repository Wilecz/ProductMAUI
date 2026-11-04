using ClassLibrary;

var products = new List<Products>
{
    new Products { Name = "Product 1", Cost = 10.99, Category = 'A', Quantity = 5 },
    new Products { Name = "Product 2", Cost = 15.49, Category = 'B', Quantity = 3 },
    new Products { Name = "Product 3", Cost = 12.99, Category = 'A', Quantity = 10 },
    new Products { Name = "Product 4", Cost = 12.99, Category = 'C', Quantity = 2 },
    new Products { Name = "Product 5", Cost = 9.99, Category = 'B', Quantity = 8 }
 };
double WholeStock = 0;
var productsInCategories = new Dictionary<char, List<Products>>();
products = products.OrderBy(p => p.Cost - p.Cost * 2).ToList();
foreach (var product in products)
{
    if (!productsInCategories.ContainsKey(product.Category))
    {
        productsInCategories[product.Category] = new List<Products>();
    }
    productsInCategories[product.Category].Add(product);
}

Console.WriteLine("Products in categories:");
foreach (var productCategory in productsInCategories)
{
    Console.WriteLine($"Category: {productCategory.Key}");
    foreach (var product in productCategory.Value)
    {
        Console.WriteLine($"  Name: {product.Name}, Cost: {product.Cost}, Quantity: {product.Quantity}, WholeCost: {Math.Round(product.Cost * product.Quantity, 2)}");
    }
}

foreach(var product in products)
{
    WholeStock += product.Cost * product.Quantity;
}
WholeStock = Math.Round(WholeStock, 2);
Console.WriteLine($"WholeStock: {WholeStock}");

Console.WriteLine("Enter the maximum price: ");
double maxPrice = double.Parse(Console.ReadLine());
Console.WriteLine("Enter the minimum price: ");
double minPrice = double.Parse(Console.ReadLine());

foreach (var productCategory in productsInCategories)
{
    
}