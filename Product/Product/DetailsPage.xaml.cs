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
    private async void BackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}