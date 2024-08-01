using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShopCom.ViewModels;

public partial class HelpSopportViewModel : ViewModelGlobal
{
    [ObservableProperty]
    private int visitsPenddings;

    [ObservableProperty]
    private ObservableCollection<Client> clients;

    [ObservableProperty]
    private Client selectedClient;

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
}
