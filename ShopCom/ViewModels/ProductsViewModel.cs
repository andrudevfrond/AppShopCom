using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShopCom.ViewModels;

public partial class ProductsViewModel: ViewModelGlobal
{
    private readonly INavigationService navigationService;

    [ObservableProperty]
    private ObservableCollection<Product> products;
    [ObservableProperty]
    private Product selectedProduct;
    [ObservableProperty]
    private bool isRefreshing;

    public ProductsViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
        GetProducts();
        PropertyChanged += ProductsViewModel_PropertyChanged;

    }

    [RelayCommand]
    private async Task Refresh() {
        GetProducts();
        await Task.Delay(3000);
        IsRefreshing = false;
    }

    // este evento solo sucede con la propiedades que sean twoWay
    // es decir que envia informacion desde la vista hacia el viewModel
    private async void ProductsViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedProduct)) {
            var uri = $"{nameof(ProductDetailPage)}?id={SelectedProduct.Id}";
            await navigationService.GoToAsync(uri);
        }
    }

    private void GetProducts()
    {
        var db = new ShopDbContext();
        Products = new ObservableCollection<Product>(db.Products);
        db.Dispose();
    }
}

