namespace ShopCom.Views;

public partial class HelpSopportPage : ContentPage
{
	public HelpSopportPage( HelpSopportViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}


