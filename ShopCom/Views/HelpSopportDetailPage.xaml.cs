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
        (BindingContext as HelpSupportDetailData).ClientId = id;
    }
}

public class HelpSupportDetailData : BindingUtilObject
{

    public HelpSupportDetailData()
    {
        var db = new ShopDbContext();
        Products = new ObservableCollection<Product>(db.Products);
        AddCommand = new Command( () =>
        {
            var purchase = new Purchase(ClientId, SelectedProduct.Id, Count);
            Purchases.Add(purchase);
        },
        () => true
        );
    }

    public ICommand AddCommand{
        get; set;
    }

    private ObservableCollection<Purchase> _purchases = new ObservableCollection<Purchase>();

    public ObservableCollection<Purchase> Purchases
    {
        get { return _purchases; }
        set {
            if (_purchases != value)
            {
                _purchases = value;
                RaisePropertyChanged();
            }
        }
    }


    private int _clientId;

    public int ClientId
    {
        get { return _clientId; }
        set { _clientId = value; }
    }

    private ObservableCollection<Product> _products;

    public ObservableCollection<Product> Products
    {
        get => _products;
        set
        {
            if (_products != value)
            {
                _products = value;
                RaisePropertyChanged();
            }
        }
    }

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
                RaisePropertyChanged();
            }
        }
    }

    private decimal _totalPrice;

    public decimal TotalPrice
    {
        get => _totalPrice;
        set {
            if (_totalPrice != value) 
            {
                _totalPrice = value;
                RaisePropertyChanged();
            }
        }
    }

    private decimal _priceSelected;

    public decimal PriceSelected
    {
        get => _priceSelected;
        set { _priceSelected = value; }
    }

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
                RaisePropertyChanged();

            }
        }
    }
}