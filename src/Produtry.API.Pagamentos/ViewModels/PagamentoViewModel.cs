using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Produtry.API.Pagamentos.ViewModels
{
    public class PagamentoViewModel
    {
        [JsonProperty("valor")]
        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        public decimal Valor { get; set; }

        [JsonProperty("cartao")]
        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        public CartaoViewModel Cartao { get; set; }
    }
}
