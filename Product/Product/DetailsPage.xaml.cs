using ClassLibrary;
namespace Product;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(Products product)
	{
		InitializeComponent();
		BindingContext = product;
        descriptionLabel.Text = product.Description();
    }
    private async void BackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}