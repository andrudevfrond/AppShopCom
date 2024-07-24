using ShopCom.DataAccess;

namespace ShopCom
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var dbcontext = new ShopDbContext();
            category.Text = $"{nameof(category)}: " + dbcontext.Categories.Count().ToString();
            client.Text = $"{nameof(client)}: " + dbcontext.Clients.Count().ToString();
            product.Text = $"{nameof(product)}: " + dbcontext.Products.Count().ToString();
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            await DisplayAlert("Mensaje de Andru: Hola Andru", "Ok", "Cancelar");
        }
    }

}
