using ShopCom.DataAccess;

namespace ShopCom
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var dbcontext = new ShopDbContext();
            Category.Text= $"{nameof(Category)}: " + dbcontext.Categories.Count().ToString();
            Clients.Text = $"{nameof(Clients)}: " + dbcontext.Clients.Count().ToString();
            Products.Text = $"{nameof(Products)}: " + dbcontext.Products.Count().ToString();
        }
    }

}
