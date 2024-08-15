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
    public HelpSupportDetailViewModel()
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
