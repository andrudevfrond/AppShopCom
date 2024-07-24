using Microsoft.Maui.Controls.Shapes;
using ShopCom.DataAccess;

namespace ShopCom.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var dbContext = new ShopDbContext();
            category.Text = dbContext.Categories.Count().ToString();
            product.Text = dbContext.Products.Count().ToString();
            client.Text = dbContext.Clients.Count().ToString();
        }
    }

}
