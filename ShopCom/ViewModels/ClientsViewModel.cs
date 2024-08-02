using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ShopCom.ViewModels;

public partial class ClientsViewModel: ViewModelGlobal
{
    [ObservableProperty]
    private ObservableCollection<Client> clients;
    [ObservableProperty]
    private Client selectedClient;

    public ClientsViewModel()
    {
        var db = new ShopDbContext();
        Clients = new ObservableCollection<Client>(db.Clients);
    }
}
