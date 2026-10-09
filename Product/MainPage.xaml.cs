using System.Collections.ObjectModel;

namespace Product
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Products> ProductsCollection { get; set; }
        List<Products> products = new List<Products>
        {
            new Products {Name = "Jajko", Cost = 34.23, Category = 'B', Quantity = 2},
            new Products {Name = "Kalosz", Cost = 1.21, Category = 'C', Quantity = 6},
            new Products {Name = "Dźajko", Cost = 6767.99, Category = 'D', Quantity = 7},
            new Products {Name = "Dzalosz", Cost = 4.67, Category = 'A', Quantity = 2}
        };

        public MainPage()
        {
            InitializeComponent();
            ProductDisplay();
        }
        private async Task ButtonSearch(object sender, EventArgs e)
        {
            var rnd = new Random();
            SearchText.TextColor = Color.FromRgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            SearchText.FontSize = rnd.Next(10, 100);
            ProductDisplay();
        }
        private void ButtonAdder(object sender, EventArgs e)
        {
            if(ProductNameEntry.Text != null && ProductPriceEntry.Text != null && ProductCategoryPicker.SelectedItem != null && ProductQuantityEntry.Text != null)
            {
                string newProductName = ProductNameEntry.Text;
                double newProductCost = double.Parse(ProductPriceEntry.Text);
                char newProductCategory = char.Parse(ProductCategoryPicker.SelectedItem.ToString());
                uint newProductQuantity = uint.Parse(ProductQuantityEntry.Text);
            }
            else
            {
                DisplayAlertAsync("Error", "Please fill in all fields.", "OK");
            }
        }
        private void ProductDisplay()
        {
            Editor.Text = null;
            int i = 1;
            foreach (var product in products)
            {
                //if (product.Name.ToLower() == Entry.Text.ToLower() || Entry.Text == null)
                //{
                    Editor.Text += $"{i}. Name: {product.Name}, Cost: {product.Cost}, Category: {product.Category}, Quantity: {product.Quantity}\n";
                //}
                i++;
            }
        }
    }
}
