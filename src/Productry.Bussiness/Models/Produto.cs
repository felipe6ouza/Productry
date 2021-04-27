using Productry.Bussiness.Contracts;
using System;
using System.Collections.Generic;

namespace Productry.Bussiness.Models
{
    public class Produto : Entity
    {
        public Produto(string nome, decimal valorUnitario, int qtdeEstoque)
        {
            Nome = nome;
            ValorUnitario = QtdeEstoque;
            QtdeEstoque = qtdeEstoque;
            DataCadastro = DateTime.Now;

            AddNotifications(new CreateProductContract(this));
        }

        public string Nome { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public int QtdeEstoque { get; private set; }
        public DateTime DataCadastro { get; private set; }
        
        // Relacionamento Entity Framework Core
        public List<Compra> Compras { get; set; }


        public void AlterarNome(string novoNome)
        {          
            Nome = novoNome;
            AddNotifications(new UpdateProductName(this));
        }

        public void AlterarEstoque(int novaQuantidade)
        {
            QtdeEstoque = novaQuantidade;
            AddNotifications(new UpdateStockContract(this));
        }

        public void AlteraValorUnitario(decimal novoValor)
        {
            ValorUnitario = novoValor;
            AddNotifications(new UpdateProductValue(this));

        }



    }
}
