namespace ShopCom.Services;

public interface INavigationService
{
    Task GoToAsync(string uri);
    Task GoToAsync(string uri, IDictionary<string, object> parameters);
}
