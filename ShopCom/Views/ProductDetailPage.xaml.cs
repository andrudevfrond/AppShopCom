namespace ShopCom.Views;

public partial class ProductDetailPage : ContentPage, IQueryAttributable
{
	public ProductDetailPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var dbContext = new ShopDbContext();
        int id =  Convert.ToInt32(query["id"].ToString());
        var product = dbContext.Products.First(x => x.Id.Equals(id));
        container.Children.Add(new Label { Text = product.Name });
        container.Children.Add(new Label { Text = product.Description });
        container.Children.Add(new Label { Text = product.Price.ToString() });
    }
}