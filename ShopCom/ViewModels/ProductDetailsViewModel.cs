using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace ShopCom.ViewModels;

public partial class ProductDetailsViewModel : ViewModelGlobal, IQueryAttributable
{
    [ObservableProperty]
    private string name;
    [ObservableProperty]
    private string description;
    [ObservableProperty]
    private decimal price;

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var dbContext = new ShopDbContext();
        int id = Convert.ToInt32(query["id"].ToString());
        var product = await dbContext.Products.FirstAsync(x => x.Id.Equals(id));
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
    }
}
