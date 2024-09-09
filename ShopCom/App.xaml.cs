namespace ShopCom;

public partial class App : Application
{
    public App( LoginPage loginPage, ShopOutDbContext outDbContext)
    {
        InitializeComponent();
        outDbContext.Database.EnsureCreated();
        var accesssToken = Preferences.Get("accesstoken", string.Empty);

        if (string.IsNullOrEmpty(accesssToken))
        {
            MainPage = loginPage;
        }
        else { 
            MainPage = new AppShell();
        }
    }
}
