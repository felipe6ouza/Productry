using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Productry.API.ViewModels
{
    public class ProdutoViewModel
    {
        
        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("valor_unitario")]
        public double ValorUnitario { get; set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [JsonPropertyName("qtde_estoque")]
        public int QtdeEstoque { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; private set; }

        public List<CompraViewModel> Compras { get; set; }

    }
}
