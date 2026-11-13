using ClassLibrary;
namespace Product;

public partial class DetailsPage : ContentPage, IQueryAttributable
{
    private Products? product;
    private List<Products>? productsList;
    private List<ProductInterface>? allProducts;

    public DetailsPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Product", out var productValue) && productValue is Products selectedProduct)
        {
            product = selectedProduct;
            BindingContext = product;
            descriptionLabel.Text = product.Description();
            ProductNameEntry.Text = product.Name;
            ProductPriceEntry.Text = product.Cost.ToString("0.##");
            ProductQuantityEntry.Text = product.Quantity.ToString();
            ProductCategoryPicker.SelectedItem = product.Category.ToString();
        }

        if (query.TryGetValue("ProductsList", out var productsListValue) && productsListValue is List<Products> selectedProductsList)
        {
            productsList = selectedProductsList;
        }

        if (query.TryGetValue("AllProducts", out var allProductsValue) && allProductsValue is List<ProductInterface> selectedAllProducts)
        {
            allProducts = selectedAllProducts;
        }
    }

    private async void ButtonChanger(object? sender, EventArgs e)
    {
        if (product is null)
        {
            await DisplayAlertAsync("Error", "The product could not be loaded.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(ProductNameEntry.Text) ||
            !double.TryParse(ProductPriceEntry.Text, out var cost) ||
            cost < 0 ||
            ProductCategoryPicker.SelectedItem is not string categoryText ||
            !char.TryParse(categoryText, out var category) ||
            !uint.TryParse(ProductQuantityEntry.Text, out var quantity))
        {
            await DisplayAlertAsync("Error", "Enter a name, a valid non-negative price, a category and a whole-number quantity.", "OK");
            return;
        }

        product.Name = ProductNameEntry.Text.Trim();
        product.Cost = cost;
        product.Category = category;
        product.Quantity = quantity;
        descriptionLabel.Text = product.Description();

        await DisplayAlertAsync("Success", "Product details updated successfully.", "OK");
    }

    private async void ButtonRemover(object? sender, EventArgs e)
    {
        if (product is null || productsList is null || allProducts is null)
        {
            await DisplayAlertAsync("Error", "The product could not be removed.", "OK");
            return;
        }

        var confirmed = await DisplayAlertAsync("Remove product", "Remove this product?", "Remove", "Cancel");
        if (!confirmed)
        {
            return;
        }

        productsList.Remove(product);
        allProducts.Remove(product);
        await DisplayAlertAsync("Success", "Product removed successfully.", "OK");
        await Shell.Current.GoToAsync("..");
    }

    private async void BackButtonClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}