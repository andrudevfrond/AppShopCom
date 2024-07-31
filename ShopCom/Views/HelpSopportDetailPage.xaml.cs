using System.Collections.ObjectModel;
using System.Windows.Input;

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
        var id = int.Parse(query["id"].ToString());
        (BindingContext as HelpSupportDetailViewModel).ClientId = id;
    }
}

