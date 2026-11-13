using ClassLibrary;
using System.Collections.ObjectModel;


namespace Product
{
    public partial class MainPage : ContentPage
    {
        private readonly List<ProductInterface> all = new();
        public ObservableCollection<ProductInterface> SeenProducts { get; } = new();
        private readonly List<Products> products = new()
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
        private async void ButtonSearch(object? sender, EventArgs e)
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
            //Refresh();
        }
        private async void ButtonAdder(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductNameEntry.Text) ||
                !double.TryParse(ProductPriceEntry.Text, out var newProductCost) ||
                newProductCost < 0 ||
                ProductCategoryPicker.SelectedItem is not string categoryText ||
                !char.TryParse(categoryText, out var newProductCategory) ||
                !uint.TryParse(ProductQuantityEntry.Text, out var newProductQuantity))
            {
                await DisplayAlertAsync("Error", "Enter a name, a valid non-negative price, a category and a whole-number quantity.", "OK");
                return;
            }

            var newProduct = new Products
            {
                Name = ProductNameEntry.Text.Trim(),
                Cost = newProductCost,
                Category = newProductCategory,
                Quantity = newProductQuantity
            };
            products.Add(newProduct);
            all.Add(newProduct);
            ClearAddProductForm();
            //Refresh();
        }
        private void ProductSearchTextChanged(object? sender, TextChangedEventArgs e)
        {
            //Refresh();
        }
        private void Refresh()
        {
            SeenProducts.Clear();
            foreach (var p in ClassLibrary.Browser.Search(all, ProductSearchEntry.Text))
                SeenProducts.Add(p);
        }
        private async void DetailButtonClicked(object? sender, EventArgs e)
        {
            if (ProductCollectionView?.SelectedItem is Products selected)
            {
                await Shell.Current.GoToAsync(nameof(DetailsPage), new Dictionary<string, object>
                {
                    ["Product"] = selected,
                    ["ProductsList"] = products,
                    ["AllProducts"] = all
                });
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Refresh();
        }
        private void ButtonShowAddProductStack(object? sender, EventArgs e)
        {
            AddProductStack.IsVisible = !AddProductStack.IsVisible;
        }

        private void ClearAddProductForm()
        {
            ProductNameEntry.Text = string.Empty;
            ProductPriceEntry.Text = string.Empty;
            ProductQuantityEntry.Text = string.Empty;
            ProductCategoryPicker.SelectedItem = null;
        }
    }
}
