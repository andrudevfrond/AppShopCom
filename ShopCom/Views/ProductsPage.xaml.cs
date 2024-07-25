using ShopCom.DataAccess;

namespace ShopCom.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();

		var dbContext = new ShopDbContext();

		foreach (var item in dbContext.Products) {
			container.Children.Add(new Label { Text = item.Name });
		}
	}
}