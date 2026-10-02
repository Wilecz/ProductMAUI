namespace Product
{
    public partial class MainPage : ContentPage
    {
        List<Products> products = new List<Products>
        {
            new Products {Name = "Jajko", Cost = 34.23, Category = 'B', Quantity = 2},
            new Products {Name = "Kalosz", Cost = 1.21, Category = 'G', Quantity = 6},
            new Products {Name = "Dźajko", Cost = 6767.99, Category = 'D', Quantity = 7},
            new Products {Name = "Dzalosz", Cost = 4.67, Category = 'A', Quantity = 2}
        };

        public MainPage()
        {
            InitializeComponent();
            ProductDisplay();
        }
        private void Buttoner(object sender, EventArgs e)
        {
            var rnd = new Random();
            SearchText.TextColor = Color.FromRgb(rnd.Next(0,256), rnd.Next(0, 256), rnd.Next(0, 256));
            SearchText.FontSize = rnd.Next(10, 100);
            ProductDisplay();
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
