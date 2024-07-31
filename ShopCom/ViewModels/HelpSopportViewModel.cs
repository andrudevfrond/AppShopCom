using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShopCom.ViewModels;

public class HelpSopportViewModel : BindingUtilObject
{
    private readonly INavigationService _navigationService;
    public HelpSopportViewModel(INavigationService navigationService)
    {
        var db = new ShopDbContext();
        Clients = new ObservableCollection<Client>(db.Clients);
        PropertyChanged += HelpSopportData_PropertyChanged;
        _navigationService = navigationService;
    }

    private async void HelpSopportData_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedClient))
        {
            var uri = $"{nameof(HelpSopportDetailPage)}?id={SelectedClient.Id}";
            await _navigationService.GoToAsync(uri);
        }
    }

    private int _visitsPenddings;
    public int VisitsPenddings
    {
        get => _visitsPenddings;
        set
        {
            if (_visitsPenddings != value)
            {
                _visitsPenddings = value;
                RaisePropertyChanged();
            }
        }
    }
    private ObservableCollection<Client> _clients;
    public ObservableCollection<Client> Clients
    {
        get => _clients;
        set
        {
            if (_clients != value)
            {
                _clients = value;
                RaisePropertyChanged();
            }
        }
    }

    private Client _selectedClient;

    public Client SelectedClient
    {
        get => _selectedClient;
        set
        {
            if (_selectedClient != value)
            {
                _selectedClient = value;
                RaisePropertyChanged();
            }
        }
    }
}
