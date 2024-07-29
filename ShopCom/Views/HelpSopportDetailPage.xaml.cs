
namespace ShopCom.Views;

public partial class HelpSopportDetailPage : ContentPage, IQueryAttributable
{
	public HelpSopportDetailPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Title = $"Cliente: {query["id"]}";
    }
}