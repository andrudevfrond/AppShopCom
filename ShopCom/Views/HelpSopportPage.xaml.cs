using ShopCom.DataAccess;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShopCom.Views;

public partial class HelpSopportPage : ContentPage
{
	public HelpSopportPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		var dataObject = Resources["data"] as HelpSopportData;
		dataObject.VisitsPenddings = 30;
    }
}


public class HelpSopportData: BindingUtilObject
{
    public HelpSopportData()
    {
        var db = new ShopDbContext();
        Clients = new ObservableCollection<Client>(db.Clients);
    }

    private int _visitsPenddings;
    public int VisitsPenddings {
        get { return _visitsPenddings; }
        set {
            if (_visitsPenddings != value) { 
                _visitsPenddings = value;
                RaisePropertyChanged();
            }
        } 
    }
    private ObservableCollection<Client> _clients;
    public ObservableCollection<Client> Clients {
        get { return _clients; }
        set { 
            if (_clients != value){
                _clients = value;
                RaisePropertyChanged();
            }
        }
    }

}