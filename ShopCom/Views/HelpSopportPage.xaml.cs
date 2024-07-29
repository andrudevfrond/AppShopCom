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

    // public int VisitsPeddings {  get; set; }
    public int _visitsPenddings;
    public int VisitsPenddings {
        get { return _visitsPenddings; }
        set {
            if (_visitsPenddings != value) { 
                _visitsPenddings = value;
                RaisePropertyChanged();
            }
        } 
    }
}