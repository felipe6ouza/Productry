using Productry.Bussiness.Contracts;

namespace Productry.Bussiness.Models
{
    public class Cartao : Entity
    {
        public Cartao(string titular, string numero, string dataExpiracao, string bandeira, string cvv)
        {
            Titular = titular;
            Numero = numero;
            DataExpiracao = dataExpiracao;
            Bandeira = bandeira;
            Cvv = cvv;

            AddNotifications(new ValidCardContract(this));
        }

        public string Titular { get; private set; }

        public string Numero { get; private set; }

        public string DataExpiracao { get; private set; }

        public string Bandeira { get; private set; }

        public string Cvv { get; private set; }
    }
}
