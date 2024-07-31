
namespace ShopCom.Services;

public class NavegationService : INavigationService
{
    public async Task GoToAsync(string uri)
    {
        await Shell.Current.GoToAsync(uri);
    }

    public async Task GoToAsync(string uri, IDictionary<string, object> parameters)
    {
        await Shell.Current.GoToAsync(uri, parameters);
    }
}
