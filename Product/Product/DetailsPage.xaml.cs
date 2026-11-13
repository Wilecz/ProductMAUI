using ClassLibrary;
namespace Product;

public partial class DetailsPage : ContentPage, IQueryAttributable
{
	public DetailsPage()
	{
		InitializeComponent();
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["Product"] is Products product)
        {
            BindingContext = product;
            descriptionLabel.Text = product.Description();
        }
    }
    private void ButtonChanger(object sender, EventArgs e)
    {
        //if (ProductNameEntry.Text != null && ProductPriceEntry.Text != null && ProductCategoryPicker.SelectedItem != null && ProductQuantityEntry.Text != null)
        //{
        //    string newProductName = ProductNameEntry.Text;
        //    double newProductCost = double.Parse(ProductPriceEntry.Text);
        //    char newProductCategory = char.Parse(ProductCategoryPicker.SelectedItem.ToString());
        //    uint newProductQuantity = uint.Parse(ProductQuantityEntry.Text);
        //    var newProduct = new Products { Name = newProductName, Cost = newProductCost, Category = newProductCategory, Quantity = newProductQuantity };
        //    BindingContext = newProduct;
        //    newProduct.Name = newProductName;
        //    newProduct.Cost = newProductCost;
        //    newProduct.Category = newProductCategory;
        //    newProduct.Quantity = newProductQuantity;
        //    DisplayAlertAsync("Success", "Product details updated successfully.", "OK");
        //}
        //else
        //{
        //    DisplayAlertAsync("Error", "Please fill in all fields.", "OK");
        //}
        if(ProductNameEntry.Text != null)
        {
            ((Products)BindingContext).Name = ProductNameEntry.Text;
        }
        if(ProductPriceEntry.Text != null)
        {
            ((Products)BindingContext).Cost = double.Parse(ProductPriceEntry.Text);
        }
        if (ProductCategoryPicker.SelectedItem != null)
        {
            ((Products)BindingContext).Category = char.Parse(ProductCategoryPicker.SelectedItem.ToString());
        }
        if(ProductQuantityEntry.Text != null)
        {
            ((Products)BindingContext).Quantity = uint.Parse(ProductQuantityEntry.Text);
        }
        if(ProductNameEntry.Text != null || ProductPriceEntry.Text != null || ProductCategoryPicker.SelectedItem != null || ProductQuantityEntry.Text != null)
        {
            DisplayAlertAsync("Success", "Product details updated successfully.", "OK");
        }
        if (ProductNameEntry.Text == null && ProductPriceEntry.Text == null && ProductCategoryPicker.SelectedItem == null && ProductQuantityEntry.Text == null)
        {
            DisplayAlertAsync("Error", "Please fill in all fields.", "OK");
        }
    }
    private async void BackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}