using CommunityToolkit.Mvvm.ComponentModel;

namespace ShopCom.ViewModels;

public partial class SummaryViewModel : ViewModelGlobal
{
    [ObservableProperty]
    int visits;
    [ObservableProperty]
    int clients;
    [ObservableProperty]
    decimal totals;
    [ObservableProperty]
    int totalProducts;

    public SummaryViewModel(ShopOutDbContext outDbContext)
    {
        var db = new ShopDbContext();

        Visits = outDbContext.Purchases.ToList().DistinctBy(s => s.ClientId).ToList().Count();
        Clients = db.Clients.Count();
        Totals = outDbContext.Purchases.ToList().Sum(s => s.Cantidad * s.Precio);
        TotalProducts = outDbContext.Purchases.Sum(s => s.Cantidad);
    }
}
