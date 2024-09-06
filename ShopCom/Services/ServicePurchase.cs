using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ShopCom.Services;

public class ServicePurchase
{
    private HttpClient _client;

    public ServicePurchase(HttpClient client)
    {
        _client = client;
    }

    public async Task<bool> SendData(IEnumerable<Purchase> purchases) {
        var uri = "http://172.27.192.1:81/api/compra";
        var body = new { 
            data = purchases
        };

        var result = await _client.PostAsJsonAsync(uri, body);
        return result.IsSuccessStatusCode;
    }
}
