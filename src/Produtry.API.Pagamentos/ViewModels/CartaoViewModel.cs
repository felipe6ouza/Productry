using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Produtry.API.Pagamentos.ViewModels
{
    public class CartaoViewModel
    {
        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [JsonPropertyName("titular")]
        public string Titular { get; set; }
        
        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [JsonPropertyName("numero")]
        [CreditCard(ErrorMessage = "Cartão de Crédito Inválido")]
        public string Numero { get; set; }
        
        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [JsonPropertyName("data_expiracao")]
        public string DataExpiracao { get; set; }


        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [JsonPropertyName("bandeira")]
        public string Bandeira { get; set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [JsonPropertyName("cvv")]
        public string Cvv { get; set; }
    }
}
