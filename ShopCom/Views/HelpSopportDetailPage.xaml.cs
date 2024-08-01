namespace ShopCom.Views;

public partial class HelpSopportDetailPage : ContentPage
{
    public HelpSopportDetailPage(HelpSupportDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}

