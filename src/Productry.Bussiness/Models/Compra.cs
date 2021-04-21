using System;

namespace Productry.Bussiness.Models
{

    public class Compra : Entity
    {
        public Compra()
        {
            DataCompra = DateTime.Now;
        }
        public Compra(int produtoId, int qtdeComprada, Cartao cartao)
        {
            ProdutoId = produtoId;
            QtdeComprada = qtdeComprada;
            Cartao = cartao;
            DataCompra = DateTime.Now;
        }

        public int ProdutoId { get; set; }

        public int QtdeComprada { get; set; }

        public Cartao Cartao { get; set; }

        public DateTime DataCompra { get; private set; }

        // Relacionamento Entity Framework Core
        public Produto Produto { get; set; }
    }
}
