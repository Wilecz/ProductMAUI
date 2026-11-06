using ClassLibrary;
using System.Collections.ObjectModel;


namespace Product
{
    public partial class MainPage : ContentPage
    {
        public readonly List<Products> productsList = new();
        private readonly List<ProductInterface> all = new();
        public ObservableCollection<ProductInterface> SeenProducts { get; } = new();
        public ObservableCollection<ProductInterface> ProductsCollection { get; set; }
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
            all.AddRange(products);
            BindingContext = this;
            Refresh();
        }
        private async void ButtonSearch(object sender, EventArgs e)
        {
            var rnd = new Random();
            int searchTextSize = 0;
            SearchText.TextColor = Color.FromRgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            while (searchTextSize <= 40)
            {
                searchTextSize++;
                SearchText.FontSize = searchTextSize;
                await Task.Delay(searchTextSize + 15);
            }
            searchTextSize = 0;
            Refresh();
        }
        private void ButtonAdder(object sender, EventArgs e)
        {
            if (ProductNameEntry.Text != null && ProductPriceEntry.Text != null && ProductCategoryPicker.SelectedItem != null && ProductQuantityEntry.Text != null)
            {
                string newProductName = ProductNameEntry.Text;
                double newProductCost = double.Parse(ProductPriceEntry.Text);
                char newProductCategory = char.Parse(ProductCategoryPicker.SelectedItem.ToString());
                uint newProductQuantity = uint.Parse(ProductQuantityEntry.Text);
                var newProduct = new Products { Name = newProductName, Cost = newProductCost, Category = newProductCategory, Quantity = newProductQuantity };
                products.Add(newProduct);
                all.Add(newProduct);
                Refresh();
            }
            else
            {
                DisplayAlertAsync("Error", "Please fill in all fields.", "OK");
            }
        }
        private void ProductSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            SeenProducts.Clear();
            foreach (var p in ClassLibrary.Browser.Search(all, ProductSearchEntry.Text))
                SeenProducts.Add(p);
        }
        private async void DetailButtonClicked(object sender, EventArgs e)
        {
            if (ProductCollectionView?.SelectedItem is Products selected)
            {
                await Shell.Current.GoToAsync(nameof(DetailsPage), new Dictionary<string, object>
                {
                    ["Product"] = selected
                });
            }
        }
    }
}
