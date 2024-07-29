using ShopCom.DataAccess;
using ShopCom.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCom.Handlers
{
    public class ProductSearchHandler : SearchHandler
    {
        ShopDbContext db;

        public ProductSearchHandler()
        {
            this.db = new ShopDbContext();
        }
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            if (string.IsNullOrWhiteSpace(newValue)) { 
                ItemsSource = null;
                return;
            }

            var results = db.Products.Where(p => p.Name.ToLowerInvariant().Contains(newValue.ToLowerInvariant())).ToList();

            ItemsSource = results;

        }

        protected override async void OnItemSelected(object item)
        {
           await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?id={((Product)item).Id}");
        }
    }
}
