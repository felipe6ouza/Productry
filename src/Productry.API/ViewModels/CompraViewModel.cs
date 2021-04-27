using Productry.Bussiness.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Productry.API.ViewModels
{
    public class CompraViewModel
    {
        [Key]
        public int Id { get; private set; }

        [JsonPropertyName("produto_id")]
        public int ProdutoId { get; set; }

        [JsonPropertyName("qtde_comprada")]
        public int QtdeComprada { get; set; }

        [JsonPropertyName("cartao")]
        public CartaoViewModel Cartao { get; set; }

        public DateTime DataCompra { get; private set; }

        public ProdutoViewModel Produto { get; set; }
    }
}
