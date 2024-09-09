using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopCom.ViewModels;

public partial class HelpSupportDetailViewModel : ViewModelGlobal, IQueryAttributable
{
    public ICommand AddCommand
    {
        get; set;
    }
    private readonly IConnectivity _connectivity;

    [ObservableProperty]
    private ObservableCollection<Purchase> purchases = new ObservableCollection<Purchase>();

    [ObservableProperty]
    private int clientId;

    [ObservableProperty]
    private ObservableCollection<Product> products;

    private Product _selectedProduct;

    public Product SelectedProduct
    {
        get => _selectedProduct;
        set
        {
            if (_selectedProduct != value)
            {
                _selectedProduct = value;
                PriceSelected = value.Price;
                Count = 1;
                OnPropertyChanged();
            }
        }
    }

    [ObservableProperty]
    private decimal totalPrice;

    [ObservableProperty]
    private decimal priceSelected;

    private int _count;

    public int Count
    {
        get => _count;
        set
        {
            if (value != _count)
            {
                _count = value;
                TotalPrice = PriceSelected * value;
                OnPropertyChanged();

            }
        }
    }
    private readonly ServicePurchase _servicePurchase;
    private readonly ShopOutDbContext _outDbContext;

    public HelpSupportDetailViewModel(
        IConnectivity connectivity, 
        ServicePurchase servicePurchase,
        ShopOutDbContext outDbContext)
    {
        var db = new ShopDbContext();
        Products = new ObservableCollection<Product>(db.Products);
        AddCommand = new Command(() =>
        {
            var purchase = new Purchase(
                ClientId, 
                SelectedProduct.Id, 
                Count,
                SelectedProduct.Name,
                SelectedProduct.Price,
                SelectedProduct.Price * Count);
            Purchases.Add(purchase);
        },
        () => true
        );
        _connectivity = connectivity;
        connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        _servicePurchase = servicePurchase;
        _outDbContext = outDbContext;
    }
    [RelayCommand(CanExecute = nameof(StatusConnection))]
    private async Task SendPurchase()
    {
        // SendPurchaseCommand
        // enviar datos al servidor

        //var result = await _servicePurchase.SendData(purchases);
        //if (result)
        //{
        //    await Shell.Current.DisplayAlert("Mensaje", "Se enviaron la compras al servidor backend", "Aceptar");
        //}

        // guardar datos en la base de dato sqlite
        _outDbContext.Database.EnsureCreated();

        foreach (var item in purchases) {
            _outDbContext.Purchases.Add(new PurchaseItem( 
                item.ClientId,
                item.ProductId,
                item.Cantidad,
                item.ProductoPrecio
            ));
        }

        await _outDbContext.SaveChangesAsync();

        await Shell.Current.DisplayAlert("Mensaje", "Se registra en la base de datos sqlite", "Aceptar");

    }

    private void Connectivity_ConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
    {
        SendPurchaseCommand.NotifyCanExecuteChanged();
    }

    private bool StatusConnection() {
        return _connectivity.NetworkAccess == NetworkAccess.Internet ? true : false;
    }
    

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var id = int.Parse(query["id"].ToString());
        ClientId = id;
    }

    [RelayCommand]
    private void DeletePurchase(Purchase purchase) {
        Purchases.Remove(purchase);
    }
}
