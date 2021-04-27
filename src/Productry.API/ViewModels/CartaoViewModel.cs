using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Productry.API.ViewModels
{
    public class CartaoViewModel
    {
        [Key]
        public int Id { get; private set; }

        [JsonPropertyName("titular")]
        public string Titular { get; set; }

        [JsonPropertyName("numero")]
        [CreditCard(ErrorMessage = "Cartão de Crédito Inválido")]
        public string Numero { get; set; }

        [JsonPropertyName("data_expiracao")]
        [RegularExpression(@"^(?:[012]?[0-9]|3[01])[./-](?:0?[1-9]|1[0-2])[./-](?:[0-9]{2}){1,2}$",
      ErrorMessage = "Data de Expiração do Cartão em Formato Inválido. Insira no padrão dd-mm-yyyy.")]
        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        public string DataExpiracao { get; set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [JsonPropertyName("bandeira")]
        public string Bandeira { get; set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [JsonPropertyName("cvv")]
        public string Cvv { get; set; }
    }
}
