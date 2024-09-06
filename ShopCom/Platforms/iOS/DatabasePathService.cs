namespace ShopCom.Services;

public class DatabasePathService : IDatabasePathService
{
    public string Get(string filename)
    {
        // buscar la ruta en el dispositivo android
        var pathDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return Path.Combine(pathDirectory, filename);
    }
}
