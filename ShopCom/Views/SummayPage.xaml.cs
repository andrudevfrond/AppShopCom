namespace ShopCom.Views;

public partial class SummaryPage : ContentPage
{
	public SummaryPage(SummaryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}