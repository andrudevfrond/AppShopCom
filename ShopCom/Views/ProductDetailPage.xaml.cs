namespace ShopCom.Views;

public partial class ProductDetailPage : ContentPage
{
	public ProductDetailPage(ProductDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}