using ShopCom.DataAccess;

namespace ShopCom.Views;

public partial class ClientsPage : ContentPage
{
	public ClientsPage()
	{
		InitializeComponent();
		var dbContext = new ShopDbContext();

		foreach (var item in dbContext.Clients) {
			container.Children.Add(new Label { Text = item.Name });
		}
	}
}