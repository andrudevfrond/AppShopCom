using Newtonsoft.Json;
using ShopCom.Models.Backend.Login;
using System.Text;

namespace ShopCom.Services;

public class SecurityService
{
    private HttpClient _client;

    public SecurityService(HttpClient client)
    {
        _client = client;
    }

    public async Task<bool> Login(string? email,string? password) {
        var uri = "http://172.27.192.1:81/api/usuario/login";

        var loginRequest = new LoginRequest { 
            Email = email,
            Password = password
        };
        var json = JsonConvert.SerializeObject(loginRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(uri, content);

        if (!response.IsSuccessStatusCode) return false;

        var jsonresult = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<UsuarioResponse>(jsonresult);
        
        if (result == null) return false;

        // Almacenar los datos en el mobil
        Preferences.Set("accesstoken", result.Token);
        Preferences.Set("userId", result.Id);
        Preferences.Set("email", result.Email);
        Preferences.Set("nombre", $"{result.Nombre} {result.Apellido}");
        Preferences.Set("telefono", result.Telefono);
        Preferences.Set("username", result.UserName);

        return true;
    }
}
