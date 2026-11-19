using System.Text;
using ClassLibrary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductWPF
{
    public partial class MainWindow : Window
    {
        public double WarehouseValue { get; }
        public MainWindow()
        {
            InitializeComponent();
            var products = new List<Products>
            {
                new Parts {Name = "Part", Cost = 10.99, Category = 'A', Quantity = 100, Producer = "Producer A"},
                new Service {Name = "Service", Cost = 49.99, Category = 'B', Quantity = 50},
                new Accessory {Name = "Accessory", Cost = 5.99, Category = 'C', Quantity = 200, Color = "#FF0000"}
            };

            WarehouseValue = Warehouse.CalculateTotalWarehouseValue(products);
            ProductListBox.ItemsSource = products;
            NumberProductsTextBlock.Text = $"Number of Products: {products.Count}";
            ValueInventoryTextBlock.Text = $"Value of Inventory: {products.Sum(p => p.Cost * p.Quantity):F2}zł";
            WarehouseValueTextBlock.Text = $"Warehouse Value: {WarehouseValue:F2}zł";
        }
    }
}