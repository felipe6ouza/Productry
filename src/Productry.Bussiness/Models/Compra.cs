using Productry.Bussiness.Contracts;
using System;

namespace Productry.Bussiness.Models
{

    public class Compra : Entity
    {
 
        public Compra(int produtoId, int qtdeComprada, Cartao cartao)
        {
            ProdutoId = produtoId;
            QtdeComprada = qtdeComprada;
            Cartao = cartao;
            DataCompra = DateTime.Now;

            AddNotifications(new ValidCardContract(this.Cartao));
        }

        private Compra(int produtoId, int qtdeComprada)
        {
            ProdutoId = produtoId;
            QtdeComprada = qtdeComprada;
        }

        public int ProdutoId { get; set; }

        public int QtdeComprada { get; set; }

        public int CartaoId { get; set; }

        public Cartao Cartao { get; set; }

        public DateTime DataCompra { get; private set; }

        // Relacionamento Entity Framework Core
        public Produto Produto { get; set; }
    }
}
