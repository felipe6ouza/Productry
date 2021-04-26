using Productry.Bussiness.Interfaces;
using Productry.Bussiness.Services;
using System.Threading.Tasks;

namespace Productry.Services.Services
{
    public class EstoqueService : BaseService, IEstoqueService
    {

        private readonly IProdutoRepository _produtoRepository;

        public EstoqueService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> AlterarEstoque(int produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null)
                return false;

            produto.AlterarEstoque(quantidade);

            if(!produto.IsValid)
            {
                foreach(var item in produto.Notifications)
                {
                    Notificar(item.Message);
                }

                return false;
            }
           
           return await _produtoRepository.Atualizar(produto);

        }

    }
}
