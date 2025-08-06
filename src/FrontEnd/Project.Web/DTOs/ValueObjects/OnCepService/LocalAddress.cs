using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Project.Web.DTOs.ValueObjects.OnCepService;

public class LocalAddress
{
    [JsonPropertyName("cep")]
    public string PostalCode { get; set; } = string.Empty;

    [JsonPropertyName("logradouro")]
    public string AddressDescription { get; set; } = string.Empty;

    [JsonPropertyName("complemento")]
    public string Complement { get; set; } = string.Empty;

    [JsonPropertyName("bairro")]
    public string Neighborhood { get; set; } = string.Empty;

    [JsonPropertyName("localidade")]
    public string City { get; set; } = string.Empty;

    [JsonPropertyName("estado")]
    public string State { get; set; } = string.Empty;

    [JsonPropertyName("ibge")]
    public string IBGE { get; set; } = string.Empty;

    [JsonPropertyName("gia")]
    public string GIA { get; set; } = string.Empty;

    [JsonPropertyName("ddd")]
    public string DDD { get; set; } = string.Empty;

    [JsonPropertyName("siafi")]
    public string SIAFI { get; set; } = string.Empty;
}