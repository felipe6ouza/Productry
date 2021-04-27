using System.Text.Json.Serialization;

namespace Productry.Bussiness.Services.Reponses
{
    public class AutorizarCompraResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set;}
        [JsonPropertyName("valor")]
        public double Valor { get; set; }
        
        [JsonPropertyName("estado")]
        public string Estado { get; set; }
    }
}
