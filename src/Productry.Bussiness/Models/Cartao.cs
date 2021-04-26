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

        public string Titular { get;  set; }

        public string Numero { get;  set; }

        public string DataExpiracao { get;  set; }

        public string Bandeira { get;  set; }

        public string Cvv { get;  set; }
    }
}
