using Project.Web.DTOs.ValueObjects.OnCepService;
using Project.Web.Interfaces.Services;

namespace Project.Web.Services;

public class CepService : ICepService
{
    public async Task<LocalAddress> SearchByPostalCode(string postalCode)
    {
        var url = $"https://viacep.com.br/ws/{postalCode.Replace(".", string.Empty).Replace("-", string.Empty)}/json/";

        var http = new HttpClient();
        var response = await http.GetFromJsonAsync<LocalAddress>(url);

        return response;
    }
}