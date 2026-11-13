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
        public MainWindow()
        {
            InitializeComponent();
            var products = new List<Products>
            {
                new Parts {Name = "Part A", Cost = 10.99, Category = 'A', Quantity = 100},
                new Service {Name = "Service B", Cost = 49.99, Category = 'B', Quantity = 50},
                new Accessory {Name = "Accessory C", Cost = 5.99, Category = 'C', Quantity = 200}
            };
            ProductListBox.ItemsSource = products;
        }
    }
}