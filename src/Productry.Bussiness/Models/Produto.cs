using System;
using System.Collections.Generic;

namespace Productry.Bussiness.Models
{
    public class Produto : Entity
    {
        public Produto(string nome, double valorUnitario, int qtdeEstoque)
        {
            Nome = nome;
            ValorUnitario = QtdeEstoque;
            QtdeEstoque = qtdeEstoque;
            DataCadastro = DateTime.Now;
        }

        public string Nome { get; private set; }
        public double ValorUnitario { get; private set; }
        public int QtdeEstoque { get; private set; }
        public DateTime DataCadastro { get; private set; }
        
        // Relacionamento Entity Framework Core
        public List<Compra> Compras { get; set; }


        public bool AlteraNome(string novoNome)
        {
            if (string.IsNullOrEmpty(novoNome))
                return false;
            
            Nome = novoNome;
            return true;
        }

        public bool AlteraEstoque(int novaQuantidade)
        {
            if (novaQuantidade < 0)
                return false;

            QtdeEstoque = novaQuantidade;

            return true;
        }

        public bool AlteraValorUnitario(double novoValor)
        {
            if (novoValor < 0)
                return false;

            ValorUnitario = novoValor;
            return true;
        }

     

    }
}
