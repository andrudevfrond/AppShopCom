using ShopCom.DataAccess;

namespace ShopCom.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();

		var dbContext = new ShopDbContext();
		products.ItemsSource = dbContext.Products;


		//foreach (var item in dbContext.Products) {
		//	var button = new Button { Text = item.Name};
		//	button.Clicked += async (s, e) =>
		//	{
		//		var uri = $"{nameof(ProductDetailPage)}?id={item.Id}";
		//		await Shell.Current.GoToAsync(uri);
		//	};

		//	container.Children.Add(button);
		//}
	}
}